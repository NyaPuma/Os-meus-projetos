namespace Movie_Management_Domain.Entities
{
    public class Filme
    {
        public int Id { get; set; }

        public string Titulo { get; set; }

        public decimal Preco { get; set; }

        public Filme()
        {
        }

        public Filme(int id, string titulo, decimal preco)
        {
            Id = id;
            Titulo = titulo;
            Preco = preco;
        }
    }
}
