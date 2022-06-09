using System.ComponentModel.DataAnnotations;

namespace SpectacoleWeb.Models
{
    public class Ticket
    {
        public int Id { get; set; }
        public string? Show { get; set; }

        [RegularExpression(@"[0-9]+")]
        public int Row { get; set; }

        [RegularExpression(@"[0-9]+")]
        public int Column { get; set; }
    }
}
