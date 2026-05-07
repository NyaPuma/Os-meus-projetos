namespace Explicação_Enum
{
    enum DiasDaSemana{
        Segunda,
        Terça,
        Quarta,
        Quinta,
        Sexta,
        Sábado,
        Domingo
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar uma variavel do tipo DiasDaSemana
            DiasDaSemana hoje = DiasDaSemana.Quarta;
            Console.WriteLine(hoje);

            // Conversão explicita (cast) de um inteiro para um tipo DiasDaSemana
            DiasDaSemana d = (DiasDaSemana)4;
            Console.WriteLine(d);

            // --- Departamento --- //
            Departamento departamento = Departamento.recursoshumanos;

            // Criar objeto funcionario
            Funcionarios func1 = new("Sara", Departamento.contabilidade);
            Funcionarios func2 = new("Maria", (Departamento)3);

            Console.WriteLine($"{func1.Nome}, {func1.departamento}");
            Console.WriteLine($"{func2.Nome}, {func2.departamento}");
        }
    }
}
