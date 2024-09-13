
namespace CropGuardian.SoilMetrics.Models
{
    // Represents soil nutrient data for analysis
    public class SoilNutrientData
    {
        public float NPercentage { get; set; } // Nitrogen percentage
        public float PPercentage { get; set; } // Phosphorus percentage
        public float KPercentage { get; set; } // Potassium percentage
        public float CaPercentage { get; set; } // Calcium percentage
        public float MgPercentage { get; set; } // Magnesium percentage
        public float SPercentage { get; set; } // Sulfur percentage
        public float FePPM { get; set; }       // Iron in parts per million
        public float MnPPM { get; set; }       // Manganese in parts per million
        public float CuPPM { get; set; }       // Copper in parts per million
        public float ZnPPM { get; set; }       // Zinc in parts per million
        public float BPPM { get; set; }        // Boron in parts per million
        public float SoilMoisturePercentage { get; set; }  // Soil moisture as a percentage


        public SoilNutrientData(
            float nPercentage, float pPercentage, float kPercentage,
            float caPercentage, float mgPercentage, float sPercentage,
            float fePPM, float mnPPM, float cuPPM,
            float znPPM, float bPPM, float soilMoisturePercentage)
        {
            NPercentage = nPercentage;
            PPercentage = pPercentage;
            KPercentage = kPercentage;
            CaPercentage = caPercentage;
            MgPercentage = mgPercentage;
            SPercentage = sPercentage;
            FePPM = fePPM;
            MnPPM = mnPPM;
            CuPPM = cuPPM;
            ZnPPM = znPPM;
            BPPM = bPPM;
            SoilMoisturePercentage = soilMoisturePercentage;
        }

        // Overloaded constructor with only soil moisture
        public SoilNutrientData(float soilMoisturePercentage)
        {
            SoilMoisturePercentage = soilMoisturePercentage;
        }
    }
}
