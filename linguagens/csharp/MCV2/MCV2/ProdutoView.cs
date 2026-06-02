namespace MCV2
{
    public class ProdutoView
    {
        public static void ExibirDetalhesProduto(string nome, double preco, int stock)
        {
            Console.WriteLine("\n=== DETALHES DO PRODUTO ===");
            Console.WriteLine($"Nome:  {nome}");
            Console.WriteLine($"Preço: {preco:C2}"); // Formata como moeda local
            Console.WriteLine($"Stock: {stock} unidades");
            Console.WriteLine("===========================\n");
        }

        public static void ExibirMensagemErro(string mensagem)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"[ERRO]: {mensagem}");
            Console.ResetColor();
        }
    }
}