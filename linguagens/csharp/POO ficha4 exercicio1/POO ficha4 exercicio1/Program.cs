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
    internal class Program
    {
        static void Main(string[] args)
        {
            // Criar a lista de imóveis (Polimorfismo em ação)
            List<Imovel> listaImoveis =
            [
                // Adicionar os exemplos solicitados
                new ImovelNovo("Rua das Flores, 10", 150000, 20000),
                new ImovelVelho("Avenida Central, 25", 120000, 15000),
            ];

            // Percorrer a lista e mostrando as informações
            foreach (var imovel in listaImoveis)
            {
                imovel.MostrarInformacoes();
            }
        }
    }
}
