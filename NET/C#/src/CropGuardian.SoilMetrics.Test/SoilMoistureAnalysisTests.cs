using Xunit;
using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;
using CropGuardian.SoilMetrics.Services;

namespace CropGuardian.SoilMetrics.Test
{
    public class SoilMoistureAnalysisTests
    {
        [Fact]
        public void TestAnalyzeSoil_LowMoisture_ShouldRecommendIrrigation()
        {
            // Simulate low soil moisture (15%) using the overloaded constructor
            var soilData = new SoilNutrientData(15.0f);
            var mockSoilDataService = new MockSoilDataService(soilData);
            var cropProvider = new StaticCropProvider(); // Not relevant for moisture test

            var analysisService = new SoilAnalysisService(cropProvider, mockSoilDataService);
            var recommendations = analysisService.AnalyzeSoil("Corn", "Tasselling");

            // Assert recommendations for low soil moisture
            Assert.Contains(recommendations, r => r.Contains("Soil moisture is too low"));
            Assert.Contains(recommendations, r => r.Contains("Consider irrigating to improve nutrient uptake."));
        }

        [Fact]
        public void TestAnalyzeSoil_HighMoisture_ShouldRecommendDrainage()
        {
            // Simulate high soil moisture (70%) using the overloaded constructor
            var soilData = new SoilNutrientData(70.0f);
            var mockSoilDataService = new MockSoilDataService(soilData);
            var cropProvider = new StaticCropProvider(); // Not relevant for moisture test

            var analysisService = new SoilAnalysisService(cropProvider, mockSoilDataService);
            var recommendations = analysisService.AnalyzeSoil("Corn", "Tasselling");

            // Assert recommendations for high soil moisture
            Assert.Contains(recommendations, r => r.Contains("Soil moisture is too high"));
            Assert.Contains(recommendations, r => r.Contains("Ensure proper drainage to avoid waterlogging.")); 
        }

        [Fact]
        public void TestAnalyzeSoil_OptimalMoisture_ShouldConfirmMoistureIsOptimal()
        {
            // Simulate optimal soil moisture (40%) using the overloaded constructor
            var soilData = new SoilNutrientData(40.0f);
            var mockSoilDataService = new MockSoilDataService(soilData);
            var cropProvider = new StaticCropProvider(); // Not relevant for moisture test

            var analysisService = new SoilAnalysisService(cropProvider, mockSoilDataService);
            var recommendations = analysisService.AnalyzeSoil("Corn", "Tasselling");

            // Assert that moisture is optimal
            Assert.Contains(recommendations, r => r.Contains("Soil moisture is within the optimal range"));           
        }
    }
       
}

