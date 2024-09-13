namespace SoilHealth.Interfaces

open SoilHealth.Models

type ISoilDataService =
    abstract member GetSoilData: unit -> SoilNutrientData option

