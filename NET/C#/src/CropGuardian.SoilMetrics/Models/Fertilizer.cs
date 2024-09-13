using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Models
{
    public enum NutrientType
    {
        Nitrogen,
        Phosphorus,
        Potassium,
        Calcium,
        Magnesium,
        Sulfur,
        Iron,
        Manganese,
        Copper,
        Zinc,
        Boron
    }

    // Represents a fertilizer and its nutrient content for a specific nutrient
    public class Fertilizer
    {
        public string Name { get; set; }
        public NutrientType Nutrient { get; set; } // Type of nutrient the fertilizer provides
        public float NutrientContent { get; set; } // Percentage of nutrient in the fertilizer

        public Fertilizer(string name, NutrientType nutrient, float nutrientContent)
        {
            Name = name;
            Nutrient = nutrient;
            NutrientContent = nutrientContent;
        }
    }
}
