using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogiTrack.Core.ViewModels.Vehicle
{
    public class VehicleStatisticsViewmodel
    {
        public int TotalVehiclesCount { get; set; }
        public int RefrigeratedVehiclesCount { get; set; }
        public string TotalDistanceTravelled { get; set; } = string.Empty;
        public string AverageDistancePerVehicle { get; set; } = string.Empty;
        public string TotalFuelConsumed { get; set; } = string.Empty;
        public int VehiclesForRepairment { get; set; } 

    }
}
