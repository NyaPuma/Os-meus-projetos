using Microsoft.Data.Sqlite;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class DirectorSqliteRepository : IDirectorRepository
    {
        private readonly string _connectionString = "Data Source=films.db";

        // Create table if missing
        public DirectorSqliteRepository()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = """
                CREATE TABLE IF NOT EXISTS Directors (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE NOT NULL,
                    Country TEXT NOT NULL
                )
                """;
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public void Add(Director director)
        {
            ArgumentNullException.ThrowIfNull(director);

            var name = director.Name?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(director));

            var country = director.Country?.Trim();
            if (string.IsNullOrWhiteSpace(country))
                throw new ArgumentException("Country is required", nameof(director));

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "INSERT INTO Directors (Name, Country) VALUES (@name, @country)";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name!);
            command.Parameters.AddWithValue("@country", country!);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19) // UNIQUE constraint failed
            {
                throw new InvalidOperationException("Director name already exists", ex);
            }

            // Get last inserted id
            command.CommandText = "SELECT last_insert_rowid()";
            director.Id = Convert.ToInt32(command.ExecuteScalar());
            director.Name = name!;
            director.Country = country!;
        }

        public List<Director> GetAll()
        {
            var list = new List<Director>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
                pragmaCommand.ExecuteNonQuery();

                string sql = "SELECT Id, Name, Country FROM Directors";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Director(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        reader.GetString(2)
                    ));
                }
            }

            return list;
        }

        public Director? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            name = name.Trim();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "SELECT Id, Name, Country FROM Directors WHERE Name = @name COLLATE NOCASE LIMIT 1";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Director(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    reader.GetString(2)
                );
            }

            return null;
        }

        public bool Remove(int id)
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "DELETE FROM Directors WHERE Id = @id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
