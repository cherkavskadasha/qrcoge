using System;
using System.Collections.Generic;
using System.IO;

namespace Lab6.Services
{
    public class ExportService
    {
        public void ExportToCSV(string filePath, List<string> data)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter(filePath))
                {
                    foreach (var line in data)
                    {
                        sw.WriteLine(line);
                    }
                }
                Console.WriteLine("Data exported successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error exporting to CSV: {ex.Message}");
            }
        }
    }
}
