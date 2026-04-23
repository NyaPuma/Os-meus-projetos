namespace exemplo_ficheiros
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::
            // ::::: Quero que o meu ficheiro se vá chamar teste.txt tenha caminho relativo :::::
            // ::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::::

            string caminho = "teste.txt";

            string conteudo = "Esta é a primeira linha do ficheiro";

            // ::::::::::::::::::::::::::::::::::::::::
            // ::::: Criar um ficheiro e escrever :::::
            // ::::::::::::::::::::::::::::::::::::::::

            //File.WriteAllText(caminho, conteudo);

            // ::::::::::::::::::::::::::::::::::::
            // ::::: Ler conteúdo do ficheiro :::::
            // ::::::::::::::::::::::::::::::::::::

            //string conteudo2 = File.ReadAllText(caminho);
            //Console.WriteLine("Conteúdo do ficheiro teste.txt");
            //Console.WriteLine(conteudo2);

            //File.Delete(caminho);

            // :::::::::::::::::::::::::
            // ::::: Classe Stream :::::
            // :::::::::::::::::::::::::

            using(StreamWriter texto = new StreamWriter(caminho))
            {
                texto.WriteLine("Esta é a primeira frase");
                texto.WriteLine("Bom dia");
            }

            // ::::::::::::::::::::::::
            // ::::: Ler conteúdo :::::
            // ::::::::::::::::::::::::

            using(StreamReader texto_lido = new StreamReader(caminho))
            {
                string linha;
                while((linha = texto_lido.ReadLine()) != null)
                {
                    Console.WriteLine(linha);
                }
            }
        }
    }
}
