using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI
{
   public interface IDeviceOperation
    {
        Task AddDeviceAsync( string deviceID);

        Task DeleteDeviceAsync(string deviceID);

        Task <List<string>> GetDeviceDetails(string deviceID);
    }
}
