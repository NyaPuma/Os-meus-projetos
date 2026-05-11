namespace POO_Funcionario_abstracto
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Funcionario f = new(); // -> Não é possivel criar objetos de classes abstratas

            Funcionario f1 = new Socio("Manuel", 42, 100, 5);
            Funcionario f2 = new Programador("Ana", 28, 1500);
            Funcionario f3 = new Comercial("Pedro", 35, 1200, 3000, 5);
        }
    }
}
