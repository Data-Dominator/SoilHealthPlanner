module SoilHealth.Tests.SoilAnalysisTests

open Xunit
open SoilHealth.Models
open SoilHealth.Services
open SoilHealth.Interfaces

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

/// Mock soil data service for testing
type MockSoilDataService(soilData: SoilNutrientData) =
    interface ISoilDataService with
        member _.GetSoilData() = Some soilData

/// Test SoilAnalysisService nutrient recommendations
[<Fact>]
let ``AnalyzeSoil should provide correct nutrient recommendations`` () =
    let cropProvider = MockCropProvider()
    let soilData = { NPercentage = 2.0
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
                     SoilMoisturePercentage = 35.0 }
    let soilDataService = MockSoilDataService(soilData)
    let soilAnalysisService = SoilAnalysisService(cropProvider, soilDataService)

    let recommendations = soilAnalysisService.AnalyzeSoil("Corn", "Tasselling")

   // Check if any recommendation contains the substring "Nitrogen (N) is low."
    Assert.True(List.exists (fun (r: string) -> r.Contains("Nitrogen (N) is low.")) recommendations)
    Assert.True(List.exists (fun (r: string) -> r.Contains("Phosphorus (P) is within the optimal range")) recommendations)
    Assert.True(List.exists (fun (r: string) -> r.Contains("Soil moisture is within the optimal range")) recommendations)   
