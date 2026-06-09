namespace POO_ficha4_exercicio1
{
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um programa em C# para representar imóveis.                                      ::::: //
    // ::::: O sistema deve ter uma classe base chamada Imovel, que possui um endereço e um preço.       ::::: //
    // :::::                                                                                             ::::: //
    // ::::: Depois, devem ser criadas as seguintes classes derivadas:                                   ::::: //
    // :::::     Novo, que herda de Imovel e possui um valor adicional no preço.                        ::::: //
    // :::::     Velho, que herda de Imovel e possui um desconto no preço.                              ::::: //
    // :::::                                                                                             ::::: //
    // ::::: Cada classe deve ter métodos para aceder aos seus valores e mostrar as informações no ecrã. ::::: //
    // :::::                                                                                             ::::: //
    // ::::: Valores de teste                                                                            ::::: //
    // ::::: Imóvel Novo                                                                                 ::::: //
    // :::::     Endereço: Rua das Flores, 10                                                           ::::: //
    // :::::     Preço base: 150000 €                                                                   ::::: //
    // :::::     Valor adicional: 20000 €                                                               ::::: //
    // :::::     Preço final esperado: 170000 €                                                         ::::: //
    // ::::: Imóvel Velho                                                                                ::::: //
    // :::::     Endereço: Avenida Central, 25                                                          ::::: //
    // :::::     Preço base: 120000 €                                                                   ::::: //
    // :::::     Desconto: 15000 €                                                                      ::::: //
    // :::::     Preço final esperado: 105000 €                                                         ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    internal class Imovel(string endereco, decimal preco)
    {
        public string Endereco { get; set; } = endereco;
        public decimal Preco { get; set; } = preco;

        // Marcamos como virtual para permitir que as classes filhas o alterem
        public virtual void MostrarInformacoes()
        {
            Console.WriteLine($"Endereço: {Endereco} | Preço Base: {Preco:C}");
        }
    }
}
