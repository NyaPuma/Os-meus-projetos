using Microsoft.Data.Sqlite;
using MovieManagement.Domain.Entities;
using MovieManagement.Domain.Interfaces;

namespace MovieManagement.Data.Repositories
{
    public class CategorySqliteRepository : ICategoryRepository
    {
        private readonly string _connectionString = "Data Source=films.db";

        // Create table if missing
        public CategorySqliteRepository()
        {
            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = """
                CREATE TABLE IF NOT EXISTS Categories (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Name TEXT UNIQUE NOT NULL
                )
                """;
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public void Add(Category category)
        {
            ArgumentNullException.ThrowIfNull(category);

            var name = category.Name?.Trim();
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(category));

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "INSERT INTO Categories (Name) VALUES (@name)";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name!);

            try
            {
                command.ExecuteNonQuery();
            }
            catch (SqliteException ex) when (ex.SqliteErrorCode == 19) // UNIQUE constraint failed
            {
                throw new InvalidOperationException("Category name already exists", ex);
            }

            // Get last inserted id
            command.CommandText = "SELECT last_insert_rowid()";
            category.Id = Convert.ToInt32(command.ExecuteScalar());
            category.Name = name!;
        }

        public List<Category> GetAll()
        {
            var list = new List<Category>();

            using (var connection = new SqliteConnection(_connectionString))
            {
                connection.Open();
                using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
                pragmaCommand.ExecuteNonQuery();

                string sql = "SELECT Id, Name FROM Categories";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    list.Add(new Category(
                        reader.GetInt32(0),
                        reader.GetString(1)
                    ));
                }
            }

            return list;
        }

        public Category? GetByName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required", nameof(name));

            name = name.Trim();

            using var connection = new SqliteConnection(_connectionString);
            connection.Open();
            using var pragmaCommand = new SqliteCommand("PRAGMA foreign_keys = ON", connection);
            pragmaCommand.ExecuteNonQuery();

            string sql = "SELECT Id, Name FROM Categories WHERE Name = @name COLLATE NOCASE LIMIT 1";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@name", name);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Category(
                    reader.GetInt32(0),
                    reader.GetString(1)
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

            string sql = "DELETE FROM Categories WHERE Id = @id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
