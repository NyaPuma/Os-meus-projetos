namespace Exercicio_extra___13_04_2026
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  EXERCICIO EXTRA: VETOR - SOMA E FILTRO                                      :::::
            // :::::                                                                              :::::
            // :::::  Dado um vetor de números inteiros, faça o seguinte;                         :::::
            // :::::                                                                              :::::
            // :::::  1.Calcule a soma de todos os elementos                                      :::::
            // :::::  2.criar um sub vetor apenas com os valores maiores que 40                   :::::
            // :::::  3.Se não existir nenhum valor maior que 40, mostre uma mensagem indicativa  :::::
            // :::::                                                                              :::::
            // :::::  Dados de Teste:                                                             :::::
            // :::::                                                                              :::::
            // :::::  int[] valores = { 12, 12, 34, 45, 67, 100, 62, 27 }                         :::::
            // :::::                                                                              :::::
            // :::::  4.Mostrar:                                                                  :::::
            // :::::  - quais os elementos do vetor são maiores ou menores que 40;                :::::
            // :::::  - a soma dos valores do vetor                                               :::::         
            // :::::  - os elementos do sub - vetor                                               :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            int soma = 0;
            List<int> MaiorQue40 = [];
            List<int> MenorQue40 = [];
            int contador = 0;

            // ::::::::::::::::::::::::::::
            // :::::  Dados de Teste  :::::
            // ::::::::::::::::::::::::::::

            int[] valores = [12, 12, 34, 45, 67, 100, 62, 27];

            // ::::::::::::::::::::::::::::::::::::::::
            // :::::  Soma de todos os elementos  :::::
            // ::::::::::::::::::::::::::::::::::::::::

            for (int i = 0; i < valores.Length; i++)
            {
                soma += valores[i];

                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
                // :::::  Cria sub-vetor para guardar elementos maiores e menores que 40  :::::
                // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

                if (valores[i] > 40)
                {
                    MaiorQue40.Add(valores[i]);
                    contador++;
                }
                else
                {
                    MenorQue40.Add(valores[i]);
                }
            }

            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // :::::  Mostra a soma dos valores do vetor                         :::::
            // :::::  Quais os elementos do vetor são maiores ou menores que 40  :::::
            // :::::  os elementos do sub - vetor                                :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            Console.WriteLine($"A soma de todos os valores é de {soma}");
            Console.WriteLine($"Os elementos maiores que 40 são: {(MaiorQue40.Count > 0 ? string.Join(", ", MaiorQue40) : "Nenhum")}");
            Console.WriteLine($"Os elementos menores ou iguais a 40 são: {(MenorQue40.Count > 0 ? string.Join(", ", MenorQue40) : "Nenhum")}");

            if (contador > 0)
            {
                Console.WriteLine($"Os elementos do sub-vetor (maiores que 40) são: {string.Join(", ", MaiorQue40)}");
            }
            else
            {
                Console.WriteLine("Não existe nenhum número maior que 40");
            }
        }
    }
}
