namespace exercicio_extra_20_04
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::: Pedir uma idade ao utilizador e verificar se é maior de idade :::::

            try
            {
                Console.WriteLine("Insira um valor para idade:");
                int idade = int.Parse(Console.ReadLine());
                VerificarIdade(idade);
                Console.WriteLine("Idade Válida");
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }
        }

        static void VerificarIdade(int idade)
        {
            if (idade < 18)
            {
                throw new Exception("Não tem autorização para utilizar este programa");
            }
        }
        
    }
}
