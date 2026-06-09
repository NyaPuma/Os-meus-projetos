using System;

namespace POO_Ficha_1_Exercicio_2
{
    internal class Funcionario
    {
        // ::::: Atributos privados :::::
        private string nome;
        private double salario;
        private string cargo;
        // Define a password como um atributo ou uma constante interna
        private const string passwordCorreta = "1234";

        // ::::: 1. Construtor: Inicializa os atributos no momento da criação :::::
        public Funcionario(string nome, double salario, string cargo)
        {
            this.nome = nome;
            this.salario = salario;
            this.cargo = cargo;
        }

        // ::::: 2. Métodos Get :::::
        public string GetNome()
        {  
            return nome; 
        }

        public double GetSalario()
        {
            return salario;
        }

        public string GetCargo()
        {
            return cargo;
        }

        // ::::: 3. Método para apresentar os dados :::::
        // Alteramos este método para aceitar a password
        public void MostrarDados(string passwordInserida)
        {
            if (passwordInserida == passwordCorreta)
            {
                Console.WriteLine("--- Dados do Funcionário ---");
                Console.WriteLine($"Nome:    {nome}");
                Console.WriteLine($"Cargo:   {cargo}");
                Console.WriteLine($"Salário: {salario:C2}");
                Console.WriteLine("----------------------------");
            }
            else
            {
                Console.WriteLine("Acesso Negado: Password incorreta!");
            }
        }
    }
}