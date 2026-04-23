namespace exceção_exemplo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::: Simular uma operação crítica :::::

            // ::::: Tentativa de dividir um numero por zero :::::

            int numerador = 10;
            int denominador = 0;

            try
            {
                int resultado = numerador / denominador;
                Console.WriteLine($"Resultado: {resultado}");
            }

            catch(DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
            }

            catch(Exception ex)
            {
                Console.WriteLine("ERRO!");
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.GetType());
            }

            finally
            {
                Console.WriteLine("Encerramento do ficheiro");
            }
            
        }
    }
}
