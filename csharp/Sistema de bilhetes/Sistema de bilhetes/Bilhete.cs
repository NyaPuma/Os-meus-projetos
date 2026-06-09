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
    internal class Bilhete(decimal valor)
    {
        public decimal Valor { get; set; } = valor;

        public virtual void MostrarValor()
        {
            Console.WriteLine($"O valor do bilhete é: {Valor:F2}");
        }
    }
}
