using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Services
{
    public class SimulatedDataService : ISoilDataService
    {
        private readonly Random _random = new Random();
        private readonly CropNutrientSufficiency _cropData;

        public SimulatedDataService(CropNutrientSufficiency cropData)
        {
            _cropData = cropData;
        }

        public SoilNutrientData GetSoilData()
        {
            return GenerateRandomSoilData();
        }

        // Generate random soil data
        public SoilNutrientData GenerateRandomSoilData()
        {
            try
            {
                return new SoilNutrientData(
                    RandomFloat(_cropData.NitrogenRange),
                    RandomFloat(_cropData.PhosphorusRange),
                    RandomFloat(_cropData.PotassiumRange),
                    RandomFloat(_cropData.CalciumRange),
                    RandomFloat(_cropData.MagnesiumRange),
                    RandomFloat(_cropData.SulfurRange),
                    RandomFloat(_cropData.IronRange),
                    RandomFloat(_cropData.ManganeseRange),
                    RandomFloat(_cropData.CopperRange),
                    RandomFloat(_cropData.ZincRange),
                    RandomFloat(_cropData.BoronRange),                 
                    soilMoisturePercentage: (float)(_random.NextDouble() * 100) // Random soil moisture percentage
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException("Error generating simulated soil data.", ex);
            }
        }

        private float RandomFloat(NutrientRange range)
        {
            return (float)(_random.NextDouble() * (range.Max - range.Min) + range.Min);
        }
    }
}
