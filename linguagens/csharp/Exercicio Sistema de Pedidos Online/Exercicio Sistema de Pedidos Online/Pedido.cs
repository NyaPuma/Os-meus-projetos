using System;
using System.Collections.Generic;
using System.Globalization;
using System.Net.NetworkInformation;
using System.Text;

namespace Exercicio_Sistema_de_Pedidos_Online
{
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    // ::::: Desenvolva um sistema de pedidos online para uma empresa em C# que permita aos clientes inserir informações pessoais,         ::::: //
    // ::::: fazer pedidos e visualizar o resumo de seus pedidos.                                                                          ::::: //
    // :::::                                                                                                                               ::::: //
    // ::::: Diagrama de classes:                                                                                                          ::::: //
    // :::::    - Cliente representa os clientes do sistema e contém informações como nome, email e data de nascimento.                    ::::: //
    // :::::    - Produto representa os produtos disponíveis para compra e contém informações como nome e preço.                           ::::: //
    // :::::    - ItemPedido representa os itens individuais num pedido e contém informações como quantidade e preço unitário.             ::::: //
    // :::::    - Pedido representa um pedido feito por um cliente e contém informações como a data e hora do pedido, o status do pedido e ::::: //
    // :::::    uma lista de itens do pedido.                                                                                              ::::: //
    // :::::    - StatusPedido é uma classe do tipo enumeração que define os possíveis estados de um pedido, como "Pagamento Pendente",    ::::: //
    // :::::    "A processar", "Enviado" e "Entregue".                                                                                     ::::: //
    // :::::                                                                                                                               ::::: //
    // ::::: As relações entre as classes são mostradas através de associações. Por exemplo, um cliente pode fazer vários pedidos, então   ::::: //
    // ::::: há uma associação de 1 para muitos entre Cliente e Pedido. Similarmente, um pedido pode conter vários itens, então há uma     ::::: //
    // ::::: associação de 1 para muitos entre Pedido e ItemPedido.                                                                        ::::: //
    // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
    ///////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////

    // Classe principal que gerencia o pedido, cliente e a lista de itens.
    internal class Pedido(DateTime moment, StatusPedido status, Cliente cliente)
    {
        public DateTime Moment { get; set; } = moment;
        public StatusPedido Status { get; set; } = status;
        public Cliente Cliente { get; set; } = cliente;
        public List<ItemPedido> Items { get; set; } = [];

        public void AdicionarItem(ItemPedido item) => Items.Add(item);
        public void RemoverItem(ItemPedido item) => Items.Remove(item);

        // Soma o SubTotal de todos os itens da lista.
        public double Total()
        {
            double soma = 0;
            foreach (ItemPedido item in Items) soma += item.SubTotal();
            return soma;
        }

        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine("-------------------------------------------");
            sb.AppendLine("          RESUMO DO PEDIDO");
            sb.AppendLine("-------------------------------------------");
            sb.AppendLine($"Instante:   {Moment:dd/MM/yyyy HH:mm:ss}");
            sb.AppendLine($"Status:     {Status}");
            sb.AppendLine($"Cliente:    {Cliente.Nome}");
            sb.AppendLine($"Nascimento: {Cliente.DataNascimento:dd/MM/yyyy}");
            sb.AppendLine($"Email:      {Cliente.Email}");
            sb.AppendLine("\nITENS:");

            foreach (ItemPedido item in Items)
            {
                sb.AppendLine($"- {item.Produto.NomeProduto}: ${item.Preco:F2} x {item.Quantidade} (Subtotal: ${item.SubTotal():F2})");
            }

            sb.AppendLine("-------------------------------------------");
            sb.AppendLine($"VALOR TOTAL: ${Total().ToString("F2", CultureInfo.InvariantCulture)}");
            sb.AppendLine("-------------------------------------------");
            return sb.ToString();
        }
    }
}
