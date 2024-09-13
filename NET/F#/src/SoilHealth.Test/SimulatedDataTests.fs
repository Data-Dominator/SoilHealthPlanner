module SoilHealth.Tests.SimulatedDataTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services

/// Mock crop nutrient sufficiency data for testing
let mockCropData = 
    { CropName = "Corn"
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
      BoronRange = (30.0, 50.0) }

/// Test that SimulatedDataService generates random soil data within the crop's nutrient ranges
[<Fact>]
let ``GenerateRandomSoilData should generate soil data within crop's nutrient range`` () =
    let simulatedDataService = SimulatedDataService()
    let randomSoilData = simulatedDataService.GenerateRandomSoilData(Some mockCropData)

    // Assert that the generated soil data is within the specified range
    Assert.InRange(randomSoilData.NPercentage, 2.5, 3.5)
    Assert.InRange(randomSoilData.PPercentage, 0.2, 0.5)
    Assert.InRange(randomSoilData.KPercentage, 1.5, 2.5)
    Assert.InRange(randomSoilData.CaPercentage, 0.4, 1.0)
    Assert.InRange(randomSoilData.MgPercentage, 0.2, 0.4)
    Assert.InRange(randomSoilData.SPercentage, 0.2, 0.3)
    Assert.InRange(randomSoilData.FePPM, 20.0, 100.0)
    Assert.InRange(randomSoilData.MnPPM, 50.0, 150.0)
    Assert.InRange(randomSoilData.CuPPM, 5.0, 10.0)
    Assert.InRange(randomSoilData.ZnPPM, 20.0, 50.0)
    Assert.InRange(randomSoilData.BPPM, 30.0, 50.0)

/// Test that SimulatedDataService generates purely random soil data
[<Fact>]
let ``GeneratePureRandomSoilData should generate random soil data`` () =
    let simulatedDataService = SimulatedDataService()
    let randomSoilData = simulatedDataService.GeneratePureRandomSoilData()

    // Just check the ranges; they should be reasonable
    Assert.InRange(randomSoilData.NPercentage, 1.0, 5.0)
    Assert.InRange(randomSoilData.PPercentage, 0.1, 1.0)
    Assert.InRange(randomSoilData.KPercentage, 0.5, 3.0)
    Assert.InRange(randomSoilData.CaPercentage, 0.2, 1.5)
    Assert.InRange(randomSoilData.MgPercentage, 0.1, 1.0)
    Assert.InRange(randomSoilData.SPercentage, 0.1, 0.5)
    Assert.InRange(randomSoilData.FePPM, 10.0, 100.0)
    Assert.InRange(randomSoilData.MnPPM, 20.0, 200.0)
    Assert.InRange(randomSoilData.CuPPM, 2.0, 15.0)
    Assert.InRange(randomSoilData.ZnPPM, 5.0, 50.0)
    Assert.InRange(randomSoilData.BPPM, 10.0, 60.0)
