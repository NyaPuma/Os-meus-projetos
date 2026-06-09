namespace Sistema_de_bilhetes
{
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Exercício 2 - Sistema Bilhetes                                                                 ::::: //
    // :::::     Crie uma classe chamada Bilhete que possua um valor em euros e um método ImprimeValor().  ::::: //
    // :::::     Crie uma classe VIP, que herda de Bilhete e possui um valor adicional.                    ::::: //
    // :::::     Crie um método que retorne o valor do bilhete VIP, com o adicional incluído.              ::::: //
    // :::::     Crie uma classe Normal, que herda de Bilhete e possui um método que imprime:              ::::: //
    // :::::     "Bilhete Normal".                                                                         ::::: //
    // :::::     Crie uma classe CamaroteInferior que herda de VIP que possui a localização do             ::::: //
    // :::::    bilhete e métodos para aceder e imprimir essa localização, e uma classe                     ::::: //
    // :::::    CamaroteSuperior que herda de VIP, que é mais cara, possui valor adicional e                ::::: //
    // :::::    um método para retornar o valor do bilhete.                                                 ::::: //
    // :::::                                                                                                ::::: //
    // ::::: Exemplos de teste                                                                              ::::: //
    // ::::: Considere os seguintes valores para testar o programa:                                         ::::: //
    // :::::     Bilhete com valor de 10,00 €                                                              ::::: //
    // :::::     Bilhete VIP com valor de 10,00 € e valor adicional de 5,00 €                              ::::: //
    // :::::     Bilhete Normal com valor de 10,00 €                                                       ::::: //
    // :::::     Camarote Inferior com valor de 10,00 €, valor adicional de 5,00 € e localização "Setor A" ::::: //
    // :::::     Camarote Superior com valor de 10,00 €, valor adicional de 5,00 € e valor extra de 8,00 € ::::: //
    // :::::                                                                                                ::::: //
    // ::::: Resultados esperados                                                                           ::::: //
    // :::::     O Bilhete deve apresentar 10,00 €                                                         ::::: //
    // :::::     O Bilhete VIP deve apresentar 15,00 €                                                     ::::: //
    // :::::     O Bilhete Normal deve imprimir a mensagem "Bilhete Normal" e o valor 10,00 €              ::::: //
    // :::::     O Camarote Inferior deve apresentar 15,00 € e a localização "Setor A"                     ::::: //
    // :::::     O Camarote Superior deve apresentar 23,00 €                                               ::::: //
    // :::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("--- TESTES DE BILHETES ---");

            // 1. Bilhete Simples
            Bilhete b1 = new(10.00m);
            Console.Write("Bilhete: ");
            b1.MostrarValor();

            // 2. Bilhete VIP
            VIP v1 = new(10.00m, 5.00m);
            Console.Write("Bilhete VIP: ");
            v1.MostrarValor();

            // 3. Bilhete Normal
            Normal n1 = new(10.00m);
            n1.MostrarValor();

            // 4. Camarote Inferior
            CamaroteInferior ci = new(10.00m, 5.00m, "Setor A");
            Console.Write("Camarote Inferior: ");
            ci.MostrarValor();

            // 5. Camarote Superior
            CamaroteSuperior cs = new(10.00m, 5.00m, 8.00m);
            Console.Write("Camarote Superior: ");
            cs.MostrarValor();

            Console.WriteLine("\n--------------------------");
            Console.ReadKey();
        }
    }
}
