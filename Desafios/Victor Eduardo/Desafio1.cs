using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static string resposta = ""; //variavel que guarda a resposta
        static bool dig_resposta = false; //modo digitando resposta 
        static bool modo_admin = false; //modo administrador
        static int posicaoAtual = -1; //posicao do caracter digitado atual
        static int qtdEnter = 0; //qtd de enter pressionados

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;
            //imprime a msg inicial
            string frase_padrao = "Oh maquina dotada de inteligencia";

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Olá! Seja bem vindo a maquina de inteligencia");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\nDigite uma pergunta...");

            //Loop de captura de teclas
            do
            {
                //ler o caracter digitado e nao exibe no console
                cki = Console.ReadKey(true);

                //verifica se esta iniciando uma nova frase
                if (resposta == "" && posicaoAtual == -1)
                {
                    //caso digite o caracter coringa, ativa o modo admin
                    //e ativa a exibicao da frase padrao a cada tecla
                    if (cki.KeyChar.Equals(';')) { 
                        dig_resposta = true; //ativa modo digitando resposta
                        modo_admin = true; //ativa modo administrador
                        posicaoAtual++; //incrementa a posicao do digito
                        Console.Write(""); //imprimi vazio no console
                        continue; 
                    }
                    else //caso nao digite, desativa a digitacao da resposata
                        dig_resposta = false;
                }

                //verifica se pressionou a tecla enter e nao esta no modo admin
                if (cki.Key == ConsoleKey.Enter && !modo_admin) {
                    //exibe a mensagem de cansado
                    Console.WriteLine("\n\nEstou muito cansado agora. Respondo apenas para meu mestre.");
                    //reseta as variaveis do console
                    resetConsole();
                    continue;
                }

                //caso esteja no modo admin
                if (modo_admin) { 
                    if (dig_resposta) //e o modo digitando a resposta ativado
                    {
                        if (cki.Key != ConsoleKey.Enter) { //e precione uma tecla diferente de enter
                            resposta += cki.KeyChar; //guarda o caractere na variavel de resposta
                            if (posicaoAtual < frase_padrao.ToCharArray().Count()) //caso a posicao atual digitada for menor que o tamanho da frase padrao de elogio
                                Console.Write(frase_padrao[posicaoAtual]); //escreve o caracter da posicao referente ao elogio
                            posicaoAtual++; //incrementa a variavel do digito atual
                        } else {  //caso pressione enter
                            dig_resposta = false; //indica que nao esta mais digitando a resposta
                            qtdEnter++; //indica que foi pressionado + 1 enter
                        }
                    } else //caso nao esteja em modo digitando msg
                    {
                        if (cki.Key == ConsoleKey.Enter && qtdEnter == 1) {  // e digite enter, ja tendo digitado uma vez enter
                            Console.WriteLine("\nR: {0}", resposta); //exibe a resposta
                            resetConsole();//reseta o console
                            continue;
                        }
                        else //caso nao digite enter, exibe o caracter digitado
                            Console.Write(cki.KeyChar);
                    }
                } //caso nao esteja no modo admin, exibe o caracter digitado
                else
                    Console.Write(cki.KeyChar);

            } while (cki.Key != ConsoleKey.Escape); //loop enquanto preciona uma tecla diferente de ESC

        }
        
        //metodo responsavel por resetar as variaveis utilizadas
        public static void resetConsole()
        {
            qtdEnter = 0; //zera a qtd. de enter pressionado
            posicaoAtual = -1; //retorna a posicao do digito para -1
            modo_admin = false; //desativa o modo admin
            dig_resposta = false; //desativa o modo de digitando resposta
            resposta = ""; //reseta a variavel que guarda a resposta
            Console.WriteLine("\n\nDigite uma pergunta..."); //escreve a frase para digitar uma nova pergunta
        }
    }
}
