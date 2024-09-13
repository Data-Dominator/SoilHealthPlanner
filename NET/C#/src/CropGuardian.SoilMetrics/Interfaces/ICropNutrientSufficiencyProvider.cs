using CropGuardian.SoilMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Interfaces
{
    /// <summary>
    /// Interface to provide nutrient sufficiency data for crops.
    /// Developers can implement this to pull data from various sources (databases, APIs, etc.).
    /// </summary>
    public interface ICropNutrientSufficiencyProvider
    {
        /// <summary>
        /// Gets the nutrient sufficiency data for a specific crop and growth stage.
        /// </summary>
        /// <param name="cropName">Name of the crop (e.g., Corn, Soybeans).</param>
        /// <param name="growthStage">Growth stage of the crop (e.g., Tasselling, Flowering).</param>
        /// <returns>Returns the nutrient sufficiency data for the crop.</returns>
        CropNutrientSufficiency GetCropNutrientSufficiency(string cropName, string growthStage);
    }
}
