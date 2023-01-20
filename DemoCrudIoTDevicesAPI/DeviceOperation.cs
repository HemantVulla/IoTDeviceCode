using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using Newtonsoft.Json;
using Message = Microsoft.Azure.Devices.Client.Message;
using System.Text;
using Microsoft.Azure.Devices.Shared;
using Microsoft.Azure.Devices;
using Microsoft.Extensions.Configuration;

namespace DemoCrudIoTDevicesAPI
{
    public class DeviceOperation : IDeviceOperation
    {

        private readonly IConfiguration _configuration;
        private readonly string _connectionString;
        private static RegistryManager registryManager;

        public DeviceOperation(IConfiguration configuration)
        {
            _connectionString = configuration.GetValue<string>("MyDeviceConfig:StorageConnection");
        }
        public async Task AddDeviceAsync(string deviceID)
        {
             

            Device device;
            try
            {
                registryManager = RegistryManager.CreateFromConnectionString(_connectionString);

                var d = new Device(deviceID);

                await registryManager.AddDeviceAsync(d);

            }
            catch (Exception ex)
            {

            }
        }

        public async Task DeleteDeviceAsync(string deviceID)
        {
            //  throw new NotImplementedException();
            Device device;
            try
            {

                registryManager = RegistryManager.CreateFromConnectionString(_connectionString);


                await registryManager.RemoveDeviceAsync(deviceID);
               // Console.WriteLine("Device Deleted");
            }
            catch (Exception ex)
            {

            }
        }

        public async  Task<List<string>> GetDeviceDetails(string deviceID)
        {
            // throw new NotImplementedException();
            Device device;
            try
            {

                registryManager = RegistryManager.CreateFromConnectionString(_connectionString);
                Device details = new Device();
                List<string> devicedetails = new List<string>();
                var d = await registryManager.GetDeviceAsync(deviceID);
                if (d != null)
                {
                    devicedetails.Add(d.Id.ToString());
                    devicedetails.Add(d.Status.ToString());
                    devicedetails.Add(d.GetType().ToString());
                }
                return devicedetails;


            }
            catch(Exception ex)
            {
                return null;
            }
            }
    }
}
