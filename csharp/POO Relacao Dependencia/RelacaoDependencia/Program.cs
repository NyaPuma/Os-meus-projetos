namespace RelacaoDependencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //criação dos objetos funcionario

            Funcionario funcionario1 = new Funcionario("Antonio Lopes", 1345.50);

            Funcionario funcionario2 = new Funcionario("Carlota Pires", 1400.00);

            //Criar o serviço de relatorio

            RelatorioService relatorio1 = new RelatorioService();
            RelatorioService relatorio2 = new RelatorioService();

           


            //Gerar os relatorios

            relatorio1.GerarRelatorio(funcionario1);
            relatorio2.GerarRelatorio(funcionario2);
            
        }
    }
}
