using System;

namespace Lab6.Models
{
    public class QRCodeRecord
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public string FilePath { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
