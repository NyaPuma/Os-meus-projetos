namespace RelacaoAssociacao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //criação do conta

            ContaCorrente conta1 = new ContaCorrente();
            conta1.Agencia = "001";
            conta1.Numero = "12345-6";
            conta1.Saldo = 1000;


            //criação do cliente

            Cliente cliente1 = new Cliente();
            cliente1.Nome = "João";
            cliente1.NIF = "123456789";
            cliente1.Telefone = "987456321";

            //Establecer a associaçao

            conta1.Titular = cliente1;

            Console.WriteLine(cliente1.Nome);
            Console.WriteLine(conta1.Titular.Nome);

            //se se mudar o Nome apartir da conta
            conta1.Titular.Nome = "Maria";

            //a aceder ao conteudo de Nome atraves do cliente

            Console.WriteLine(cliente1.Nome); //resultado = Maria

            //O objeto cliente1 é o mesmo objeto que está associado a conta1
            
        }
    }
}
