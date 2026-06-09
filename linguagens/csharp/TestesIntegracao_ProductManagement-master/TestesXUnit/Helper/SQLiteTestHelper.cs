using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Text;

namespace TestesXUnit.Helper
{
    public class SQLiteTestHelper
    {
        // Criação de uma base de dados
        // limpa in-memory (não cria ficheiro)
        // com tabela já pronta a usar

        public static SqliteConnection CreateInMemoryDataBase()
        {
            var connection = new SqliteConnection("DataSource=:memory:");
            connection.Open();
            // Criar a tabela
            var cmd = connection.CreateCommand();
            cmd.CommandText = @"CREATE TABLE Produtos (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nome TEXT NOT NULL,
                                Preco REAL NOT NULL);";
            cmd.ExecuteNonQuery();
            return connection;
            // Este return devolve a ligação aberta e com a tabela criada, pronta a ser usada nos testes
        }
    }
}
