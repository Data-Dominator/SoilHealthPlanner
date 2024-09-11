namespace SoilHealth.Services

open SoilHealth.Models
open System

/// Service to generate simulated soil nutrient data.
type SimulatedDataService() =
    
    let random = Random()

    /// Generate a random float within a range (min, max).
    let randomFloat (minVal: float) (maxVal: float) =
        minVal + (random.NextDouble() * (maxVal - minVal))

    /// Validates the input for null values using Option types.
    let validateInput (crop: CropNutrientSufficiency option) =
        match crop with
        | None -> raise (ArgumentNullException("Crop data cannot be null"))
        | Some _ -> ()

    /// Generate random soil nutrient data within the sufficiency ranges.
    member this.GenerateRandomSoilData (crop: CropNutrientSufficiency option) =
        validateInput crop  // Validate input before proceeding

        match crop with
        | Some cropData ->
            {
                NPercentage = randomFloat (fst cropData.NitrogenRange) (snd cropData.NitrogenRange)
                PPercentage = randomFloat (fst cropData.PhosphorusRange) (snd cropData.PhosphorusRange)
                KPercentage = randomFloat (fst cropData.PotassiumRange) (snd cropData.PotassiumRange)
                CaPercentage = randomFloat (fst cropData.CalciumRange) (snd cropData.CalciumRange)
                MgPercentage = randomFloat (fst cropData.MagnesiumRange) (snd cropData.MagnesiumRange)
                SPercentage = randomFloat (fst cropData.SulfurRange) (snd cropData.SulfurRange)
                FePPM = randomFloat (fst cropData.IronRange) (snd cropData.IronRange)
                MnPPM = randomFloat (fst cropData.ManganeseRange) (snd cropData.ManganeseRange)
                CuPPM = randomFloat (fst cropData.CopperRange) (snd cropData.CopperRange)
                ZnPPM = randomFloat (fst cropData.ZincRange) (snd cropData.ZincRange)
                BPPM = randomFloat (fst cropData.BoronRange) (snd cropData.BoronRange)
            }
        | None -> failwith "Invalid crop data"

    /// Generate random soil data outside the sufficiency range (for testing edge cases).
    member this.GenerateRandomSoilDataOutOfRange (crop: CropNutrientSufficiency option) =
        validateInput crop  // Validate input before proceeding

        match crop with
        | Some cropData ->
            {
                NPercentage = randomFloat (fst cropData.NitrogenRange - 1.0) (snd cropData.NitrogenRange + 1.0)
                PPercentage = randomFloat (fst cropData.PhosphorusRange - 0.1) (snd cropData.PhosphorusRange + 0.1)
                KPercentage = randomFloat (fst cropData.PotassiumRange - 0.5) (snd cropData.PotassiumRange + 0.5)
                CaPercentage = randomFloat (fst cropData.CalciumRange - 0.2) (snd cropData.CalciumRange + 0.2)
                MgPercentage = randomFloat (fst cropData.MagnesiumRange - 0.1) (snd cropData.MagnesiumRange + 0.1)
                SPercentage = randomFloat (fst cropData.SulfurRange - 0.1) (snd cropData.SulfurRange + 0.1)
                FePPM = randomFloat (fst cropData.IronRange - 20.0) (snd cropData.IronRange + 20.0)
                MnPPM = randomFloat (fst cropData.ManganeseRange - 10.0) (snd cropData.ManganeseRange + 10.0)
                CuPPM = randomFloat (fst cropData.CopperRange - 2.0) (snd cropData.CopperRange + 2.0)
                ZnPPM = randomFloat (fst cropData.ZincRange - 5.0) (snd cropData.ZincRange + 5.0)
                BPPM = randomFloat (fst cropData.BoronRange - 5.0) (snd cropData.BoronRange + 5.0)
            }
        | None -> failwith "Invalid crop data"
