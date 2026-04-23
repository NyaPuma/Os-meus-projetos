using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Exercicio_4._1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Cria um programa que calcule quantos dias faltam para o final do ano atual. O programa deve: :::::
            // :::::    • Obter a data atual(DateTime.Now)                                                        :::::
            // :::::    • Criar um DateTime com o dia 31 / 12 do mesmo ano                                        :::::
            // :::::    • Subtrair as duas datas                                                                  :::::
            // :::::    • Mostrar quantos dias faltam                                                             :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            DateTime DataAtual = DateTime.Today;
            Console.WriteLine($"Data atual é {DataAtual:d}");

            DateTime FinalAno = new(DataAtual.Year, 12, 31);

            TimeSpan Diferenca = FinalAno - DataAtual;
            Console.WriteLine($"Ainda faltam {Diferenca.Days} dias para o final do ano");
        }
    }
}
