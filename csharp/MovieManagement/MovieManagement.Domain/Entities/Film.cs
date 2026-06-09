namespace MovieManagement.Domain.Entities
{
    public class Film
    {
        public int Id { get; set; }

        public string Title { get; set; } = string.Empty;

        public int Year { get; set; }

        public string Language { get; set; } = string.Empty;

        // Rating between 0 and 5
        public int Rating { get; set; }

        // Foreign keys for relationships
        public int DirectorId { get; set; }

        public int CategoryId { get; set; }

        public Film()
        {
        }

        public Film(int id, string title, int year, string language, int rating, int directorId, int categoryId)
        {
            Id         = id;
            Title      = title;
            Year       = year;
            Language   = language;
            Rating     = rating;
            DirectorId = directorId;
            CategoryId = categoryId;
        }

        public Film(string title, int year, string language, int rating, int directorId, int categoryId)
        {
            Title      = title;
            Year       = year;
            Language   = language;
            Rating     = rating;
            DirectorId = directorId;
            CategoryId = categoryId;
        }
    }
}