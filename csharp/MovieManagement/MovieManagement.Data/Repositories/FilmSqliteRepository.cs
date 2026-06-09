using Microsoft.Data.Sqlite;
using MovieManagement.Domain.Interfaces;
using MovieManagement.Domain.Entities;

namespace MovieManagement.Data.Repositories
{
    public class FilmSqliteRepository : IFilmRepository
    {
        private readonly string _conectionString = "Data Source=films.db";

        // create table if missing
        public FilmSqliteRepository()
        {
            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = """
                CREATE TABLE IF NOT EXISTS Films (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Title TEXT UNIQUE NOT NULL,
                    Year INTEGER NOT NULL,
                    Language TEXT NOT NULL,
                    Rating INTEGER NOT NULL,
                    DirectorId INTEGER NOT NULL,
                    CategoryId INTEGER NOT NULL,
                    FOREIGN KEY (DirectorId) REFERENCES Directors(Id),
                    FOREIGN KEY (CategoryId) REFERENCES Categories(Id)
                )
                """;
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();

            // Create Directors table
            sql = """
                CREATE TABLE IF NOT EXISTS Directors (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE NOT NULL,
                    Country TEXT NOT NULL
                )
                """;
            command.CommandText = sql;
            command.ExecuteNonQuery();

            // Create Categories table
            sql = """
                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE NOT NULL
                )
                """;
            command.CommandText = sql;
            command.ExecuteNonQuery();
        }

        public void Add(Film film)
        {
            ArgumentNullException.ThrowIfNull(film);

            // Validate foreign keys
            if (film.DirectorId <= 0)
                throw new ArgumentException("DirectorId must be greater than 0", nameof(film));

            if (film.CategoryId <= 0)
                throw new ArgumentException("CategoryId must be greater than 0", nameof(film));

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "INSERT INTO Films (Title, Year, Language, Rating, DirectorId, CategoryId) VALUES (@title, @year, @language, @rating, @directorId, @categoryId)";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@title", film.Title);
            command.Parameters.AddWithValue("@year", film.Year);
            command.Parameters.AddWithValue("@language", film.Language);
            command.Parameters.AddWithValue("@rating", film.Rating);
            command.Parameters.AddWithValue("@directorId", film.DirectorId);
            command.Parameters.AddWithValue("@categoryId", film.CategoryId);
            command.ExecuteNonQuery();

            // get last inserted id
            command.CommandText = "SELECT last_insert_rowid()";
            film.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public List<Film> GetAll()
        {
            var list = new List<Film>();

            using (var connection = new SqliteConnection(_conectionString))
            {
                connection.Open();
                using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
                pragmaCommand.ExecuteNonQuery();

                string sql = "SELECT Id, Title, Year, Language, Rating, DirectorId, CategoryId FROM Films";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Film(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetInt32(2),
                        reader.GetString(3),
                        reader.GetInt32(4),
                        reader.GetInt32(5),
                        reader.GetInt32(6)
                    ));
                }
            }

            return list;
        }

        public Film? GetByTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title)) return null;

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "SELECT Id, Title, Year, Language, Rating, DirectorId, CategoryId FROM Films WHERE Title = @title LIMIT 1";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@title", title);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Film(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetInt32(2),
                    reader.GetString(3),
                    reader.GetInt32(4),
                    reader.GetInt32(5),
                    reader.GetInt32(6)
                );
            }

            return null;
        }

        public bool Remove(int id)
        {
            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "DELETE FROM Films WHERE Id = @id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
