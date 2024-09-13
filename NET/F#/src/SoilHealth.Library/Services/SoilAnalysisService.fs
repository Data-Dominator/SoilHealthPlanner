namespace SoilHealth.Services

open System
open System.Collections.Generic
open SoilHealth.Models
open SoilHealth.Interfaces

// Exception for soil analysis errors
type SoilAnalysisException(message: string, innerException: Exception) =
    inherit Exception(message, innerException)

// Fertilizer record
type Fertilizer = {
    Name: string
    NutrientType: NutrientType
    NutrientContent: float
}

// Soil Analysis Service
type SoilAnalysisService(cropProvider: ICropNutrientSufficiencyProvider, soilDataService: ISoilDataService) =

    // Analyze soil and return recommendations
    member this.AnalyzeSoil(cropName: string, growthStage: string): string list =
        try
            // Get crop nutrient sufficiency data
            let cropDataOption = cropProvider.GetCropNutrientSufficiency(cropName, growthStage)
            match cropDataOption with
            | None -> raise (ArgumentException("Crop nutrient sufficiency data is missing."))
            | Some cropData ->
            
            // Get soil data
            let soilDataOption = soilDataService.GetSoilData()
            match soilDataOption with
            | None -> raise (ArgumentException("Soil nutrient data is missing."))
            | Some soilData ->

            // Perform the analysis and return recommendations
            this.AnalyzeSoilData(soilData, cropData)
        with
        | ex -> raise (SoilAnalysisException("Error occurred during soil analysis.", ex))

    // Analyze soil data and provide recommendations
    member private this.AnalyzeSoilData(soilData: SoilNutrientData, cropData: CropNutrientSufficiency): string list =
        let recommendations = ResizeArray<string>()

        // Define fertilizers
        let nitrogenFertilizers = [
            { Name = "Urea"; NutrientType = NutrientType.Nitrogen; NutrientContent = 46.0 }
            { Name = "Ammonium Nitrate"; NutrientType = NutrientType.Nitrogen; NutrientContent = 33.5 }
        ]

        let phosphorusFertilizers = [
            { Name = "Superphosphate"; NutrientType = NutrientType.Phosphorus; NutrientContent = 20.0 }
            { Name = "Triple Superphosphate"; NutrientType = NutrientType.Phosphorus; NutrientContent = 45.0 }
        ]

        // Analyze macronutrients
        this.CheckAndRecommend(cropData.NitrogenRange, soilData.NPercentage, "Nitrogen (N)", recommendations, nitrogenFertilizers)
        this.CheckAndRecommend(cropData.PhosphorusRange, soilData.PPercentage, "Phosphorus (P)", recommendations, phosphorusFertilizers)

        // Add more CheckAndRecommend calls for other nutrients (e.g., Potassium, Calcium, etc.)

        // Analyze soil moisture
        this.AnalyzeSoilMoisture(soilData.SoilMoisturePercentage, recommendations)

        
        let result = Seq.toList recommendations
        result

    // Check nutrient levels and make recommendations on how much fertilizer to apply
    member private this.CheckAndRecommend(nutrientRange: NutrientRange, actualValue: float, nutrientName: string, recommendations: ResizeArray<string>, fertilizers: Fertilizer list) =
        if actualValue < fst nutrientRange then
            let deficiency = fst nutrientRange - actualValue
            let bestFertilizer = this.ChooseBestFertilizer(fertilizers)
            let amountToApply = this.CalculateFertilizerAmount(deficiency, bestFertilizer)
            recommendations.Add($"{nutrientName} is low. Apply {amountToApply:F2} kg/ha of {bestFertilizer.Name}.")
        elif actualValue > snd nutrientRange then
            recommendations.Add($"{nutrientName} is high. Avoid applying more {nutrientName}.")
        else
            recommendations.Add($"{nutrientName} is within the optimal range.")

    // Choose the best fertilizer based on nutrient content
    member private this.ChooseBestFertilizer(fertilizers: Fertilizer list) =
        fertilizers |> List.maxBy (fun f -> f.NutrientContent)

    // Calculate how much fertilizer to apply based on deficiency
    member private this.CalculateFertilizerAmount(deficiency: float, fertilizer: Fertilizer): float =
        deficiency / (fertilizer.NutrientContent / 100.0)

    // Analyze soil moisture and provide moisture-specific recommendations
    member private this.AnalyzeSoilMoisture(soilMoisturePercentage: float, recommendations: ResizeArray<string>) =
        let optimalMoistureMin = 20.0
        let optimalMoistureMax = 60.0

        if soilMoisturePercentage < optimalMoistureMin then
            recommendations.Add($$"""Soil moisture is too low {{soilMoisturePercentage:F2}}%. Consider irrigating to improve nutrient uptake.""")
        elif soilMoisturePercentage > optimalMoistureMax then
            recommendations.Add($$"""Soil moisture is too high {{soilMoisturePercentage:F2}}%. Ensure proper drainage to avoid waterlogging.""")
        else
            recommendations.Add($$"""Soil moisture is within the optimal range {{soilMoisturePercentage:F2}}%.""")
