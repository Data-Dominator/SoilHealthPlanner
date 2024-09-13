using CropGuardian.SoilMetrics.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CropGuardian.SoilMetrics.Interfaces
{
    public interface ISoilDataService
    {
        SoilNutrientData GetSoilData();
    }

    
}
