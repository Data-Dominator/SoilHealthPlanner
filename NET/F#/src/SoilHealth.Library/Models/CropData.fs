namespace SoilHealth.Models

/// Represents the nutrient sufficiency levels for a specific crop at a particular growth stage.
/// Each field specifies the acceptable range for nutrient levels.
type CropNutrientSufficiency = {
    CropName: string        // The name of the crop (e.g., Corn, Soybeans)
    GrowthStage: string     // The growth stage (e.g., Flowering, Tasselling)
    NPercentage: float * float // Nitrogen percentage range (min, max)
    PPercentage: float * float // Phosphorus percentage range (min, max)
    KPercentage: float * float // Potassium percentage range (min, max)
    CaPercentage: float * float // Calcium percentage range (min, max)
    MgPercentage: float * float // Magnesium percentage range (min, max)
    SPercentage: float * float // Sulfur percentage range (min, max)
    FePPM: float * float        // Iron in parts per million (min, max)
    MnPPM: float * float        // Manganese in parts per million (min, max)
    CuPPM: float * float        // Copper in parts per million (min, max)
    ZnPPM: float * float        // Zinc in parts per million (min, max)
    BPPM: float * float         // Boron in parts per million (min, max)
}

/// Module to hold predefined crop data examples for testing or default usage.
module CropNutrientSufficiencyExamples =

    /// Example sufficiency data for Corn at the Tasselling stage.
    let cornTasselling = {
        CropName = "Corn"
        GrowthStage = "Tasselling"
        NPercentage = (2.5, 3.5)
        PPercentage = (0.2, 0.5)
        KPercentage = (1.5, 2.5)
        CaPercentage = (0.4, 1.0)
        MgPercentage = (0.2, 0.4)
        SPercentage = (0.2, 0.3)
        FePPM = (20, 100)
        MnPPM = (50, 150)
        CuPPM = (5, 10)
        ZnPPM = (20, 50)
        BPPM = (30, 50)
    }

    /// Example sufficiency data for Soybeans at the Flowering stage.
    let soybeansFlowering = {
        CropName = "Soybeans"
        GrowthStage = "Flowering"
        NPercentage = (4.25, 5.5)
        PPercentage = (0.25, 0.5)
        KPercentage = (1.7, 2.5)
        CaPercentage = (0.3, 1.0)
        MgPercentage = (0.2, 0.4)
        SPercentage = (0.2, 0.4)
        FePPM = (50, 350)
        MnPPM = (25, 100)
        CuPPM = (5, 10)
        ZnPPM = (30, 50)
        BPPM = (20, 50)
    }

    /// Example sufficiency data for Alfalfa at the Flowering stage.
    let alfalfaFlowering = {
        CropName = "Alfalfa"
        GrowthStage = "Flowering"
        NPercentage = (2.5, 5.0)
        PPercentage = (0.25, 0.7)
        KPercentage = (2.0, 3.5)
        CaPercentage = (0.3, 1.0)
        MgPercentage = (0.25, 0.7)
        SPercentage = (0.25, 0.5)
        FePPM = (30, 250)
        MnPPM = (25, 100)
        CuPPM = (8, 30)
        ZnPPM = (25, 70)
        BPPM = (30, 80)
    }
    
    /// Example sufficiency data for Wheat at the Prior to Filling stage.
    let wheatPriorToFilling = {
        CropName = "Wheat"
        GrowthStage = "Prior to Filling"
        NPercentage = (2.0, 3.0)
        PPercentage = (0.26, 0.5)
        KPercentage = (1.5, 3.0)
        CaPercentage = (0.2, 1.0)
        MgPercentage = (0.12, 0.4)
        SPercentage = (0.15, 0.4)
        FePPM = (20, 250)
        MnPPM = (15, 100)
        CuPPM = (3, 25)
        ZnPPM = (15, 70)
        BPPM = (5, 25)
    }
