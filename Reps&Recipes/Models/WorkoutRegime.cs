using System.ComponentModel.DataAnnotations;

namespace Reps_Recipes.Models
{
    public class WorkoutRegime
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, StringLength(50)]
        public string Difficulty { get; set; }

        [Range(10, 300)]
        public int DurationMinutes { get; set; } // Продължителност в минути

        [Required]
        public string? ImageURL { get; set; }

        public ICollection<CatalogRegimes> CatalogRegimes { get; set; } = new List<CatalogRegimes>();
    }
}
