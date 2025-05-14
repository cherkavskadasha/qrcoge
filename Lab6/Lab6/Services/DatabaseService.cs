using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Lab6.Services
{
    public class DatabaseService
    {
        private const string ConnectionString = "Data Source=qr_codes.db;Version=3;";

        public void InitializeDatabase()
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string createTableQuery = @"CREATE TABLE IF NOT EXISTS QRCodes (
                    Id INTEGER PRIMARY KEY AUTOINCREMENT,
                    Content TEXT,
                    FilePath TEXT,
                    CreatedAt TEXT
                );";
                var command = new SQLiteCommand(createTableQuery, connection);
                command.ExecuteNonQuery();
            }
        }

        public void SaveQRCode(string content, string filePath)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string insertQuery = "INSERT INTO QRCodes (Content, FilePath, CreatedAt) VALUES (@content, @filePath, @createdAt);";
                var command = new SQLiteCommand(insertQuery, connection);
                command.Parameters.AddWithValue("@content", content);
                command.Parameters.AddWithValue("@filePath", filePath);
                command.Parameters.AddWithValue("@createdAt", DateTime.Now);
                command.ExecuteNonQuery();
            }
        }
    }
}
