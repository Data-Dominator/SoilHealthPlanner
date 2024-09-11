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
        NPercentage = (2.5, 3.5)
        PPercentage = (0.2, 0.5)
        KPercentage = (1.5, 2.5)
        CaPercentage = (0.4, 1.0)
        MgPercentage = (0.2, 0.4)
        SPercentage = (0.2, 0.3)
        FePPM = (20.0, 100.0)
        MnPPM = (50.0, 150.0)
        CuPPM = (5.0, 10.0)
        ZnPPM = (20.0, 50.0)
        BPPM = (30.0, 50.0)
    }

    // Sample soil data (deficiency in Nitrogen and Potassium)
    let soilData = {
        NPercentage = 1.8
        PPercentage = 0.3
        KPercentage = 1.2
        CaPercentage = 0.6
        MgPercentage = 0.35
        SPercentage = 0.2
        FePPM = 90.0
        MnPPM = 120.0
        CuPPM = 8.0
        ZnPPM = 40.0
        BPPM = 45.0
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
