using System.ComponentModel.DataAnnotations;

namespace SpectacoleWeb.Models
{
    public class Show
    {
        public int Id { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string? Title { get; set; }

        [StringLength(100, MinimumLength = 2)]
        [Required]
        public string? Director { get; set; }

        [StringLength(150, MinimumLength = 2)]
        [Required]
        public string? Actors { get; set; }

        [Display(Name = "Release Date")]
        [DataType(DataType.Date)]
        public DateTime DateTime { get; set; }

        [RegularExpression(@"[0-9]+")]
        public int Seats { get; set; }
    }
}
