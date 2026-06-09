namespace MovieManagement.Domain.Entities
{
    public class Director
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public Director()
        {
        }

        public Director(int id, string name, string country)
        {
            Id      = id;
            Name    = name;
            Country = country;
        }
    }
}
