using CropGuardian.SoilMetrics.Interfaces;
using CropGuardian.SoilMetrics.Models;

namespace CropGuardian.SoilMetrics.IotServices
{
    public class IoTDataService : ISoilDataService
    {
        public SoilNutrientData GetSoilData()
        {
            try
            {
                // Replace this logic with actual IoT device integration
                // For now, return mock data
                return new SoilNutrientData(
                    nPercentage: 2.8f,
                    pPercentage: 0.35f,
                    kPercentage: 1.7f,
                    caPercentage: 0.8f,
                    mgPercentage: 0.3f,
                    sPercentage: 0.2f,
                    fePPM: 85.0f,
                    mnPPM: 120.0f,
                    cuPPM: 8.5f,
                    znPPM: 30.0f,
                    bPPM: 40.0f,
                    soilMoisturePercentage: 40.0f
                );
            }
            catch (Exception ex)
            {
                throw new IoTDeviceException("Error fetching data from IoT device.", ex);
            }
        }
    }

    // Custom exception for IoT device issues
    public class IoTDeviceException : Exception
    {
        public IoTDeviceException(string message, Exception innerException)
            : base(message, innerException) { }
    }
}
