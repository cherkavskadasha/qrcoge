using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;

namespace Lab6.Services
{
    public class DatabaseService
    {
        private static string GetDatabasePath()
        {
            string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string dbPath = Path.Combine(baseDirectory, "qr_codes.db");

            Console.WriteLine($"Database path: {dbPath}");

            return dbPath;
        }

        private static string ConnectionString => $"Data Source={GetDatabasePath()};Version=3;";

        public void InitializeDatabase()
        {
            try
            {
                string dbPath = GetDatabasePath();
                if (!File.Exists(dbPath))
                {
                    SQLiteConnection.CreateFile(dbPath);
                    Console.WriteLine("Database file created!");
                }

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
                    Console.WriteLine("Table created or already exists!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error initializing database: {ex.Message}");
            }
        }

        public void SaveQRCode(string content, string filePath)
        {
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string insertQuery = "INSERT INTO QRCodes (Content, FilePath, CreatedAt) VALUES (@content, @filePath, @createdAt);";
                    var command = new SQLiteCommand(insertQuery, connection);
                    command.Parameters.AddWithValue("@content", content);
                    command.Parameters.AddWithValue("@filePath", filePath);
                    command.Parameters.AddWithValue("@createdAt", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
                    command.ExecuteNonQuery();
                    Console.WriteLine("QR code saved to database!");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error saving QR code to database: {ex.Message}");
            }
        }

        public List<string> GetAllQRCodes()
        {
            var qrCodes = new List<string>();
            try
            {
                using (var connection = new SQLiteConnection(ConnectionString))
                {
                    connection.Open();
                    string selectQuery = "SELECT * FROM QRCodes;";
                    var command = new SQLiteCommand(selectQuery, connection);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string content = reader["Content"].ToString();
                            string filePath = reader["FilePath"].ToString();
                            string createdAt = reader["CreatedAt"].ToString();
                            qrCodes.Add($"Content: {content}, File: {filePath}, Created: {createdAt}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error retrieving QR codes: {ex.Message}");
            }
            return qrCodes;
        }
    }
}
