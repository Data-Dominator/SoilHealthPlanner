namespace SoilHealth.Services

open SoilHealth.Models
open System

/// Service to generate simulated soil nutrient data.
type SimulatedDataService() =
    
    let random = Random()

    /// Generate a random float within a range (min, max).
    let randomFloat (minVal: float) (maxVal: float) =
        minVal + (random.NextDouble() * (maxVal - minVal))
    
    /// Helper function to extract nutrient ranges and generate random values.
    let generateNutrientData (cropData: CropNutrientSufficiency) adjustRange =
        let minN, maxN = adjustRange cropData.NPercentage
        let minP, maxP = adjustRange cropData.PPercentage
        let minK, maxK = adjustRange cropData.KPercentage
        let minCa, maxCa = adjustRange cropData.CaPercentage
        let minMg, maxMg = adjustRange cropData.MgPercentage
        let minS, maxS = adjustRange cropData.SPercentage
        let minFe, maxFe = adjustRange cropData.FePPM
        let minMn, maxMn = adjustRange cropData.MnPPM
        let minCu, maxCu = adjustRange cropData.CuPPM
        let minZn, maxZn = adjustRange cropData.ZnPPM
        let minB, maxB = adjustRange cropData.BPPM

        {
            NPercentage = randomFloat minN maxN
            PPercentage = randomFloat minP maxP
            KPercentage = randomFloat minK maxK
            CaPercentage = randomFloat minCa maxCa
            MgPercentage = randomFloat minMg maxMg
            SPercentage = randomFloat minS maxS
            FePPM = randomFloat minFe maxFe  
            MnPPM = randomFloat minMn maxMn  
            CuPPM = randomFloat minCu maxCu  
            ZnPPM = randomFloat minZn maxZn  
            BPPM = randomFloat minB maxB     
        }
    
    /// Adjust range function for out of range generation.
    let outOfRangeAdjust (minVal: float, maxVal: float) = 
        (minVal - 1.0, maxVal + 1.0)
    
    /// Generate random soil nutrient data for testing purposes.
    member this.GenerateRandomSoilData (cropData: CropNutrientSufficiency) =
        generateNutrientData cropData id

    

    /// Generate random soil data, potentially outside the sufficiency range (for testing edge cases).
    member this.GenerateRandomSoilDataOutOfRange (cropData: CropNutrientSufficiency) =
        generateNutrientData cropData outOfRangeAdjust