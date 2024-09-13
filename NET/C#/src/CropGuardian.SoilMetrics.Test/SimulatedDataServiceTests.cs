using CropGuardian.SoilMetrics.Models;
using CropGuardian.SoilMetrics.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CropGuardian.SoilMetrics.Test
{
    public class SimulatedDataServiceTests
    {
        private readonly SimulatedDataService _simulatedDataService;

        public SimulatedDataServiceTests()
        {
            // Predefined crop nutrient sufficiency data
            var cropData = new CropNutrientSufficiency(
                "Corn", "Tasselling",
                new NutrientRange(2.5f, 3.5f),  // Nitrogen
                new NutrientRange(0.2f, 0.5f),  // Phosphorus
                new NutrientRange(1.5f, 2.5f),  // Potassium
                new NutrientRange(0.4f, 1.0f),  // Calcium
                new NutrientRange(0.2f, 0.4f),  // Magnesium
                new NutrientRange(0.2f, 0.3f),  // Sulfur
                new NutrientRange(20.0f, 100.0f), // Iron
                new NutrientRange(50.0f, 150.0f), // Manganese
                new NutrientRange(5.0f, 10.0f),  // Copper
                new NutrientRange(20.0f, 50.0f), // Zinc
                new NutrientRange(30.0f, 50.0f)  // Boron
            );

            _simulatedDataService = new SimulatedDataService(cropData);
        }

        [Fact]
        public void TestGenerateRandomSoilData_WithinRange()
        {
            // Generate random soil data
            var soilData = _simulatedDataService.GenerateRandomSoilData();

            // Assert that the generated soil data is within the expected ranges
            Assert.InRange(soilData.NPercentage, 2.5f, 3.5f);
            Assert.InRange(soilData.PPercentage, 0.2f, 0.5f);
            Assert.InRange(soilData.KPercentage, 1.5f, 2.5f);
        }
    }
}
