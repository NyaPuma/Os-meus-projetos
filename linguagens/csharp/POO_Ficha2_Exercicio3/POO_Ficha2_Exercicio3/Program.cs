using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Contracts;
using System.Runtime.Intrinsics.X86;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace POO_Ficha2_Exercicio3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ///////////////////////////////////////////////////////////////////////////////////////////////////
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            // ::::: Contexto: O objetivo deste exercício é gerir uma lista de contactos de forma      ::::: //
            // ::::: segura, garantindo que não existem duplicações e permitindo a atualização de      ::::: //
            // ::::: dados de contactos já existentes.                                                 ::::: //
            // :::::                                                                                   ::::: //
            // ::::: 1.Preparação da Classe                                                            ::::: //
            // ::::: Crie uma classe chamada Contacto com as seguintes propriedades autoimplementadas: ::::: //
            // :::::     Nome(do tipo string)                                                         ::::: //
            // :::::     Email(do tipo string)                                                        ::::: //
            // :::::                                                                                   ::::: //
            // ::::: 2.Manipulação da Lista                                                            ::::: //
            // ::::: No método Main, crie uma List < Contacto > e preencha - a com, pelo menos, três   ::::: //
            // ::::: contactos iniciais(ex: "Ana", "Bruno", "Carla").                                  ::::: //
            // :::::                                                                                   ::::: //
            // ::::: 3.Validação de Duplicados                                                         ::::: //
            // ::::: Implemente uma lógica que tente adicionar um novo contacto à lista:               ::::: //
            // :::::     Antes de adicionar, utilize o método Exists() para verificar se já existe    ::::: //
            // :::::    algum contacto com o mesmo Nome.                                               ::::: //
            // :::::     Se o nome já existir, exiba na consola: "Erro: O contacto [nome] já se       ::::: //
            // :::::    encontra na agenda."                                                           ::::: //
            // :::::     Se não existir, adicione o novo objeto à lista.                              ::::: //
            // :::::                                                                                   ::::: //
            // ::::: 4.Pesquisa e Atualização                                                          ::::: //
            // ::::: Implemente uma funcionalidade de edição:                                          ::::: //
            // :::::     Defina uma variável com o nome de um contacto que deseja atualizar.          ::::: // 
            // :::::     Utilize o método Find() para localizar o objeto na lista.                    ::::: //
            // :::::    O que é o Find() ?                                                             ::::: //
            // :::::    Ao contrário de um método que retorna apenas um true ou false,                 ::::: //
            // :::::    o Find() devolve a referência para o objeto real na memória.Por isso,          ::::: //
            // :::::    quando se altera o Email do objeto retornado pelo Find(), está se a            ::::: //
            // :::::    alterar o objeto que está guardado dentro da lista!                            ::::: //
            // :::::     Verificação de segurança: Como o método Find() pode                          ::::: //
            // :::::    retornar null(caso o nome não seja encontrado), verifique se o                 ::::: //
            // :::::    resultado da pesquisa é diferente de null antes de prosseguir.                 ::::: //
            // :::::     Se encontrado, altere o Email desse objeto para um novo valor e              ::::: //
            // :::::    apresente a mensagem: "Contacto [nome] atualizado com sucesso!".               ::::: //
            // :::::                                                                                   ::::: //
            // ::::: 5.Apresentação                                                                    ::::: //
            // ::::: Crie um método simples que percorra a lista(usando um ciclo foreach) e            ::::: //
            // ::::: imprima o Nome e o Email de todos os contactos presentes na agenda após           ::::: //
            // ::::: as operações anteriores.                                                          ::::: //
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::: //
            ///////////////////////////////////////////////////////////////////////////////////////////////////

            List<Contacto> contactos =
            [
                new Contacto("Ana", "Ana@email"),
                new Contacto("Bruno", "Bruno@email"),
                new Contacto("Carla", "Carla@email"),
            ];

            // ::::: 3. Validação de Duplicados ::::: //
            Console.WriteLine("--- Adicionar Novo Contacto ---");
            Console.Write("Digite o nome: ");
            string nomeNovo = Console.ReadLine();

            // ::::: Verifica se o nome já existe na lista ::::: //
            if (contactos.Exists(c => c.Nome.Equals(nomeNovo, StringComparison.OrdinalIgnoreCase)))
            {
                Console.WriteLine($"Erro: O contacto [{nomeNovo}] já se encontra na agenda.");
            }
            else
            {
                Console.Write("Digite o email: ");
                string emailNovo = Console.ReadLine();
                contactos.Add(new Contacto(nomeNovo, emailNovo));
                Console.WriteLine("Contacto adicionado com sucesso!");
            }

            // ::::: 4. Pesquisa e Atualização ::::: //
            Console.WriteLine("\n--- Atualizar Email ---");
            Console.Write("Nome do contacto que deseja atualizar: ");
            string nomeParaEditar = Console.ReadLine();

            // ::::: Find retorna o objeto real da memória ou null ::::: //
            Contacto contactoEncontrado = contactos.Find(c => c.Nome.Equals(nomeParaEditar, StringComparison.OrdinalIgnoreCase));

            if (contactoEncontrado != null)
            {
                Console.Write($"Insira o novo email para {contactoEncontrado.Nome}: ");
                contactoEncontrado.Email = Console.ReadLine();
                Console.WriteLine($"Contacto {contactoEncontrado.Nome} atualizado com sucesso!");
            }
            else
            {
                Console.WriteLine("Erro: Contacto não encontrado.");
            }

            // ::::: 5. Apresentação Final ::::: //
            Console.WriteLine("\n--- Lista de Contactos Atualizada ---");
            Apresentacao(contactos);
        }

        // ::::: Tornamos o método static para ser usado no Main ::::: //
        public static void Apresentacao(List<Contacto> lista)
        {
            foreach (var c in lista)
            {
                Console.WriteLine($"Nome: {c.Nome} | Email: {c.Email}");
            }
        }
    }
}
