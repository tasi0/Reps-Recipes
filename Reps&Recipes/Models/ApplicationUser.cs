using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace Reps_Recipes.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required, StringLength(50)]
        public string Name { get; set; }

        public ICollection<Catalog> Catalogs { get; set; } = new List<Catalog>();
    }
}
