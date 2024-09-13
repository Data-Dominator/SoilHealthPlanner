using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;
using CropGuardian.SoilMetrics.Services;

namespace CropGuardian.SoilMetrics.Test
{

    public class SoilAnalysisTests
    {
        private readonly SoilAnalysisService _soilAnalysisService;
        private readonly CropNutrientSufficiency _cropData;

        public SoilAnalysisTests()
        {
            // Predefined crop data for testing (Corn at Tasselling stage)
            _cropData = new CropNutrientSufficiency(
                "Corn", "Tasselling",
                new NutrientRange(2.5f, 3.5f),  // Nitrogen range
                new NutrientRange(0.2f, 0.5f),  // Phosphorus range
                new NutrientRange(1.5f, 2.5f),  // Potassium range
                new NutrientRange(0.4f, 1.0f),  // Calcium range
                new NutrientRange(0.2f, 0.4f),  // Magnesium range
                new NutrientRange(0.2f, 0.3f),  // Sulfur range
                new NutrientRange(20.0f, 100.0f), // Iron range
                new NutrientRange(50.0f, 150.0f), // Manganese range
                new NutrientRange(5.0f, 10.0f),   // Copper range
                new NutrientRange(20.0f, 50.0f),  // Zinc range
                new NutrientRange(30.0f, 50.0f)   // Boron range
            );

            // Full mock soil data
            var soilData = new SoilNutrientData(2.0f, 0.3f, 1.5f, 0.5f, 0.3f, 0.2f, 80.0f, 60.0f, 8.0f, 25.0f, 20.0f, 35.0f);
            var mockSoilDataService = new MockSoilDataService(soilData);

            _soilAnalysisService = new SoilAnalysisService(new StaticCropProvider(), mockSoilDataService);
        }

        [Fact]
        public void TestAnalyzeSoil_ShouldProvideCorrectNutrientRecommendations()
        {
            var recommendations = _soilAnalysisService.AnalyzeSoil("Corn", "Tasselling");

            // Assert nutrient-specific recommendations
            Assert.Contains(recommendations, r => r.Contains("Nitrogen (N) is low."));
            Assert.Contains(recommendations, r => r.Contains("Apply")); // Check for fertilizer application advice
        }
    }

    // Mock provider for crop data (returns real crop data)
    public class StaticCropProvider : ICropNutrientSufficiencyProvider
    {
        public CropNutrientSufficiency GetCropNutrientSufficiency(string cropName, string growthStage)
        {
            // Return mock crop nutrient sufficiency data for testing
            return new CropNutrientSufficiency(
                "Corn", "Tasselling",
                new NutrientRange(2.5f, 3.5f),  // Nitrogen range
                new NutrientRange(0.2f, 0.5f),  // Phosphorus range
                new NutrientRange(1.5f, 2.5f),  // Potassium range
                new NutrientRange(0.4f, 1.0f),  // Calcium range
                new NutrientRange(0.2f, 0.4f),  // Magnesium range
                new NutrientRange(0.2f, 0.3f),  // Sulfur range
                new NutrientRange(20.0f, 100.0f), // Iron range
                new NutrientRange(50.0f, 150.0f), // Manganese range
                new NutrientRange(5.0f, 10.0f),   // Copper range
                new NutrientRange(20.0f, 50.0f),  // Zinc range
                new NutrientRange(30.0f, 50.0f)   // Boron range
            );
        }
    }
}