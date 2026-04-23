namespace DateTimeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {   
            // ::::::::::::::::::::::::::
            // ::::: Criar DateTime :::::
            // ::::::::::::::::::::::::::

            DateTime agora = DateTime.Now;
            Console.WriteLine("data de agora: " + agora);

            DateTime diahoje = DateTime.Today; // Dia de hoje
            Console.WriteLine("Dia de hoje: " + diahoje);

            DateTime dataEspecifica = new DateTime(1978, 1, 18);
            Console.WriteLine("Dia de aniversário: " + dataEspecifica);

            // ::::: Quero aceder a partes da data :::::

            Console.WriteLine(agora.Year);  //Ano
            Console.WriteLine(agora.Month); //Mes
            Console.WriteLine(agora.Day);   //Dia
            Console.WriteLine(agora.Hour);  //Hora
            Console.WriteLine(agora.Minute);//Minutos

            // ::::: Alterar a repressentação de string to data :::::

            Console.WriteLine(agora.ToString("dd-MM-yyyy"));

            // ::::: Pedir ao utilizador que insira uma data :::::

            Console.WriteLine("Insira uma data");
            DateTime data1 = DateTime.Parse(Console.ReadLine());

            // ::::: O correto seria fazer um TryParse, porque o Parse só vai funcionar
            // ::::: se o utilizador colocar uma data com formato esperado

            Console.WriteLine("Insira uma data");
            string input = Console.ReadLine();

            DateTime data2;

            if (DateTime.TryParse(input, out data2))
            {
                Console.WriteLine("Data inserida: " + data2);
            }
            else
            {
                Console.WriteLine("Formato inválido");
            }

            // ::::: Dia da semana :::::

            Console.WriteLine($"dia da semana {dataEspecifica.DayOfWeek}");

            // ::::: Adicionar 4 dias à data agora :::::

            Console.WriteLine($"4 dias adicionados a agora: {agora.AddDays(4)}");

            // ::::: Adicionar 4 dias e meio à data agora :::::

            Console.WriteLine($"4 dias e meio adicionados a agora: {agora.AddDays(4.5)}");

            // ::::: Quero saber o dia da semana daqui a 5 dias :::::

            Console.WriteLine($"Dia de semana daqui a 5 dias {agora.AddDays(5).DayOfWeek}");

            // ::::::::::::::::::::
            // ::::: Timespan :::::
            // ::::::::::::::::::::

            TimeSpan intervalo1 = TimeSpan.FromHours(5);
            Console.WriteLine("Intervalo: " + intervalo1);

            // ::::: A diferença entre valores inteiros e totais :::::

            TimeSpan intervalo2 = new TimeSpan(2, 21, 03);

            Console.WriteLine($"diferença total inteira {intervalo2.Hours}"); // 2
            Console.WriteLine($"diferença total: {intervalo2.TotalHours}");   // 2....

            // ::::: subtrai datas :::::

            TimeSpan diferenca = DateTime.Now - new DateTime(2025, 1, 1);
            Console.WriteLine($"Diferença de datas {diferenca}");

            // ::::: comparação e conversão :::::

            // ::::: comparar 2 datas :::::

            int resultado = DateTime.Compare(DateTime.Now, dataEspecifica);
            Console.WriteLine($"Resultado da comparação é {resultado}");

            // ::::: se resultado = 1 a 1ª data é > que a 2ª
            // ::::: se resultado = 0 as datas são iguais
            // ::::: se resultado = -1 a 1ª data é < que a 2ª

            bool iguais = DateTime.Now.Date.Equals(dataEspecifica);
            Console.WriteLine($"igualdade: {iguais}");
        }
    }
}
