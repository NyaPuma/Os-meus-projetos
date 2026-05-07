using System;
using System.Collections.Generic;
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

    // Representa um item específico dentro de um pedido, vinculando produto e quantidade.
    internal class ItemPedido(int quantidade, double preco, Produto produto)
    {
        public int Quantidade { get; set; } = quantidade;
        public double Preco { get; set; } = preco;
        public Produto Produto { get; set; } = produto;

        // Calcula o valor total deste item (Preço * Quantidade).
        public double SubTotal() => Quantidade * Preco;
    }
}
