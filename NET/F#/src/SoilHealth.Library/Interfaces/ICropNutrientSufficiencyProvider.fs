namespace SoilHealth.Interfaces

open SoilHealth.Models

type ICropNutrientSufficiencyProvider =
    abstract member GetCropNutrientSufficiency: cropName: string * growthStage: string -> CropNutrientSufficiency option



