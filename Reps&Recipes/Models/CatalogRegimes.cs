namespace Reps_Recipes.Models
{
    public class CatalogRegimes
    {
        public int CatalogId { get; set; }
        public Catalog Catalog { get; set; }

        public int WorkoutRegimeId { get; set; }
        public WorkoutRegime WorkoutRegime { get; set; }
    }
}
