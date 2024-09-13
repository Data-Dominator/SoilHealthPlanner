
namespace CropGuardian.SoilMetrics.Models
{
    // Represents a range of float values (min, max)
    public class NutrientRange
    {
        public float Min { get; set; }
        public float Max { get; set; }

        public NutrientRange(float min, float max)
        {
            Min = min;
            Max = max;
        }
    }
}
