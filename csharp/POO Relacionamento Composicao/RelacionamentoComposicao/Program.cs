namespace RelacionamentoComposicao
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Criar o funcionario
            Funcionario f1 = new Funcionario("Carlos");

            //Adicionar dependentes (cridos dentro da classe funcionario)
            f1.AdicionarDependente("Ana", 10);
            f1.AdicionarDependente("Pedro", 8);

            //Listar dependentes
            f1.ListarDependentes();

        }
    }
}
