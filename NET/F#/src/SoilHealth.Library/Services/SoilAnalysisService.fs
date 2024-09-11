namespace SoilHealth.Services

open SoilHealth.Models

/// Service to analyze soil nutrient data compared to crop nutrient sufficiency levels.
type SoilAnalysisService() =

    /// Checks if a nutrient value is outside the specified range (min, max) for macronutrients.
    let checkRange (minVal: float, maxVal: float) (actual: float) =
        if actual < minVal then Some("low")
        elif actual > maxVal then Some("high")
        else None

    let checkAndAddRecommendation
        (cropRange: float * float, soilValue: float, nutrientName: string, recommendations: ResizeArray<string>)
        =
        checkRange cropRange soilValue
        |> Option.iter (fun status -> recommendations.Add($"{nutrientName} is {status}."))

    /// Analyze the soil data and return a list of deficiencies with recommendations.
    member this.AnalyzeSoil(soilData: SoilNutrientData, cropData: CropNutrientSufficiency) =
        let recommendations = ResizeArray<string>()

        // Check macronutrient levels
        checkAndAddRecommendation (cropData.NPercentage, soilData.NPercentage, "Nitrogen (N)", recommendations)
        checkAndAddRecommendation (cropData.PPercentage, soilData.PPercentage, "Phosphorus (P)", recommendations)
        checkAndAddRecommendation (cropData.KPercentage, soilData.KPercentage, "Potassium (K)", recommendations)
        checkAndAddRecommendation (cropData.CaPercentage, soilData.CaPercentage, "Calcium (Ca)", recommendations)
        checkAndAddRecommendation (cropData.MgPercentage, soilData.MgPercentage, "Magnesium (Mg)", recommendations)
        checkAndAddRecommendation (cropData.SPercentage, soilData.SPercentage, "Sulfur (S)", recommendations)

        // Check micronutrient levels (using floats now)
        checkAndAddRecommendation (cropData.FePPM, soilData.FePPM, "Iron (Fe)", recommendations)
        checkAndAddRecommendation (cropData.MnPPM, soilData.MnPPM, "Manganese (Mn)", recommendations)
        checkAndAddRecommendation (cropData.CuPPM, soilData.CuPPM, "Copper (Cu)", recommendations)
        checkAndAddRecommendation (cropData.ZnPPM, soilData.ZnPPM, "Zinc (Zn)", recommendations)
        checkAndAddRecommendation (cropData.BPPM, soilData.BPPM, "Boron (B)", recommendations)

        // Return the list of recommendations as an array
        recommendations |> List.ofSeq
