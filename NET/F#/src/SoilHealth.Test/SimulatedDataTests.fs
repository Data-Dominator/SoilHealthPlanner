module SoilHealth.Tests.SimulatedDataTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services

[<Fact>]
let ``Test Generate Random Soil Data`` () =
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

    // Create the simulated data service
    let simulatedDataService = SimulatedDataService()

    // Generate random soil data
    let randomSoilData = simulatedDataService.GenerateRandomSoilData(cropData)

    // Assert that the generated data is within the expected range
    Assert.InRange(randomSoilData.NPercentage, 2.5, 3.5)
    Assert.InRange(randomSoilData.PPercentage, 0.2, 0.5)
    Assert.InRange(randomSoilData.FePPM, 20.0, 100.0)


