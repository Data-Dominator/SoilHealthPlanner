namespace SoilHealth.Services

open SoilHealth.Models

/// Service to analyze soil nutrient data compared to crop nutrient sufficiency levels.
type SoilAnalysisService() =
    
    /// Checks if a nutrient value is outside the specified range (min, max) for macronutrients.
    let checkRange (minVal: float, maxVal: float) (actual: float) =
        if actual < minVal then Some("low")
        elif actual > maxVal then Some("high")
        else None

    /// Analyze the soil data and return a list of deficiencies with recommendations.
    member this.AnalyzeSoil (soilData: SoilNutrientData, cropData: CropNutrientSufficiency) =
        let recommendations = ResizeArray<string>()

        // Check macronutrient levels
        checkRange cropData.NPercentage soilData.NPercentage |> Option.iter (fun status -> recommendations.Add($"Nitrogen (N) is {status}."))
        checkRange cropData.PPercentage soilData.PPercentage |> Option.iter (fun status -> recommendations.Add($"Phosphorus (P) is {status}."))
        checkRange cropData.KPercentage soilData.KPercentage |> Option.iter (fun status -> recommendations.Add($"Potassium (K) is {status}."))
        checkRange cropData.CaPercentage soilData.CaPercentage |> Option.iter (fun status -> recommendations.Add($"Calcium (Ca) is {status}."))
        checkRange cropData.MgPercentage soilData.MgPercentage |> Option.iter (fun status -> recommendations.Add($"Magnesium (Mg) is {status}."))
        checkRange cropData.SPercentage soilData.SPercentage |> Option.iter (fun status -> recommendations.Add($"Sulfur (S) is {status}."))

        // Check micronutrient levels (using floats now)
        checkRange cropData.FePPM soilData.FePPM |> Option.iter (fun status -> recommendations.Add($"Iron (Fe) is {status}."))
        checkRange cropData.MnPPM soilData.MnPPM |> Option.iter (fun status -> recommendations.Add($"Manganese (Mn) is {status}."))
        checkRange cropData.CuPPM soilData.CuPPM |> Option.iter (fun status -> recommendations.Add($"Copper (Cu) is {status}."))
        checkRange cropData.ZnPPM soilData.ZnPPM |> Option.iter (fun status -> recommendations.Add($"Zinc (Zn) is {status}."))
        checkRange cropData.BPPM soilData.BPPM |> Option.iter (fun status -> recommendations.Add($"Boron (B) is {status}."))

        // Return the list of recommendations as an array
        recommendations |> List.ofSeq
