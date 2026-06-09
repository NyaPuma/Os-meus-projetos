using System;
using System.Collections.Generic;
using System.Text;
using Movie_Management_Domain.Interfaces;
using Movie_Management_Domain.Entities;
using Microsoft.Data.Sqlite;

namespace Movie_Management_Data.Repositories
{
    public class FilmeSQLiteRepository : IFilmeRepository
    {
        private readonly string _conectionString = "Data Source = filmes.db";

        // criação da tabela
        public FilmeSQLiteRepository()
        {
            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "CREATE TABLE IF NOT EXISTS Filmes (Id INTEGER PRIMARY KEY AUTOINCREMENT, Titulo TEXT, Preco REAL)";
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public void Adicionar(Filme filme)
        {
            ArgumentNullException.ThrowIfNull(filme);

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "INSERT INTO Filmes (Titulo, Preco) VALUES (@titulo, @preco)";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@titulo", filme.Titulo);
            command.Parameters.AddWithValue("@preco", filme.Preco);
            command.ExecuteNonQuery();

            // get last inserted id
            command.CommandText = "SELECT last_insert_rowid()";
            filme.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public List<Filme> ObterTodos()
        {
            var lista = new List<Filme>();

            using (var connection = new SqliteConnection(_conectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Titulo, Preco FROM Filmes";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Filme(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        Convert.ToDecimal(reader.GetDouble(2))
                    ));
                }
            }

            return lista;
        }

        public Filme? ObterPorTitulo(string titulo)
        {
            if (string.IsNullOrWhiteSpace(titulo)) return null;

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "SELECT Id, Titulo, Preco FROM Filmes WHERE Titulo = @titulo LIMIT 1";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@titulo", titulo);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Filme(
                    reader.GetInt32(0),
                    reader.GetString(1),
                    Convert.ToDecimal(reader.GetDouble(2))
                );
            }

            return null;
        }

        public bool Remover(int id)
        {
            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "DELETE FROM Filmes WHERE Id = @id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
