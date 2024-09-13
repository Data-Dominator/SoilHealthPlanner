using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;


namespace CropGuardian.SoilMetrics.Services
{
    public class SoilAnalysisService
    {
        private readonly ICropNutrientSufficiencyProvider _cropProvider;
        private readonly ISoilDataService _soilDataService;

        public SoilAnalysisService(ICropNutrientSufficiencyProvider cropProvider, ISoilDataService soilDataService)
        {
            _cropProvider = cropProvider;
            _soilDataService = soilDataService;
        }

        // Analyze the soil and provide detailed recommendations
        public List<string> AnalyzeSoil(string cropName, string growthStage)
        {
            try
            {
                // Get crop nutrient sufficiency data
                var cropData = _cropProvider.GetCropNutrientSufficiency(cropName, growthStage);
                if (cropData == null)
                {
                    throw new ArgumentNullException(nameof(cropData), "Crop nutrient sufficiency data is missing.");
                }

                // Get soil data from the data service (IoT or simulated)
                var soilData = _soilDataService.GetSoilData();
                if (soilData == null)
                {
                    throw new ArgumentNullException(nameof(soilData), "Soil nutrient data is missing.");
                }

                // Perform the analysis
                return AnalyzeSoilData(soilData, cropData);
            }
            catch (Exception ex)
            {
                throw new SoilAnalysisException("Error occurred during soil analysis.", ex);
            }
        }

        // Analyze soil data and return detailed recommendations
        private List<string> AnalyzeSoilData(SoilNutrientData soilData, CropNutrientSufficiency cropData)
        {
            var recommendations = new List<string>();

            // Example fertilizers for different nutrients
            var nitrogenFertilizers = new List<Fertilizer>
            {
                new Fertilizer("Urea", NutrientType.Nitrogen, 46.0f),  // 46% Nitrogen
                new Fertilizer("Ammonium Nitrate", NutrientType.Nitrogen, 33.5f)  // 33.5% Nitrogen
            };

            var phosphorusFertilizers = new List<Fertilizer>
            {
                new Fertilizer("Superphosphate", NutrientType.Phosphorus, 20.0f), // 20% Phosphorus
                new Fertilizer("Triple Superphosphate", NutrientType.Phosphorus, 45.0f) // 45% Phosphorus
            };

            // Analyze macronutrients
            CheckAndRecommend(cropData.NitrogenRange, soilData.NPercentage, "Nitrogen (N)", recommendations, nitrogenFertilizers);
            CheckAndRecommend(cropData.PhosphorusRange, soilData.PPercentage, "Phosphorus (P)", recommendations, phosphorusFertilizers);

            // Add more CheckAndRecommend calls for other nutrients (e.g., Potassium, Calcium, etc.)

            // Analyze soil moisture
            AnalyzeSoilMoisture(soilData.SoilMoisturePercentage, recommendations);

            return recommendations;
        }

        // Check nutrient levels and make recommendations on how much fertilizer to apply
        private void CheckAndRecommend(NutrientRange range, float actualValue, string nutrientName, List<string> recommendations, List<Fertilizer> fertilizers)
        {
            if (actualValue < range.Min)
            {
                var deficiency = range.Min - actualValue;

                // Choose the best fertilizer based on the nutrient content
                var bestFertilizer = ChooseBestFertilizer(fertilizers);

                // Calculate how much fertilizer to apply
                var amountToApply = CalculateFertilizerAmount(deficiency, bestFertilizer);
                recommendations.Add($"{nutrientName} is low. Apply {amountToApply:F2} kg/ha of {bestFertilizer.Name}.");
            }
            else if (actualValue > range.Max)
            {
                recommendations.Add($"{nutrientName} is high. Avoid applying more {nutrientName}.");
            }
            else
            {
                recommendations.Add($"{nutrientName} is within the optimal range.");
            }
        }

        // Choose the best fertilizer based on nutrient content
        private Fertilizer ChooseBestFertilizer(List<Fertilizer> fertilizers)
        {
            // Select the fertilizer with the highest nutrient content (simple strategy)
            Fertilizer bestFertilizer = null;
            float highestContent = 0;

            foreach (var fertilizer in fertilizers)
            {
                if (fertilizer.NutrientContent > highestContent)
                {
                    highestContent = fertilizer.NutrientContent;
                    bestFertilizer = fertilizer;
                }
            }

            return bestFertilizer;
        }

        // Calculate the amount of fertilizer to apply
        private float CalculateFertilizerAmount(float deficiency, Fertilizer fertilizer)
        {
            // Calculate the required fertilizer based on nutrient content
            return deficiency / (fertilizer.NutrientContent / 100);
        }

        // Analyze soil moisture and provide moisture-specific recommendations
        private void AnalyzeSoilMoisture(float soilMoisturePercentage, List<string> recommendations)
        {
            const float optimalMoistureMin = 20.0f;  // Optimal moisture range minimum
            const float optimalMoistureMax = 60.0f;  // Optimal moisture range maximum

            if (soilMoisturePercentage < optimalMoistureMin)
            {
                recommendations.Add($"Soil moisture is too low ({soilMoisturePercentage}%). Consider irrigating to improve nutrient uptake.");
            }
            else if (soilMoisturePercentage > optimalMoistureMax)
            {
                recommendations.Add($"Soil moisture is too high ({soilMoisturePercentage}%). Ensure proper drainage to avoid waterlogging.");
            }
            else
            {
                recommendations.Add($"Soil moisture is within the optimal range ({soilMoisturePercentage}%).");
            }
        }
    }

    // Custom exception for soil analysis errors
    public class SoilAnalysisException : Exception
    {
        public SoilAnalysisException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}

    /// <summary>
    /// Custom exception to handle errors in soil analysis.
    /// </summary>
    public class SoilAnalysisException : Exception
    {
        public SoilAnalysisException(string message, Exception innerException)
            : base(message, innerException) { }
    }

