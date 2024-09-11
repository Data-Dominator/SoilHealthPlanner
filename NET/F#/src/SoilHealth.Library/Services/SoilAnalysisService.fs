namespace SoilHealth.Services

open SoilHealth.Models

/// Service to analyze soil nutrient data compared to crop nutrient sufficiency levels.
type SoilAnalysisService() =

    // Assume implementation of checkRange function
    let checkRange (min: float) (max: float) (value: float) : Option<string> =
        if value < min then Some "deficient"
        elif value > max then Some "excessive"
        else None    

    /// Analyze the soil data and return a list of deficiencies with recommendations.
    member this.AnalyzeSoil (soilData: SoilNutrientData, cropData: CropNutrientSufficiency) : string list =       
        let analyzeNutrient (name: string) (range: float * float) (value: float) =
            checkRange (fst range) (snd range) value
            |> Option.map (fun status -> $"{name} is {status}.")

        let recommendations =
            [ yield analyzeNutrient "Nitrogen (N)" cropData.NitrogenRange soilData.NPercentage
              yield analyzeNutrient "Phosphorus (P)" cropData.PhosphorusRange soilData.PPercentage
              yield analyzeNutrient "Potassium (K)" cropData.PotassiumRange soilData.KPercentage
              yield analyzeNutrient "Calcium (Ca)" cropData.CalciumRange soilData.CaPercentage
              yield analyzeNutrient "Magnesium (Mg)" cropData.MagnesiumRange soilData.MgPercentage
              yield analyzeNutrient "Sulfur (S)" cropData.SulfurRange soilData.SPercentage
              yield analyzeNutrient "Iron (Fe)" cropData.IronRange soilData.FePPM
              yield analyzeNutrient "Manganese (Mn)" cropData.ManganeseRange soilData.MnPPM
              yield analyzeNutrient "Copper (Cu)" cropData.CopperRange soilData.CuPPM
              yield analyzeNutrient "Zinc (Zn)" cropData.ZincRange soilData.ZnPPM
              yield analyzeNutrient "Boron (B)" cropData.BoronRange soilData.BPPM ]
            |> List.choose id

        recommendations
