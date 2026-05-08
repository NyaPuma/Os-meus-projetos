namespace ExemploHeranca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<Funcionario> listaFuncionario = [];

            Funcionario f1 = new("Luis", 45, "Barcelos");

            // Polimorfismo de referencia
            // Do lado esquerdo o compilador vê sócio como Funcionário
            // Do lado direito new() é o objeto real do tipo sócio
            // ou seja, é um Funcionário especilizado (é um)
            Funcionario socio1 = new Socio("Manuel", 35, "Vila Verde", 100);

            Socio socio2 = new("Carolina", 38, "Braga", 200);
            Funcionario tarefeiro = new Outsourcing("Sara", 23, "Braga", 20);

            // Adicionar á lista
            listaFuncionario.Add(f1);
            listaFuncionario.Add(socio1);
            listaFuncionario.Add(socio2);
            listaFuncionario.Add(tarefeiro);

            foreach (Funcionario f in listaFuncionario) 
            { 
                f.ExibirInformacoes();
            }
        }
    }
}
