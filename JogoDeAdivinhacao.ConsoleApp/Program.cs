﻿namespace JogoDeAdivinhacaoConsoleApp
{
    internal class Program
    {
        // Cria uma instância da classe Random
        static Random geradorDeNumeros = new Random();

        // Cria uma variável inteira que recebe a instância de Random e
        // utiliza o método Next dessa classe para gerar números aleatórios de 1 a 20
        static int numeroSecreto = geradorDeNumeros.Next(1, 21);

        // Cria a varíavel do tipo float para armezenar a pontuação inicial do usuário
        static float pontuacao = 1000;

        // Cria uma lista vazia para armazenar os números chutados
        static List<int> numerosChutados = new List<int> { };

        // Cria uma constante do tipo int para armazenar o valor de 2000ms
        const int tempo = 2000;

        static int totalDeTentativas = 0;

        static int cont = 1;

        static void Main(string[] args)
        {
            bool opcaoContinuar = true;

            do
            {
                if (int.TryParse(MostrarMenu(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1: totalDeTentativas = 10; break;
                        case 2: totalDeTentativas = 5; break;
                        case 3: totalDeTentativas = 3; break;
                        default: ApresentarMensagem("Opção inválida. Tente novamente!"); continue;
                    }
                }
                else
                {
                    ApresentarMensagem("Entrada inválida. Digite um número inteiro!");
                    continue;
                }

                MostrarCabecalho();

                Console.WriteLine($"Pontuação final: {pontuacao}");

                opcaoContinuar = OpcaoContinuar();

                Console.Clear();

            } while (opcaoContinuar);

        }

        // Função para exibir o Menu que retornar a string opcao
        static string MostrarMenu()
        {
            Console.Clear();
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("\tJogo de Adivinhação");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("Escolha um nível de dificuldade");
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine("1 - Fácil (10 tentativas)");
            Console.WriteLine("2 - Normal (5 tentativas)");
            Console.WriteLine("3 - Difícil (3 tentativas)");
            Console.WriteLine("-------------------------------------------");

            Console.Write("Digite sua escolha: ");
            string opcao = Console.ReadLine();

            return opcao;
        }

        // Função para retornar a opção continuar
        static bool OpcaoContinuar()
        {
            string opcaoContinuar = "S";
            bool desejaContinuar = true;

            while (true)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine("Deseja Continuar? (S/N)");
                opcaoContinuar = Console.ReadLine().ToUpper();

                if (opcaoContinuar != "S" && opcaoContinuar != "N")
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Opção inválida. Tente novamente!");
                    continue;
                }
                else if (opcaoContinuar == "N")
                {
                    desejaContinuar = false;
                }
                break;
            }

            return desejaContinuar;
        }

        static void MostrarCabecalho()
        {
            Console.Clear();

            if (cont <= totalDeTentativas)
            {
                Console.WriteLine("-------------------------------------------");
                Console.WriteLine($"Tentativa {cont} de {totalDeTentativas}");
                Console.WriteLine("-------------------------------------------");

                // Utiliza o método Any da Lista para validar se possui qualquer valor dentro dela
                // e então imprime os valores na tela, caso a Lista não esteja vazia
                if (numerosChutados.Any())
                {
                    // Utiliza o método Join da clase String para "juntar" os elementos da Lista separados
                    // por vírgula e apresentar na tela
                    Console.WriteLine($"Números já chutados: {String.Join(", ", numerosChutados)}");
                    Console.WriteLine("-------------------------------------------");
                }
            }

            cont++;

        }

        static void LogicaDoJogo()
        {
            for (int i = 1; i <= totalDeTentativas; i++)
            {
                int numeroDigitado = ObterNumero();

                if (numeroDigitado < 0)
                {
                    i--;
                    continue;
                }

                if (numeroSecreto == numeroDigitado)
                {
                    ApresentarMensagem("Parabéns, você acertou!");
                    break;
                }

                pontuacao -= Math.Abs((float)(numeroDigitado - numeroSecreto) / 2);

                if (numeroSecreto > numeroDigitado)
                    ApresentarMensagem("O número secreto é maior!");
                else
                    ApresentarMensagem("O número secreto é menor!");

                RegistrarNumeroChutado(numeroDigitado);
            }
        }


        static int ObterNumero()
        {
            Console.Write("Digite um número (de 1 à 20) para chutar: ");

            if (int.TryParse(Console.ReadLine(), out int numeroDigitado))
            {
                ApresentarMensagem("Entrada inválida. Digite um número inteiro!");
                return -1;
            }
            if (numerosChutados.Contains(numeroDigitado))
            {
                ApresentarMensagem("Número já chutado!");
                return -1;
            }
            if (numeroDigitado < 1 || numeroDigitado > 20)
            {
                ApresentarMensagem("O número digitado está fora do intervalo!");
                return -1;
            }

            return numeroDigitado;
        }


        static void ApresentarMensagem(string mensagem)
        {
            Console.WriteLine("-------------------------------------------");
            Console.WriteLine(mensagem);
            Console.WriteLine("-------------------------------------------");

            // Utiliza o método Sleep para suspender a thread atual por um tempo em milisegundos
            // então é passado a constante tempo como parâmetro, a qual foi armazenada o valor 2000
            System.Threading.Thread.Sleep(tempo);
        }

        static void RegistrarNumeroChutado(int numero)
        {
            numerosChutados.Add(numero);
        }
    }
}