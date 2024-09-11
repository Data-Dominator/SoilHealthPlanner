namespace SoilHealth.Services

open SoilHealth.Models
open System

/// Service to generate simulated soil nutrient data.
type SimulatedDataService() =
    
    let random = Random()

    /// Generate a random float within a range (min, max).
    let randomFloat (minVal: float) (maxVal: float) =
        minVal + (random.NextDouble() * (maxVal - minVal))

    /// Generate random soil nutrient data for testing purposes.
    member this.GenerateRandomSoilData (cropData: CropNutrientSufficiency) =
        let minN, maxN = cropData.NPercentage
        let minP, maxP = cropData.PPercentage
        let minK, maxK = cropData.KPercentage
        let minCa, maxCa = cropData.CaPercentage
        let minMg, maxMg = cropData.MgPercentage
        let minS, maxS = cropData.SPercentage
        let minFe, maxFe = cropData.FePPM
        let minMn, maxMn = cropData.MnPPM
        let minCu, maxCu = cropData.CuPPM
        let minZn, maxZn = cropData.ZnPPM
        let minB, maxB = cropData.BPPM
        
        {
            NPercentage = randomFloat minN maxN
            PPercentage = randomFloat minP maxP
            KPercentage = randomFloat minK maxK
            CaPercentage = randomFloat minCa maxCa
            MgPercentage = randomFloat minMg maxMg
            SPercentage = randomFloat minS maxS
            FePPM = randomFloat minFe maxFe  // Now using randomFloat for micronutrients
            MnPPM = randomFloat minMn maxMn  // Updated to use float
            CuPPM = randomFloat minCu maxCu  // Updated to use float
            ZnPPM = randomFloat minZn maxZn  // Updated to use float
            BPPM = randomFloat minB maxB     // Updated to use float
        }

    /// Generate random soil data, potentially outside the sufficiency range (for testing edge cases).
    member this.GenerateRandomSoilDataOutOfRange (cropData: CropNutrientSufficiency) =
        let (minN, maxN) = cropData.NPercentage
        let (minP, maxP) = cropData.PPercentage
        let (minK, maxK) = cropData.KPercentage
        let (minCa, maxCa) = cropData.CaPercentage
        let (minMg, maxMg) = cropData.MgPercentage
        let (minS, maxS) = cropData.SPercentage
        let (minFe, maxFe) = cropData.FePPM
        let (minMn, maxMn) = cropData.MnPPM
        let (minCu, maxCu) = cropData.CuPPM
        let (minZn, maxZn) = cropData.ZnPPM
        let (minB, maxB) = cropData.BPPM
        
        {
            NPercentage = randomFloat (minN - 1.0) (maxN + 1.0)
            PPercentage = randomFloat (minP - 0.1) (maxP + 0.1)
            KPercentage = randomFloat (minK - 0.5) (maxK + 0.5)
            CaPercentage = randomFloat (minCa - 0.2) (maxCa + 0.2)
            MgPercentage = randomFloat (minMg - 0.1) (maxMg + 0.1)
            SPercentage = randomFloat (minS - 0.1) (maxS + 0.1)
            FePPM = randomFloat (minFe - 20.0) (maxFe + 20.0)  // Using randomFloat for micronutrients
            MnPPM = randomFloat (minMn - 10.0) (maxMn + 10.0)  // Updated to float
            CuPPM = randomFloat (minCu - 2.0) (maxCu + 2.0)    // Updated to float
            ZnPPM = randomFloat (minZn - 5.0) (maxZn + 5.0)    // Updated to float
            BPPM = randomFloat (minB - 5.0) (maxB + 5.0)       // Updated to float
        }
