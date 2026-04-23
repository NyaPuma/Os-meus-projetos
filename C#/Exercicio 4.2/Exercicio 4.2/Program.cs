using System.Runtime.Intrinsics.X86;

namespace Exercicio_4._2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Uma viagem tem duas etapas:                          :::::
            // :::::     Primeira etapa: 2 horas e 45 minutos            :::::
            // :::::     Segunda etapa: 1 hora e 30 minutos              :::::
            // ::::: Cria um programa que:                                :::::
            // :::::    • Crie dois TimeSpan com estas durações;          :::::
            // :::::    • Some os dois intervalos;                        :::::
            // :::::    • Mostre:                                         :::::
            // :::::        - A duração total no formato padrão(hh:mm:ss) :::::
            // :::::        - O total de horas(TotalHours)                :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            TimeSpan intervalo1 = new(2, 45, 00);
            TimeSpan intervalo2 = new(1, 30, 00);

            TimeSpan Total = intervalo1 + intervalo2;

            Console.WriteLine($"A soma das duas etapas é de {Total} e o total de horas é de {Total.Hours}");
        }
    }
}
