using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Services
{
    /// <summary>
    /// A predefined crop provider that returns static nutrient sufficiency data.
    /// </summary>
    public class PredefinedCropProvider : ICropNutrientSufficiencyProvider
    {
        /// <summary>
        /// Gets predefined nutrient sufficiency data for the given crop and growth stage.
        /// </summary>
        public CropNutrientSufficiency GetCropNutrientSufficiency(string cropName, string growthStage)
        {
            if (cropName == "Corn" && growthStage == "Tasselling")
            {
                return PredefinedCropData.GetCornTassellingData();
            }
            if (cropName == "Soybeans" && growthStage == "Flowering")
            {
                return PredefinedCropData.GetSoybeansFloweringData();
            }
            if (cropName == "Wheat" && growthStage == "Prior to Filling")
            {
                return PredefinedCropData.GetWheatPriorToFillingData();
            }
            if (cropName == "Alfalfa" && growthStage == "Flowering")
            {
                return PredefinedCropData.GetAlfalfaFloweringData();
            }

            throw new ArgumentException($"No predefined data for crop: {cropName} at growth stage: {growthStage}");
        }
    }
}
