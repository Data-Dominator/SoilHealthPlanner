namespace SoilHealth.Services

open System
open SoilHealth.Models

/// Utility functions for generating random values
module RandomUtils =
    let random = Random()

    /// Generates a random float between two given values (inclusive)
    let randomFloat minVal maxVal = 
        minVal + (random.NextDouble() * (maxVal - minVal)) |> float

/// Service for generating simulated soil nutrient data
type SimulatedDataService() =

    /// Generate random soil nutrient data within the sufficiency ranges for a given crop
    member this.GenerateRandomSoilData (crop: CropNutrientSufficiency option) : SoilNutrientData =
        match crop with
        | Some cropData ->
            { NPercentage = RandomUtils.randomFloat (fst cropData.NitrogenRange) (snd cropData.NitrogenRange)
              PPercentage = RandomUtils.randomFloat (fst cropData.PhosphorusRange) (snd cropData.PhosphorusRange)
              KPercentage = RandomUtils.randomFloat (fst cropData.PotassiumRange) (snd cropData.PotassiumRange)
              CaPercentage = RandomUtils.randomFloat (fst cropData.CalciumRange) (snd cropData.CalciumRange)
              MgPercentage = RandomUtils.randomFloat (fst cropData.MagnesiumRange) (snd cropData.MagnesiumRange)
              SPercentage = RandomUtils.randomFloat (fst cropData.SulfurRange) (snd cropData.SulfurRange)
              FePPM = RandomUtils.randomFloat (fst cropData.IronRange) (snd cropData.IronRange)
              MnPPM = RandomUtils.randomFloat (fst cropData.ManganeseRange) (snd cropData.ManganeseRange)
              CuPPM = RandomUtils.randomFloat (fst cropData.CopperRange) (snd cropData.CopperRange)
              ZnPPM = RandomUtils.randomFloat (fst cropData.ZincRange) (snd cropData.ZincRange)
              BPPM = RandomUtils.randomFloat (fst cropData.BoronRange) (snd cropData.BoronRange)
              SoilMoisturePercentage = RandomUtils.randomFloat 20.0 60.0 } // Example range for soil moisture
        | None ->
            raise (ArgumentException("Invalid crop data provided for simulation."))

    /// Generate random soil data without relying on crop nutrient data (purely random simulation)
    member this.GeneratePureRandomSoilData() : SoilNutrientData =
        { NPercentage = RandomUtils.randomFloat 1.0 5.0
          PPercentage = RandomUtils.randomFloat 0.1 1.0
          KPercentage = RandomUtils.randomFloat 0.5 3.0
          CaPercentage = RandomUtils.randomFloat 0.2 1.5
          MgPercentage = RandomUtils.randomFloat 0.1 1.0
          SPercentage = RandomUtils.randomFloat 0.1 0.5
          FePPM = RandomUtils.randomFloat 10.0 100.0
          MnPPM = RandomUtils.randomFloat 20.0 200.0
          CuPPM = RandomUtils.randomFloat 2.0 15.0
          ZnPPM = RandomUtils.randomFloat 5.0 50.0
          BPPM = RandomUtils.randomFloat 10.0 60.0
          SoilMoisturePercentage = RandomUtils.randomFloat 20.0 60.0 }
