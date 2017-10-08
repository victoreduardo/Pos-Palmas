using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        static string resposta = "";
        static bool dig_resposta = false;
        static bool modo_admin = false;
        static int posicaoAtual = -1;
        static int qtdEnter = 0;

        static void Main(string[] args)
        {
            ConsoleKeyInfo cki;

            string frase_padrao = "Oh maquina dotada de inteligencia";

            Console.WriteLine("\n-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("Olá! Seja bem vindo a maquina de inteligencia");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("-------------------------------------------------");
            Console.WriteLine("\nDigite uma pergunta...");

            do
            {
                cki = Console.ReadKey(true);

                if (resposta == "" && posicaoAtual == -1)
                {
                    if (cki.KeyChar.Equals(';')) { 
                        dig_resposta = true;
                        modo_admin = true;
                        posicaoAtual++;
                        Console.Write("");
                        continue;
                    }
                    else
                        dig_resposta = false;
                }

                if (cki.Key == ConsoleKey.Enter && !modo_admin) {
                    Console.WriteLine("\n\nEstou muito cansado agora. Respondo apenas para meu mestre.");
                    resetConsole();
                    continue;
                }

                if (modo_admin) { 
                    if (dig_resposta)
                    {
                        if (cki.Key != ConsoleKey.Enter) { 
                            resposta += cki.KeyChar;
                            if (posicaoAtual < frase_padrao.ToCharArray().Count())
                                Console.Write(frase_padrao[posicaoAtual]);
                                posicaoAtual++;
                        } else { 
                            dig_resposta = false;
                            qtdEnter++;
                        }
                    } else
                    {
                        if (cki.Key == ConsoleKey.Enter && qtdEnter == 1) { 
                            Console.WriteLine("\nR: {0}", resposta);
                            resetConsole();
                            continue;
                        }
                        else
                            Console.Write(cki.KeyChar);
                    }
                }
                else
                    Console.Write(cki.KeyChar);

            } while (cki.Key != ConsoleKey.Escape);

        }
        public static void resetConsole()
        {
            qtdEnter = 0;
            posicaoAtual = -1;
            modo_admin = false;
            dig_resposta = false;
            resposta = "";
            Console.WriteLine("\n\nDigite uma pergunta...");
        }
    }
}
