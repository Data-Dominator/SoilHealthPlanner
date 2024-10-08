﻿namespace SoilHealth.Models

type NutrientRange = float * float

type CropNutrientSufficiency = {
    CropName: string
    GrowthStage: string
    NitrogenRange: NutrientRange
    PhosphorusRange: NutrientRange
    PotassiumRange: NutrientRange
    CalciumRange: NutrientRange
    MagnesiumRange: NutrientRange
    SulfurRange: NutrientRange
    IronRange: NutrientRange
    ManganeseRange: NutrientRange
    CopperRange: NutrientRange
    ZincRange: NutrientRange
    BoronRange: NutrientRange
}

/// Module to hold predefined crop data examples for testing or default usage.
module CropNutrientSufficiencyExamples =

    // Example sufficiency data for Corn at the Tasselling stage.
    let cornTasselling =
        { CropName = "Corn"
          GrowthStage = "Tasselling"
          NitrogenRange = (2.5, 3.5)
          PhosphorusRange = (0.2, 0.5)
          PotassiumRange = (1.5, 2.5)
          CalciumRange = (0.4, 1.0)
          MagnesiumRange = (0.2, 0.4)
          SulfurRange = (0.2, 0.3)
          IronRange = (20, 100)
          ManganeseRange = (50, 150)
          CopperRange = (5, 10)
          ZincRange = (20, 50)
          BoronRange = (30, 50) }

    // Example sufficiency data for Soybeans at the Flowering stage.
    let soybeansFlowering =
        { CropName = "Soybeans"
          GrowthStage = "Flowering"
          NitrogenRange = (4.25, 5.5)
          PhosphorusRange = (0.25, 0.5)
          PotassiumRange = (1.7, 2.5)
          CalciumRange = (0.3, 1.0)
          MagnesiumRange = (0.2, 0.4)
          SulfurRange = (0.2, 0.4)
          IronRange = (50, 350)
          ManganeseRange = (25, 100)
          CopperRange = (5, 10)
          ZincRange = (30, 50)
          BoronRange = (20, 50) }

    // Example sufficiency data for Alfalfa at the Flowering stage.
    let alfalfaFlowering =
        { CropName = "Alfalfa"
          GrowthStage = "Flowering"
          NitrogenRange = (2.5, 5.0)
          PhosphorusRange = (0.25, 0.7)
          PotassiumRange = (2.0, 3.5)
          CalciumRange = (0.3, 1.0)
          MagnesiumRange = (0.25, 0.7)
          SulfurRange = (0.25, 0.5)
          IronRange = (30, 250)
          ManganeseRange = (25, 100)
          CopperRange = (8, 30)
          ZincRange = (25, 70)
          BoronRange = (30, 80) }

    // Example sufficiency data for Wheat at the Prior to Filling stage.
    let wheatPriorToFilling =
        { CropName = "Wheat"
          GrowthStage = "Prior to Filling"
          NitrogenRange = (2.0, 3.0)
          PhosphorusRange = (0.26, 0.5)
          PotassiumRange = (1.5, 3.0)
          CalciumRange = (0.2, 1.0)
          MagnesiumRange = (0.12, 0.4)
          SulfurRange = (0.15, 0.4)
          IronRange = (20, 250)
          ManganeseRange = (15, 100)
          CopperRange = (3, 25)
          ZincRange = (15, 70)
          BoronRange = (5, 25) }
