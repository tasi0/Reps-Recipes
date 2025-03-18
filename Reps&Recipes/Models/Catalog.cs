using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Reps_Recipes.Models
{
    public class Catalog
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(100)]
        public string Name { get; set; }

        [ForeignKey("ApplicationUser")]
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }

        public ICollection<CatalogDiets> CatalogDiets { get; set; } = new List<CatalogDiets>();
        public ICollection<CatalogRegimes> CatalogRegimes { get; set; } = new List<CatalogRegimes>();
    }
}
