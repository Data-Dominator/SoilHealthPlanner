using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

/* How These Values Were Chosen:
   * The values were selected based on general guidelines for optimal nutrient levels in these crops, particularly during the key growth stages.
   * The specific values may vary by region, soil type, and other factors, but these serve as a general guideline.
 */

namespace CropGuardian.SoilMetrics.Models
{
    public static class PredefinedCropData
    {
        /// <summary>
        /// Nutrient sufficiency data for Corn at the Tasselling stage.
        /// </summary>
        public static CropNutrientSufficiency GetCornTassellingData()
        {
            return new CropNutrientSufficiency(
                "Corn", "Tasselling",
                new NutrientRange(2.5f, 3.5f),  // Nitrogen (N)
                new NutrientRange(0.2f, 0.5f),  // Phosphorus (P)
                new NutrientRange(1.5f, 2.5f),  // Potassium (K)
                new NutrientRange(0.4f, 1.0f),  // Calcium (Ca)
                new NutrientRange(0.2f, 0.4f),  // Magnesium (Mg)
                new NutrientRange(0.2f, 0.3f),  // Sulfur (S)
                new NutrientRange(20.0f, 100.0f), // Iron (Fe)
                new NutrientRange(50.0f, 150.0f), // Manganese (Mn)
                new NutrientRange(5.0f, 10.0f),  // Copper (Cu)
                new NutrientRange(20.0f, 50.0f), // Zinc (Zn)
                new NutrientRange(30.0f, 50.0f)  // Boron (B)
            );
        }

        /// <summary>
        /// Nutrient sufficiency data for Soybeans at the Flowering stage.
        /// </summary>
        public static CropNutrientSufficiency GetSoybeansFloweringData()
        {
            return new CropNutrientSufficiency(
                "Soybeans", "Flowering",
                new NutrientRange(4.25f, 5.5f), // Nitrogen (N)
                new NutrientRange(0.25f, 0.5f), // Phosphorus (P)
                new NutrientRange(1.7f, 2.5f),  // Potassium (K)
                new NutrientRange(0.3f, 1.0f),  // Calcium (Ca)
                new NutrientRange(0.2f, 0.4f),  // Magnesium (Mg)
                new NutrientRange(0.2f, 0.4f),  // Sulfur (S)
                new NutrientRange(50.0f, 350.0f), // Iron (Fe)
                new NutrientRange(25.0f, 100.0f), // Manganese (Mn)
                new NutrientRange(5.0f, 10.0f),   // Copper (Cu)
                new NutrientRange(30.0f, 50.0f),  // Zinc (Zn)
                new NutrientRange(20.0f, 50.0f)   // Boron (B)
            );
        }

        /// <summary>
        /// Nutrient sufficiency data for Wheat prior to grain filling.
        /// </summary>
        public static CropNutrientSufficiency GetWheatPriorToFillingData()
        {
            return new CropNutrientSufficiency(
                "Wheat", "Prior to Filling",
                new NutrientRange(2.0f, 3.0f),  // Nitrogen (N)
                new NutrientRange(0.26f, 0.5f), // Phosphorus (P)
                new NutrientRange(1.5f, 3.0f),  // Potassium (K)
                new NutrientRange(0.2f, 1.0f),  // Calcium (Ca)
                new NutrientRange(0.12f, 0.4f), // Magnesium (Mg)
                new NutrientRange(0.15f, 0.4f), // Sulfur (S)
                new NutrientRange(20.0f, 250.0f), // Iron (Fe)
                new NutrientRange(15.0f, 100.0f), // Manganese (Mn)
                new NutrientRange(3.0f, 25.0f),   // Copper (Cu)
                new NutrientRange(15.0f, 70.0f),  // Zinc (Zn)
                new NutrientRange(5.0f, 25.0f)    // Boron (B)
            );
        }

        /// <summary>
        /// Nutrient sufficiency data for Alfalfa at the Flowering stage.
        /// </summary>
        public static CropNutrientSufficiency GetAlfalfaFloweringData()
        {
            return new CropNutrientSufficiency(
                "Alfalfa", "Flowering",
                new NutrientRange(2.5f, 5.0f),  // Nitrogen (N)
                new NutrientRange(0.25f, 0.7f), // Phosphorus (P)
                new NutrientRange(2.0f, 3.5f),  // Potassium (K)
                new NutrientRange(0.3f, 1.0f),  // Calcium (Ca)
                new NutrientRange(0.25f, 0.7f), // Magnesium (Mg)
                new NutrientRange(0.25f, 0.5f), // Sulfur (S)
                new NutrientRange(30.0f, 250.0f), // Iron (Fe)
                new NutrientRange(25.0f, 100.0f), // Manganese (Mn)
                new NutrientRange(8.0f, 30.0f),   // Copper (Cu)
                new NutrientRange(25.0f, 70.0f),  // Zinc (Zn)
                new NutrientRange(30.0f, 80.0f)   // Boron (B)
            );
        }
    }

}
