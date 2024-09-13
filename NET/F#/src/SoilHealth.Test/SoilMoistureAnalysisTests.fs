module SoilHealth.Tests.SoilMoistureTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services
open SoilHealth.Interfaces


// Define the MockSoilDataService
type MockSoilDataService(soilData: SoilNutrientData) =
    interface ISoilDataService with
        member _.GetSoilData() = Some soilData

/// Mock crop provider for testing
type MockCropProvider() =
    interface ICropNutrientSufficiencyProvider with
        member _.GetCropNutrientSufficiency(cropName: string, growthStage: string) =
            Some { CropName = "Corn"
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

/// Test SoilAnalysisService moisture recommendations
[<Fact>]
let ``AnalyzeSoil should provide correct moisture recommendations`` () =
    let cropProvider = MockCropProvider()
    
    // Test case for low soil moisture
    let lowMoistureSoilData = { NPercentage = 2.0
                                PPercentage = 0.3
                                KPercentage = 1.5
                                CaPercentage = 0.5
                                MgPercentage = 0.3
                                SPercentage = 0.2
                                FePPM = 80.0
                                MnPPM = 60.0
                                CuPPM = 8.0
                                ZnPPM = 25.0
                                BPPM = 20.0
                                SoilMoisturePercentage = 15.0 } // Low soil moisture
    let soilDataService = MockSoilDataService(lowMoistureSoilData)
    let soilAnalysisService = SoilAnalysisService(cropProvider, soilDataService)

    let recommendationsLow = soilAnalysisService.AnalyzeSoil("Corn", "Tasselling")
    Assert.True(List.exists (fun (r: string) -> r.Contains("Soil moisture is too low")) recommendationsLow)
   

    // Test case for high soil moisture
    let highMoistureSoilData = { lowMoistureSoilData with SoilMoisturePercentage = 70.0 }
    let soilDataServiceHighMoisture = MockSoilDataService(highMoistureSoilData)
    let soilAnalysisService = SoilAnalysisService(cropProvider, soilDataServiceHighMoisture)
    let recommendationsHigh = soilAnalysisService.AnalyzeSoil("Corn", "Tasselling")
    Assert.True(List.exists (fun (r: string) -> r.Contains("Soil moisture is too high")) recommendationsHigh)
    
