using System;
using System.Collections.Generic;
using System.Text;
using Product_Management_Domain.Interfaces;
using Product_Management_Domain.Entities;
using Microsoft.Data.Sqlite;

namespace Product_Management_Data.Repositories
{
    internal class ProdutoSQLiteRepository : IProdutoRepository
    {
        private readonly string _conectionString = "Data Source = produtos.db";

        // criação da tabela
        public ProdutoSQLiteRepository()
        {
            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "CREATE TABLE IF NOT EXISTS Produtos (Id INTEGER PRIMARY KEY AUTOINCREMENT, Nome TEXT, Preco REAL)";
            using var command = new SqliteCommand(sql, connection);
            command.ExecuteNonQuery();
        }

        public void Adicionar(Produto produto)
        {
            ArgumentNullException.ThrowIfNull(produto);

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "INSERT INTO Produtos (Nome, Preco) VALUES (@nome, @preco)";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", produto.Nome);
            command.Parameters.AddWithValue("@preco", produto.Preco);
            command.ExecuteNonQuery();

            // get last inserted id
            command.CommandText = "SELECT last_insert_rowid()";
            produto.Id = Convert.ToInt32(command.ExecuteScalar());
        }

        public List<Produto> ObterTodos()
        {
            var lista = new List<Produto>();

            using (var connection = new SqliteConnection(_conectionString))
            {
                connection.Open();
                string sql = "SELECT Id, Nome, Preco FROM Produtos";
                using var command = new SqliteCommand(sql, connection);
                using var reader = command.ExecuteReader();
                while (reader.Read())
                {
                    lista.Add(new Produto(
                        reader.GetInt32(0),
                        reader.GetString(1),
                        Convert.ToDecimal(reader.GetDouble(2))
                    ));
                }
            }

            return lista;
        }

        public Produto? ObterPorNome(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome)) return null;

            using var connection = new SqliteConnection(_conectionString);
            connection.Open();
            string sql = "SELECT Id, Nome, Preco FROM Produtos WHERE Nome = @nome LIMIT 1";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@nome", nome);
            using var reader = command.ExecuteReader();
            if (reader.Read())
            {
                return new Produto(
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
            string sql = "DELETE FROM Produtos WHERE Id = @id";
            using var command = new SqliteCommand(sql, connection);
            command.Parameters.AddWithValue("@id", id);
            int rows = command.ExecuteNonQuery();
            return rows > 0;
        }
    }
}
