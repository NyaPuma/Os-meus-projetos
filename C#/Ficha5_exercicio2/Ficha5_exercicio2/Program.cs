namespace Ficha5_exercicio2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Cria um programa em C# que trabalhe com um ficheiro de texto chamado BragaCultura2030.txt, já      :::::
            // ::::: existente na pasta do projeto.                                                                     :::::
            // ::::: O programa deve:                                                                                   :::::
            // :::::     • Verificar se o ficheiro existe.                                                              :::::
            // :::::     • Se existir, ler o seu conteúdo.                                                              :::::
            // :::::     • Imprimir o conteúdo na consola.                                                              :::::
            // :::::     • Se não existir, apresentar uma mensagem a informar que o ficheiro não foi encontrado.        :::::
            // :::::     • Acrescente a linha “BragaCultura 2030” no fim do ficheiro outra linha com a data do sistema. :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string caminho = "C:\\Users\\Cesae\\Downloads\\C#\\Ficha5_exercicio2\\Ficha5_exercicio2\\bin\\Debug\\net10.0\\BragaCultura2030.txt";
            DateTime agora = DateTime.Now;

            if (File.Exists(caminho))
            {
                File.AppendAllLines(caminho, new string[]
                {
                    "\nBragaCultura 2030",
                    agora.ToString("dd-MM-yyyy HH:mm:ss")
                });

                string conteudo = File.ReadAllText(caminho);

                Console.WriteLine(conteudo);
            }

            else
            {
                Console.WriteLine("Ficheiro não encontrado");
            }
        }
    }
}
