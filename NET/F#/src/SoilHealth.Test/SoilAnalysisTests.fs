module SoilHealth.Tests.SoilAnalysisTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services

[<Fact>]
let ``Test Soil Analysis with Deficiency`` () =
    // Sample crop data (Corn at Tasselling)
    let cropData = {
        CropName = "Corn"
        GrowthStage = "Tasselling"
        NitrogenRange = (2.5, 3.5)
        PhosphorusRange = (0.2, 0.5)
        PotassiumRange = (1.5, 2.5)
        CalciumRange = (0.4, 1.0)
        MagnesiumRange = (0.2, 0.4)
        SulfurRange = (0.2, 0.3)
        IronRange = (20.0, 100.0)
        ManganeseRange = (50.0, 150.0)
        CopperRange = (5.0, 10.0)
        ZincRange = (20.0, 50.0)
        BoronRange = (30.0, 50.0)
    }

    // Sample soil data (with deficiencies in Nitrogen and Potassium)
    let soilData = {
        NPercentage = 1.8   // Below the minimum of 2.5
        PPercentage = 0.3   // Within range
        KPercentage = 1.2   // Below the minimum of 1.5
        CaPercentage = 0.6  // Within range
        MgPercentage = 0.35 // Within range
        SPercentage = 0.2   // Within range
        FePPM = 90.0        // Within range
        MnPPM = 120.0       // Within range
        CuPPM = 7.0         // Within range
        ZnPPM = 40.0        // Within range
        BPPM = 45.0         // Within range
    }

    // Create the analysis service
    let analysisService = SoilAnalysisService()

    // Perform the analysis
    let recommendations = analysisService.AnalyzeSoil(soilData, cropData)

    // Assert that the number of deficiencies is correct
    Assert.Equal(2, recommendations.Length)

    // Assert that specific deficiencies are returned
    Assert.Contains("Nitrogen (N) is low.", recommendations)
    Assert.Contains("Potassium (K) is low.", recommendations)
