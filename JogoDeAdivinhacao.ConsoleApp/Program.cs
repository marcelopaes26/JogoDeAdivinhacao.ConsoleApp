namespace JogoDeAdivinhacaoConsoleApp
{
    internal class Program
    {
        //V4.0 - Multiplas tentativas
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("Jogo de Adivinhação");
                Console.WriteLine("-------------------------------------");

                //escolha de dificuldade
                Console.WriteLine("Escolha um nível de dificuldade");
                Console.WriteLine("-------------------------------------");
                Console.WriteLine("1 - Fácil (10 tentativas)");
                Console.WriteLine("2 - Normal (5 tentativas)");
                Console.WriteLine("3 - Difícil (3 tentativas)");
                Console.WriteLine("-------------------------------------");

                Console.Write("Digite sua escolha: ");
                string escolhaDeDificuldade = Console.ReadLine();

                int totalDeTentativas = 0;

                if (escolhaDeDificuldade == "1")
                {
                    totalDeTentativas = 10;
                }
                else if (escolhaDeDificuldade == "2")
                {
                    totalDeTentativas = 5;
                }
                else
                {
                    totalDeTentativas = 3;
                }



                //escolha numero aleatório
                Random geradorDeNumeros = new Random();

                int numeroSecreto = geradorDeNumeros.Next(1, 21);



                //lógica do jogo

                for (int tentativa = 1; tentativa <= totalDeTentativas; tentativa++)
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------");
                    Console.WriteLine($"Tentativa {tentativa} de {totalDeTentativas}");
                    Console.WriteLine("-------------------------------------");
                    Console.Write("Digite um numero (de 1 à 20) para chutar: ");
                    int numeroDigitado = Convert.ToInt32(Console.ReadLine());

                    if (numeroDigitado == numeroSecreto)
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("Parabéns, você acertou!");
                        Console.WriteLine("-------------------------------------");
                    }
                    else if (numeroDigitado > numeroSecreto)
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("O numero digitado foi maior que o numero secreto!");
                        Console.WriteLine("-------------------------------------");
                    }
                    else
                    {
                        Console.WriteLine("-------------------------------------");
                        Console.WriteLine("O numero digitado foi menor que o numero secreto!");
                        Console.WriteLine("-------------------------------------");
                    }
                    Console.WriteLine("Deseja Continuar? (S/N");
                    string opcaoContinuar = Console.ReadLine().ToUpper();
                    if (opcaoContinuar == "S")
                    {
                        break;
                    }

                    Console.WriteLine("Pressione ENTER para continuar...");
                    Console.ReadLine();
                }
            
            }
             
            
        }
    }
}