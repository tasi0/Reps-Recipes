using System.ComponentModel.DataAnnotations;

namespace Reps_Recipes.Models
{
    public class Diet
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }

        [Required, StringLength(100)]
        public string Aim { get; set; }

        [Required]
        public string MealPlan { get; set; } // JSON или String формат за храненията

        public ICollection<CatalogDiets> CatalogDiets { get; set; } = new List<CatalogDiets>();
    }
}
