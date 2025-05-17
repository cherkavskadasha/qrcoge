using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace Lab6.Services
{
    public class DatabaseService
    {
        private const string Conn = "Data Source=qr_codes.db;Version=3;";

        public void InitializeDatabase()
        {
            using (var c = new SQLiteConnection(Conn))
            {
                c.Open();
                const string sql =
                    @"CREATE TABLE IF NOT EXISTS QRCodes(
                          Id        INTEGER PRIMARY KEY,
                          Content   TEXT,
                          FilePath  TEXT,
                          CreatedAt TEXT
                      );";
                new SQLiteCommand(sql, c).ExecuteNonQuery();
            }
        }

        public void SaveQRCode(string content, string path)
        {
            using (var c = new SQLiteConnection(Conn))
            {
                c.Open();
                var cmd = new SQLiteCommand(
                    "INSERT INTO QRCodes(Content,FilePath,CreatedAt) VALUES(@c,@p,@t);", c);
                cmd.Parameters.AddWithValue("@c", content);
                cmd.Parameters.AddWithValue("@p", path);
                cmd.Parameters.AddWithValue("@t", DateTime.Now.ToString("s"));
                cmd.ExecuteNonQuery();
            }
        }

        public List<string> GetAllQRCodes()
        {
            var list = new List<string>();
            using (var c = new SQLiteConnection(Conn))
            {
                c.Open();
                var cmd = new SQLiteCommand("SELECT Content,CreatedAt FROM QRCodes;", c);
                using (var r = cmd.ExecuteReader())
                    while (r.Read())
                        list.Add(string.Format("{0} — {1}", r["CreatedAt"], r["Content"]));
            }
            return list;
        }

        public void ClearAllQRCodes()
        {
            using (var c = new SQLiteConnection(Conn))
            {
                c.Open();
                new SQLiteCommand("DELETE FROM QRCodes;", c).ExecuteNonQuery();
            }
        }
    }
}
