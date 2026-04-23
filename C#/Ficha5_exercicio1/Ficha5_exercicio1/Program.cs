namespace Ficha5_exercicio1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string caminho = "dados.txt";
            string caminho2 = "C:\\Users\\Cesae\\Downloads\\Ficheiros\\Ficheiros\\dados.txt";
            string caminho3 = "C:\\Users\\Cesae\\Downloads\\Ficheiros\\Ficheiros\\dados.txt";

            File.WriteAllText(caminho2, "Primeira frase");

            // ::::::::::::::::::::::::::::::::::::::::
            // ::::: Acrescente 2 linhas de texto :::::
            // ::::::::::::::::::::::::::::::::::::::::

            File.AppendAllLines(caminho2, new string[]
            {
                "\nsegunda linha",
                "terceira linha"
            });

            // ::::::::::::::::::::::::::::::::::::
            // ::::: Ler conteúdo do ficheiro :::::
            // ::::::::::::::::::::::::::::::::::::

            string conteudo = File.ReadAllText(caminho2);
            Console.WriteLine(conteudo);
                
        }
    }
}
