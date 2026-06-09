namespace Explicação_Enum
{
    internal class Funcionarios(string nome, Departamento dep)
    {
        public string Nome { get; set; } = nome;
        public Departamento departamento { get; set; } = dep;
    }
}
