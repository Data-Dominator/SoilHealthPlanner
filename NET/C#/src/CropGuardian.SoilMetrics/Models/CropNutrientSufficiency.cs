using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Models
{
    // Represents nutrient sufficiency for a crop at a specific growth stage
    public class CropNutrientSufficiency
    {
        public string CropName { get; set; }
        public string GrowthStage { get; set; }

        public NutrientRange NitrogenRange { get; set; }
        public NutrientRange PhosphorusRange { get; set; }
        public NutrientRange PotassiumRange { get; set; }
        public NutrientRange CalciumRange { get; set; }
        public NutrientRange MagnesiumRange { get; set; }
        public NutrientRange SulfurRange { get; set; }               
        public NutrientRange IronRange { get; set; }
        public NutrientRange ManganeseRange { get; set; }
        public NutrientRange CopperRange { get; set; }
        public NutrientRange ZincRange { get; set; }
        public NutrientRange BoronRange { get; set; }

        public CropNutrientSufficiency(
            string cropName,
            string growthStage,
            NutrientRange nitrogenRange, NutrientRange phosphorusRange, NutrientRange potassiumRange,
            NutrientRange calciumRange, NutrientRange magnesiumRange, NutrientRange sulfurRange,
            NutrientRange ironRange, NutrientRange manganeseRange, NutrientRange copperRange,
            NutrientRange zincRange, NutrientRange boronRange)
        {
            CropName = cropName;
            GrowthStage = growthStage;
            NitrogenRange = nitrogenRange;
            PhosphorusRange = phosphorusRange;
            PotassiumRange = potassiumRange;
            CalciumRange = calciumRange;
            MagnesiumRange = magnesiumRange;
            SulfurRange = sulfurRange;
            IronRange = ironRange;
            ManganeseRange = manganeseRange;
            CopperRange = copperRange;
            ZincRange = zincRange;
            BoronRange = boronRange;
        }
    }
}
