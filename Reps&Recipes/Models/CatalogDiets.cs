namespace Reps_Recipes.Models
{
    public class CatalogDiets
    {
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }

        public int DietId { get; set; }
        public Diet Diet { get; set; }
    }
}
