using System.Diagnostics.Metrics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_Ficha_1_Exercicio_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Implementar uma classe em C# que represente um funcionário de uma empresa,         :::::
            // ::::: aplicando os conceitos básicos de programação orientada a objetos.                 :::::
            // ::::: Requisitos                                                                         :::::
            // :::::  Criar uma classe chamada Funcionario.                                            :::::
            // :::::  A classe deve possuir 3 atributos privados:                                      :::::
            // :::::  nome(do tipo string)                                                             :::::
            // :::::  salario(do tipo double)                                                          :::::
            // :::::  cargo(do tipo string)                                                            :::::
            // :::::  Criar um construtor que permita inicializar os três atributos no momento da      :::::
            // ::::: criação do objeto.                                                                 :::::
            // :::::       Criar métodos públicos para:                                                :::::
            // :::::       Obter o nome do funcionário(public string GetNome()).                       :::::
            // :::::       Obter o salário do funcionário(public double GetSalario()).                 :::::
            // :::::       Obter o cargo do funcionário(public string GetCargo()).                     :::::
            // :::::       Criar um método público que apresente os dados do funcionário(por exemplo,  :::::
            // :::::      public void MostrarDados()), mostrando nome, cargo e salário.                 :::::
            // :::::       Demonstrar o funcionamento da classe num programa principal (Main), criando :::::
            // :::::      um objeto funcionario com valores de exemplo e invocando os métodos para      :::::
            // :::::      apresentar os resultados.                                                     :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // ::::: Demonstração no programa principal :::::
            // Criar o objeto com valores de exemplo
            Funcionario func = new Funcionario("Ana Silva", 2500.50, "Desenvolvedora");

            // Perguntar pela password
            Console.WriteLine("Insira a password:");
            string passwordInserida = Console.ReadLine();

            func.MostrarDados(passwordInserida);
        }
    }
}
