using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;


namespace CropGuardian.SoilMetrics.Services
{
    public class MockSoilDataService : ISoilDataService
    {
        private readonly SoilNutrientData _soilData;

        // Constructor that accepts full SoilNutrientData
        public MockSoilDataService(SoilNutrientData soilData)
        {
            _soilData = soilData;
        }

        // Returns the SoilNutrientData
        public SoilNutrientData GetSoilData()
        {
            return _soilData;
        }
    }

}
