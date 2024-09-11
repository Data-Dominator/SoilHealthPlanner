module SoilHealth.Tests.SimulatedDataTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services

[<Fact>]
let ``Test Generate Random Soil Data Within Range`` () =
    // Sample crop data (Corn at Tasselling) wrapped in Some to match Option type
    let cropData = Some {
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

    // Create the simulated data service
    let simulatedDataService = SimulatedDataService()

    // Generate random soil data
    let randomSoilData = simulatedDataService.GenerateRandomSoilData(cropData)

    // Assert that the generated data is within the expected ranges
    Assert.InRange(randomSoilData.NPercentage, fst (2.5, 3.5), snd (2.5, 3.5))
    Assert.InRange(randomSoilData.PPercentage, fst (0.2, 0.5), snd (0.2, 0.5))
    Assert.InRange(randomSoilData.KPercentage, fst (1.5, 2.5), snd (1.5, 2.5))
    Assert.InRange(randomSoilData.CaPercentage, fst (0.4, 1.0), snd (0.4, 1.0))
    Assert.InRange(randomSoilData.MgPercentage, fst (0.2, 0.4), snd (0.2, 0.4))
    Assert.InRange(randomSoilData.SPercentage, fst (0.2, 0.3), snd (0.2, 0.3))
    Assert.InRange(randomSoilData.FePPM, fst (20.0, 100.0), snd (20.0, 100.0))
    Assert.InRange(randomSoilData.MnPPM, fst (50.0, 150.0), snd (50.0, 150.0))
    Assert.InRange(randomSoilData.CuPPM, fst (5.0, 10.0), snd (5.0, 10.0))
    Assert.InRange(randomSoilData.ZnPPM, fst (20.0, 50.0), snd (20.0, 50.0))
    Assert.InRange(randomSoilData.BPPM, fst (30.0, 50.0), snd (30.0, 50.0))
