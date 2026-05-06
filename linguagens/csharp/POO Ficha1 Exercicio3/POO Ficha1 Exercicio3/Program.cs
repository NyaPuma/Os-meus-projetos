namespace POO_Ficha1_Exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Implementar uma classe em C# que represente uma conta bancária, aplicando           :::::
            // ::::: conceitos de programação orientada a objetos, incluindo o uso de variável estática. :::::
            // :::::    Requisitos                                                                       :::::
            // :::::  Criar uma classe chamada ContaBancaria.                                           :::::
            // :::::  A classe deve possuir:                                                            :::::
            // :::::      um atributo privado numero(do tipo int), que identifica a conta;              :::::
            // :::::      um atributo privado saldo(do tipo double), que guarda o saldo da              :::::
            // :::::     conta;                                                                          :::::
            // :::::      uma variável estática privada chamada totalContas(do tipo int), que           :::::
            // :::::     conta quantas contas já foram criadas.                                          :::::
            // :::::  Criar um construtor que:                                                          :::::
            // :::::      permita inicializar o numero e o saldo;                                       :::::
            // :::::      incremente a variável estática totalContas sempre que uma nova                :::::
            // :::::     conta é criada.                                                                 :::::
            // :::::  Criar:                                                                            :::::
            // :::::      métodos públicos para depositar(Depositar(double valor)) e levantar           :::::
            // :::::     (Levantar(double valor));                                                       :::::
            // :::::      um método público MostrarDados() que apresente o número da conta              :::::
            // :::::     e o seu saldo;                                                                  :::::
            // :::::      um método estático TotalContas() que devolva o valor da                       :::::
            // :::::     variável totalContas(sem parâmetros).                                           :::::
            // :::::  Demonstrar o funcionamento da classe num programa principal(Main):                :::::
            // :::::      criar várias contas(ContaBancaria conta1 = ..., conta2 = ...);                :::::
            // :::::      efetuar depósitos e levantamentos nas contas;                                 :::::
            // :::::      no final, invocar o método estático TotalContas() para mostrar quantas        :::::
            // :::::     contas foram criadas.                                                           :::::
            // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            // 1. Criar várias contas com números diferentes para distinguir
            ContaBancaria conta1 = new ContaBancaria(101, 1000.0);
            ContaBancaria conta2 = new ContaBancaria(102, 500.0);
            ContaBancaria conta3 = new ContaBancaria(103, 2000.0);

            // 2. Efetuar operações
            Console.WriteLine("--- Operações em curso ---");
            conta1.Depositar(500.0);
            conta2.Levantar(200.0);
            conta3.Levantar(3000.0); // Teste de saldo insuficiente

            // 3. Mostrar dados individuais
            Console.WriteLine("\n--- Estado das Contas ---");
            conta1.MostrarDados();
            conta2.MostrarDados();
            conta3.MostrarDados();

            // 4. Invocar o método estático
            int total = ContaBancaria.TotalContas();
            Console.WriteLine("\n==============================");
            Console.WriteLine($"Total de contas criadas: {total}");
            Console.WriteLine("==============================");
        }
    }
}
