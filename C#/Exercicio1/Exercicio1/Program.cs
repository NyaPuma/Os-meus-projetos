using System.Globalization;
namespace Exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.1                              :::::
            // :::::  Faça um programa que:                      :::::
            // :::::  - leia a cotação do dólar (1 USD em EUR);  :::::
            // :::::  - Leia um valor de dolares a converter;    :::::
            // :::::  - Converta esse valor para euros;          :::::
            // :::::  - Mostre o resultado                       :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::

            double dolar, euro, cotacao;

            Console.WriteLine("Digite o valor de dolar:");
            dolar = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Digite o valor de cotação:");
            cotacao = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            euro = dolar * cotacao;
            Console.WriteLine($"O valor em euros é: {euro}");

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.2                                                        :::::
            // :::::  Faça um programa para pagamento de comissão de vendedores de peças,  :::::
            // :::::  levando-se em consideração que sua comissão será de 5 % do total da  :::::
            // :::::  venda e que você tem os seguintes dados:                             :::::
            // :::::  - Identificação do vendedor                                          :::::
            // :::::  - Código da peça                                                     :::::
            // :::::  - Preço unitário da peça                                             :::::
            // :::::  - Quantidade vendida                                                 :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string vendedor, peca;
            double precopeca, pagamento;
            int quantidadevendida;

            const double comissao = 0.05;

            Console.WriteLine("Identificação do vendedor:");
            vendedor = Console.ReadLine();

            Console.WriteLine("Código da peça:");
            peca = Console.ReadLine();

            Console.WriteLine("Preço unitário da peça:");
            precopeca = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Quantidade vendida:");
            quantidadevendida = int.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            pagamento = precopeca * quantidadevendida * comissao;

            Console.WriteLine($"Identificação do vendedor: {vendedor}, Código da peça: {peca}, Preço unitário da peça: {precopeca}, Quantidade vendida: {quantidadevendida}, Comissão a pagar: {pagamento}");

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.3                                                                       :::::
            // :::::  Efetuar o cálculo da quantidade de litros de combustível gasta em uma viagem,       :::::
            // :::::  utilizando um automóvel que faz 12 Km por litro.Para obter o cálculo, o utilizador  :::::
            // :::::  deve fornecer o tempo gasto na viagem e a velocidade média.                         :::::
            // :::::  DISTANCIA = TEMPO * VELOCIDADE                                                      :::::
            // :::::  LITROS_USADOS = DISTANCIA / 12.                                                     :::::
            // :::::  O programa deve apresentar os valores da velocidade média, tempo gasto,             :::::
            // :::::  a distância percorrida e a quantidade de litros utilizada na viagem.                :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            double distancia;
            double tempo;
            double velocidade;
            double litrosusados;

            const double consumo = 12;

            Console.WriteLine("Tempo gasto na viagem:");
            tempo = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Velocidade média:");
            velocidade = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            distancia = tempo * velocidade;
            litrosusados = distancia / consumo;

            Console.WriteLine($"Velocidade média: {velocidade}, Tempo gasto: {tempo}, Distância percorrida: {distancia}, Quantidade de litros utilizada: {litrosusados}");

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.4                                                                                  :::::
            // :::::                                                                                                 :::::
            // :::::  Elabore um programa em C# do tipo console que leia as medidas dos lados de 2 triângulos.       :::::
            // :::::  Calcule a área(A) de cada triangulo onde:                                                      :::::
            // :::::                                                                                                 :::::
            // :::::  p = ( lado1 + lado2 + lado3 ) / 2                                                              :::::
            // :::::  A = SQRT( p * ( p - lado1 ) * ( p - lado2 ) * ( p - lado3 )                                    :::::
            // :::::                                                                                                 :::::
            // :::::  Comparar as áreas dos 2 triângulos e indicar na console o valor de cada área de cada           :::::
            // :::::  triangulo e o triangulo com maior área.                                                        :::::
            // :::::                                                                                                 :::::
            // :::::  Certifique-se de utilizar conversão de strings para números (.Parse), e considere também a     :::::
            // :::::  utilização de CultureInfo.InvariantCulture para garantir a correta interpretação dos valores.  :::::
            // :::::                                                                                                 :::::
            // :::::  Teste para valores: (3.00; 4.00; 5.00) e (7.50; 4.50; 4.02)                                    :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            double lado1_1;
            double lado2_1;
            double lado3_1;
            double p_1;
            double A_1;

            double lado1_2;
            double lado2_2;
            double lado3_2;
            double p_2;
            double A_2;

            // :::::::::::::::::::::::::::::::::
            // :::::  Primeiro Triângulo  ::::::
            // :::::::::::::::::::::::::::::::::

            Console.WriteLine("Lado 1 do primeiro triângulo:");
            lado1_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lado 2 do primeiro triângulo:");
            lado2_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lado 3 do primeiro triângulo:");
            lado3_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            p_1 = (lado1_1 + lado2_1 + lado3_1) / 2;
            A_1 = Math.Sqrt(p_1 * (p_1 - lado1_1) * (p_1 - lado2_1) * (p_1 - lado3_1));

            // :::::::::::::::::::::::::::::::
            // :::::  Segundo Triângulo  :::::
            // :::::::::::::::::::::::::::::::

            Console.WriteLine("Lado 1 do segundo triângulo:");
            lado1_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lado 2 do segundo triângulo:");
            lado2_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine("Lado 3 do segundo triângulo:");
            lado3_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            p_2 = (lado1_2 + lado2_2 + lado3_2) / 2;
            A_2 = Math.Sqrt(p_2 * (p_2 - lado1_2) * (p_2 - lado2_2) * (p_2 - lado3_2));

            Console.WriteLine($"A área do primeiro triângulo é {A_1} e a do segundo triângulo é {A_2}");

            // :::::::::::::::::::::::::::::::::::::::
            // :::::  Comparação dos Triângulos  :::::
            // :::::::::::::::::::::::::::::::::::::::

            if (A_1 > A_2)
            {
                Console.WriteLine("O primeiro triângulo é maior do que o segundo triângulo");
            }

            else
            {
                Console.WriteLine("O segundo triângulo é maior do que o primeiro triângulo");
            }

            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.5                                                                   :::::
            // :::::                                                                                  :::::
            // :::::  Escreva um programa do tipo console em C# que solicite ao utilizador            :::::
            // :::::  que insira o nome de 3 alunos (A, B, e C) e as suas notas em três disciplinas.  :::::
            // :::::  Em seguida, calcule a média das notas e exiba o nome do aluno com maior media.  :::::
            // :::::                                                                                  :::::
            // :::::  Certifique-se de utilizar conversão de strings para números (double.Parse),     :::::
            // :::::  e considere também a utilização de CultureInfo.InvariantCulture para garantir   :::::
            // :::::  a correta interpretação dos valores.                                            :::::
            // :::::                                                                                  :::::
            // :::::  (Sem utilizar vetores)                                                          :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string aluno_a;
            string aluno_b;
            string aluno_c;

            double nota_aluno_a_disciplina_1;
            double nota_aluno_a_disciplina_2;
            double nota_aluno_a_disciplina_3;
            double media_notas_aluno_a;

            double nota_aluno_b_disciplina_1;
            double nota_aluno_b_disciplina_2;
            double nota_aluno_b_disciplina_3;
            double media_notas_aluno_b;

            double nota_aluno_c_disciplina_1;
            double nota_aluno_c_disciplina_2;
            double nota_aluno_c_disciplina_3;
            double media_notas_aluno_c;

            // :::::::::::::::::::::
            // :::::  Aluno A  :::::
            // :::::::::::::::::::::

            Console.WriteLine("Identificação do aluno a:");
            aluno_a = Console.ReadLine();

            Console.WriteLine($"Nota 1 do {aluno_a}:");
            nota_aluno_a_disciplina_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 2 do {aluno_a}:");
            nota_aluno_a_disciplina_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 3 do {aluno_a}:");
            nota_aluno_a_disciplina_3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            media_notas_aluno_a = (nota_aluno_a_disciplina_1 + nota_aluno_a_disciplina_2 + nota_aluno_a_disciplina_3) / 3;

            // :::::::::::::::::::::
            // :::::  Aluno B  :::::
            // :::::::::::::::::::::

            Console.WriteLine("Identificação do aluno b:");
            aluno_b = Console.ReadLine();

            Console.WriteLine($"Nota 1 do {aluno_b}:");
            nota_aluno_b_disciplina_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 2 do {aluno_b}:");
            nota_aluno_b_disciplina_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 3 do {aluno_b}:");
            nota_aluno_b_disciplina_3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            media_notas_aluno_b = (nota_aluno_b_disciplina_1 + nota_aluno_b_disciplina_2 + nota_aluno_b_disciplina_3) / 3;

            // :::::::::::::::::::::
            // :::::  Aluno C  :::::
            // :::::::::::::::::::::

            Console.WriteLine("Identificação do aluno c:");
            aluno_c = Console.ReadLine();

            Console.WriteLine($"Nota 1 do {aluno_c}:");
            nota_aluno_c_disciplina_1 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 2 do {aluno_c}:");
            nota_aluno_c_disciplina_2 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            Console.WriteLine($"Nota 3 do {aluno_c}:");
            nota_aluno_c_disciplina_3 = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

            media_notas_aluno_c = (nota_aluno_c_disciplina_1 + nota_aluno_c_disciplina_2 + nota_aluno_c_disciplina_3) / 3;

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Verificação dos valores da média + mensagem sobre a maior média  :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            if (media_notas_aluno_a > media_notas_aluno_b && media_notas_aluno_a > media_notas_aluno_c)
            {
                Console.WriteLine($"A média de notas do aluno {aluno_a}, {media_notas_aluno_a}, é maior do que a dos alunos {aluno_b} e {aluno_c}");
            }

            else if (media_notas_aluno_b > media_notas_aluno_c && media_notas_aluno_b > media_notas_aluno_a)
            {
                Console.WriteLine($"A média de notas do aluno {aluno_b}, {media_notas_aluno_b}, é maior do que a dos alunos {aluno_a} e {aluno_c}");
            }

            else
            {
                Console.WriteLine($"A média de notas do aluno {aluno_c}, {media_notas_aluno_c}, é maior do que a dos alunos {aluno_a} e {aluno_b}");
            }

            //  :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //  :::::::::::::::::::::::: SWITCH CASE ::::::::::::::::::::::::
            //  :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //  switch(nota)
            //  {
            //      case 1:
            //          Console.WriteLine("Fraco");
            //          break;
            //
            //      case 2:
            //          Console.WriteLine("Médio");
            //          break;
            //
            //      case 3:
            //          Console.WriteLine("Bom");
            //          break;
            //
            //      case 4:
            //          Console.WriteLine("Excelente");
            //          break;
            //
            //      default:
            //          Console.WriteLine("Valor fora do intervalo");
            //          break;
            //  }
            //  :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //  :::::::::::::::::::::::: SWITCH CASE ::::::::::::::::::::::::
            //  :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            // ----------------------------------------------------------------------------------------------------------------------------------------
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.6                                     :::::
            // :::::                                                    :::::
            // :::::  Faça um programa que dada a idade de um nadador,  :::::
            // :::::  classifique-o em uma das seguintes categorias:    :::::
            // :::::                                                    :::::
            // :::::  - Infantil A = 5 a 7 anos                         :::::
            // :::::  - Infantil B = 8 a 11 anos                        :::::
            // :::::  - Juvenil A = 12 a 13 anos                        :::::
            // :::::  - Juvenil B = 14 a 17 anos                        :::::
            // :::::  - Adultos = Maiores de 18 anos                    :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            int idade;

            Console.WriteLine("Idade do nadador:");
            idade = int.Parse(Console.ReadLine());

            switch (idade)
            {
                case int n when (idade >= 5 && idade <= 7):
                    Console.WriteLine("Infantil A");
                    break;

                case int n when (idade >= 8 && idade <= 11):
                    Console.WriteLine("Infantil B");
                    break;

                case int n when (idade >= 12 && idade <= 13):
                    Console.WriteLine("Juvenil A");
                    break;

                case int n when (idade >= 14 && idade <= 17):
                    Console.WriteLine("Juvenil B");
                    break;

                default:
                    Console.WriteLine("Adulto");
                    break;
            }

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Exercicio 1.7                                                                                            :::::
            // :::::                                                                                                           :::::
            // :::::  Faça um programa de conversão de base numérica.                                                          :::::
            // :::::  O programa deverá apresentar um menu de entrada                                                          :::::
            // :::::  com as seguintes opções:                                                                                 :::::
            // :::::                                                                                                           :::::
            // :::::  1 – Adição                                                                                               :::::
            // :::::  2 – Subtração                                                                                            :::::
            // :::::  3 – Multiplicação                                                                                        :::::
            // :::::  4 – Divisão                                                                                              :::::
            // :::::                                                                                                           :::::
            // :::::  Informe a opção:                                                                                         :::::
            // :::::  A partir da opção escolhida, o programa deverá solicitar para que o utilizador digite dois números.      :::::
            // :::::  Em seguida, o programa deve exibir o resultado da opção indicada pelo usuário e perguntar ao utilizador  :::::
            // :::::  se ele deseja voltar ao menu principal. Caso a resposta seja ´S´ ou ´s´, deverá voltar ao menu,          :::::
            // :::::  caso contrário deverá encerrar o programa.                                                               :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string continuar;
            int menu;
            int numero1;
            int numero2;
            int adicao;
            int subtracao;
            double multiplicacao;
            double divisao;

            continuar = "s";

            while (continuar == "S" || continuar == "s")
            {
                //  ::::: Menu :::::
                Console.WriteLine("1 - Adição");
                Console.WriteLine("2 - Subtração");
                Console.WriteLine("3 - Multiplicação");
                Console.WriteLine("4 - Divisão");
                menu = int.Parse(Console.ReadLine());

                //  ::::: Adição :::::
                if (menu == 1)
                {
                    Console.WriteLine("Digite o primeiro número:");
                    numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o segundo número:");
                    numero2 = int.Parse(Console.ReadLine());
                    adicao = numero1 + numero2;
                    Console.WriteLine($"A adição destes dois números é de {adicao}");
                    Console.WriteLine("Deseja continuar (s/N):");
                    continuar = Console.ReadLine();
                }

                //  ::::: Subtração :::::
                else if (menu == 2)
                {
                    Console.WriteLine("Digite o primeiro número:");
                    numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o segundo número:");
                    numero2 = int.Parse(Console.ReadLine());
                    subtracao = numero1 - numero2;
                    Console.WriteLine($"A subtração destes dois números é de {subtracao}");
                    Console.WriteLine("Deseja continuar (s/N):");
                    continuar = Console.ReadLine();
                }

                //  ::::: Multiplicação :::::
                else if (menu == 3)
                {
                    Console.WriteLine("Digite o primeiro número:");
                    numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o segundo número:");
                    numero2 = int.Parse(Console.ReadLine());
                    multiplicacao = numero1 * numero2;
                    Console.WriteLine($"A multiplicação destes dois números é de {multiplicacao}");
                    Console.WriteLine("Deseja continuar (s/N):");
                    continuar = Console.ReadLine();
                }

                //  ::::: Divisão :::::
                else if (menu == 4)
                {
                    Console.WriteLine("Digite o primeiro número:");
                    numero1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Digite o segundo número:");
                    numero2 = int.Parse(Console.ReadLine());
                    divisao = numero1 / numero2;
                    Console.WriteLine($"A divisão destes dois números é de {divisao}");
                    Console.WriteLine("Deseja continuar (s/N):");
                    continuar = Console.ReadLine();
                }

                // ::::: Número inválido :::::
                else
                {
                    Console.WriteLine("Número inválido, introduza um valor válido:");
                }
            }

            //  :::::::::::::::::::::::::::::::::::::::::::::::::::
            //  :::::  Exercicio 1.7 - Resolução alternativa  :::::
            //  :::::::::::::::::::::::::::::::::::::::::::::::::::
            //
            //  string continuar = "s";
            //
            //  while( continuar == "s")
            //  {
            //      Console.Writeline("MENU OPERAÇÔES")
            //      Console.WriteLine("1 - Adição");
            //      Console.WriteLine("2 - Subtração");
            //      Console.WriteLine("3 - Multiplicação");
            //      Console.WriteLine("4 - Divisão");
            //      menu = int.Parse(Console.ReadLine());
            //  
            //      Console.WriteLine("Digite o primeiro número:");
            //      numero1 = int.Parse(Console.ReadLine());
            //      Console.WriteLine("Digite o segundo número:");
            //      numero2 = int.Parse(Console.ReadLine());
            //      
            //      double resultado
            //
            //      switch(opcao)
            //      {
            //          case 1:
            //              resultado = numero1 + numero2
            //              Console.WriteLine($"A adição destes dois números é de {adicao}");
            //              break;
            //
            //          case 2:
            //              resultado = numero1 - numero2
            //              Console.WriteLine($"A subtração destes dois números é de {subtracao}");
            //              break;
            //
            //          case 3:
            //              resultado = numero1 * numero2
            //              Console.WriteLine($"A multiplicação destes dois números é de {multiplicacao}");
            //              break;
            //
            //          case 4:
            //              if (numero2 == 0)
            //              {
            //                  Console.WriteLine("O número tem de ser diferente de zero");
            //              }
            //              else
            //              {
            //                  resultado = numero1 / numero2
            //                  Console.WriteLine($"A divisão destes dois números é de {divisao}");
            //              }
            //              break;
            //          default:
            //              Console.WriteLine("Número inválido, introduza um valor válido:");
            //              break;
            //      }
            //      Console.WriteLine("Deseja continuar?:");
            //      continuar = Consule.Readline();
            //
            //  -------------------------------------------------------------------------------------------------------------------------------------------
            //  :::::::::::::::::::
            //  :::::  WHILE  :::::
            //  :::::::::::::::::::
            //
            //  int contador = 1;
            //
            //  while(contador<=5)
            //  {
            //      Console.WriteLine($"contador: {contador}");
            //
            //      // ::::: Atualizar contador :::::
            //      // ::::: Opção 1 :::::
            //      contador = contador + 1;
            //
            //      // ::::: Opção 2 :::::
            //      contador++;  
            //  }
            //
            //  --------------------------------------------------------------------------------------------------------------------------------------------
            //  ::::::::::::::::
            //  :::::  DO  :::::
            //  ::::::::::::::::
            //
            //  int opcao
            //  do
            //  {
            //      Console.Writeline("menu");
            //      Console.Writeline("1-opção1");
            //      Console.Writeline("2-opção2");
            //      Console.Writeline("Escolha a opção");
            //      opcao = int.Parse(Console.Readline());
            //
            //      if (opcao == 2)
            //      {
            //           break;
            //      }
            //  }
        }
    }
}
