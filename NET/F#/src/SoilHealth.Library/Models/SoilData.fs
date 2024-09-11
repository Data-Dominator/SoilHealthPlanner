namespace SoilHealth.Models

/// Represents the nutrient levels in the soil.
/// This data can either be manually entered by the user or generated through simulations.

type SoilNutrientData = {
    NPercentage: float  // Nitrogen percentage in the soil
    PPercentage: float  // Phosphorus percentage in the soil
    KPercentage: float  // Potassium percentage in the soil
    CaPercentage: float // Calcium percentage in the soil
    MgPercentage: float // Magnesium percentage in the soil
    SPercentage: float  // Sulfur percentage in the soil
    FePPM: float          // Iron in parts per million (ppm)
    MnPPM: float          // Manganese in parts per million (ppm)
    CuPPM: float          // Copper in parts per million (ppm)
    ZnPPM: float          // Zinc in parts per million (ppm)
    BPPM: float           // Boron in parts per million (ppm)
}

/// Function to create an example SoilNutrientData for testing or development purposes.
module SoilNutrientDataExamples =

    /// Example of soil data with default values.
    let defaultSoilNutrientData = {
        NPercentage = 2.5  // Nitrogen
        PPercentage = 0.4  // Phosphorus
        KPercentage = 1.8  // Potassium
        CaPercentage = 0.8 // Calcium
        MgPercentage = 0.25 // Magnesium
        SPercentage = 0.2  // Sulfur
        FePPM = 50         // Iron
        MnPPM = 60         // Manganese
        CuPPM = 8          // Copper
        ZnPPM = 25         // Zinc
        BPPM = 35          // Boron
    }
