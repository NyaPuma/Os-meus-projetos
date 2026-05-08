namespace PropriedadesAutoincrementadas
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::: Construir o objeto ::::: //
            Cliente c1 = new Cliente();

            // ::::: Atribuir valor de nome ::::: //
            c1.Nome = "Sara"; //SET

            // ::::: Atribuir valor de idade ::::: //
            c1.idade = 48; //SET

            // ::::: Ver o valor do atributo do objeto c1 ::::: //
            Console.WriteLine(c1.Nome); //GET

            // ::::: Ver o valor do atributo do objeto c1 ::::: //
            Console.WriteLine(c1.idade); //GET
        }
    }
}
