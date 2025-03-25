namespace JogoDeAdivinhacaoConsoleApp
{
    internal class Program
    {
        // Função para exibir o Menu que retornar a string opcao
        static string MostrarMenu()
        {
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
        static void Main(string[] args)
        {

            // Cria uma instância da classe Random
            Random geradorDeNumeros = new Random();

            // Cria uma variável inteira que recebe a instância de Random e
            // utiliza o método Next dessa classe para gerar números aleatórios de 1 a 20
            int numeroSecreto = geradorDeNumeros.Next(1, 21);

            int totalDeTentativas = 0;

            string opcaoContinuar = "S";

            // Cria uma constante do tipo int para armazenar o valor de 2000ms
            const int tempo = 2000;

            do
            {
                // Cria a varíavel do tipo float para armezenar a pontuação inicial do usuário
                float pontuacao = 1000;

                // Cria uma lista vazia para armazenar os números chutados
                List<int> numerosChutados = new List<int> {};

                // Utiliza o método TryParse que recebe uma string (MostrarMenu) e transforma em um inteiro (opcao)
                // para invalidar caso o usuário digite texto
                if (int.TryParse(MostrarMenu(), out int opcao))
                {
                    switch (opcao)
                    {
                        case 1:
                            totalDeTentativas = 10;
                            break;
                        case 2:
                            totalDeTentativas = 5;
                            break;
                        case 3:
                            totalDeTentativas = 3;
                            break;
                        default:
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Opção inválida. Tente novamente!");
                            continue;
                    }
                }
                else
                {
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine("Entrada inválida. Digite um número inteiro!");
                    continue;
                }

                // Lógica do jogo
                for (int i = 1; i <= totalDeTentativas; i++)
                {
                    Console.Clear();
                    Console.WriteLine("-------------------------------------------");
                    Console.WriteLine($"Tentativa {i} de {totalDeTentativas}");
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

                    Console.Write("Digite um número (de 1 à 20) para chutar: ");

                    // Mais uma vez utilizado o método TryParse para validar a entrada do usuário
                    // agora passando o Console.Readline() como primeiro parâmetro, pois este retorna uma string
                    if (int.TryParse(Console.ReadLine(), out int numeroDigitado))
                    {

                        // Utiliza o método Contains da Lista para validar se o número digitado já contém na lista
                        // e então caso tiver, apresenta o número já chutado
                        if (numerosChutados.Contains(numeroDigitado))
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Número já chutado!");
                            Console.WriteLine("-------------------------------------------");

                            // Utiliza o método Sleep para suspender a thread atual por um tempo em milisegundos
                            // então é passado a constante tempo como parâmetro, a qual foi armazenada o valor 2000
                            System.Threading.Thread.Sleep(tempo);

                            // Decrementa o i (controlador do loop) para não contar a tentativa do número já chutado
                            i--;
                            continue;
                        }

                        if (numeroDigitado < 1 || numeroDigitado > 20)
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("O número digitado está fora do intervalo!");
                            Console.WriteLine("-------------------------------------------");
                            i--;
                            System.Threading.Thread.Sleep(tempo);
                            continue;
                        }

                        // Após passar as primeiras validações, o número digitado é adicionado
                        // na Lista através do métod Add
                        numerosChutados.Add(numeroDigitado);

                        if (numeroSecreto == numeroDigitado)
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("Parabéns, você acertou!");
                            Console.WriteLine("-------------------------------------------");
                            break;
                        }

                        // Realizada a fórmula da pontuação do jogo utilizando o método Abs da classe
                        // Math para garantir o valor absoluto e forçando a divisão de inteiros
                        // fazendo um cast para float
                        pontuacao -= Math.Abs((float)(numeroDigitado - numeroSecreto) / 2);


                        if (numeroSecreto > numeroDigitado)
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("O número secreto é maior!");
                            Console.WriteLine("-------------------------------------------");
                            System.Threading.Thread.Sleep(tempo);
                        }
                        else
                        {
                            Console.WriteLine("-------------------------------------------");
                            Console.WriteLine("O número secreto é menor!");
                            Console.WriteLine("-------------------------------------------");
                            System.Threading.Thread.Sleep(tempo);
                        }

                    }
                    else
                    {
                        Console.WriteLine("-------------------------------------------");
                        Console.WriteLine("Entrada inválida. Digite um número inteiro!");
                        Console.WriteLine("-------------------------------------------");
                        System.Threading.Thread.Sleep(tempo);
                        i--;
                        continue;
                    }

                }

                Console.WriteLine($"Pontuação final: {pontuacao}");

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
                    break;
                }

                Console.Clear();

            } while (opcaoContinuar == "S");

        }
    }
}