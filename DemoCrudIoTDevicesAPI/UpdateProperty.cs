using Microsoft.Azure.Devices;
using Microsoft.Azure.Devices.Client;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI
{
    public class UpdateProperty : IUpdateProperty
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private readonly string _connectionStringDeviceID;
        private static RegistryManager registryManager;
        private static DeviceClient s_deviceClient;

        public UpdateProperty(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("MyDeviceConfig:StorageConnection");
            _connectionStringDeviceID = configuration.GetValue<string>("MyDeviceConfig:StorageConnectionDevice");
        }
        public  async Task UpdateDesiredProperty(string deviceID, string propertyName, string propertyValue)
        {
            //  throw new NotImplementedException();
            registryManager = RegistryManager.CreateFromConnectionString(_connectionString);
            var twin = await registryManager.GetTwinAsync(deviceID);

            string patch =
                @"{
        properties: {
            desired: {
              testData: 'DesiredPropertyByApp'
            }
        }
    }";
            patch = patch.Replace("testData", propertyName);
            patch = patch.Replace("DesiredPropertyByApp", propertyValue);

            await registryManager.UpdateTwinAsync(deviceID, patch, twin.ETag);
        }

        public async Task UpdateReportedProperty(string propertyValue)
        {
           // throw new NotImplementedException();
           s_deviceClient = DeviceClient.CreateFromConnectionString(_connectionStringDeviceID);

            var twin = await s_deviceClient.GetTwinAsync();

            string patch =
                "{\"type\":\"ReportedPropertyByApp\"}";
            patch = patch.Replace("ReportedPropertyByApp", propertyValue);

            await s_deviceClient.UpdateReportedPropertiesAsync(JsonConvert.DeserializeObject<TwinCollection>(patch));
        }
    }
}
