using Microsoft.Azure.Devices.Client;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI
{
    public class SendMessage : ISendMessage
    {
        private readonly IConfiguration _configuration;
        private readonly string _connectionStringDeviceID;
        private static DeviceClient s_deviceClient;

        public SendMessage(IConfiguration configuration)
        {
            _connectionStringDeviceID = configuration.GetValue<string>("MyDeviceConfig:StorageConnectionDevice");
        }
        public async Task SendDeviceToCloudMessagesAsync(string sendMessage)
        {
            // throw new NotImplementedException();
            s_deviceClient = DeviceClient.CreateFromConnectionString(_connectionStringDeviceID);
            var telemetrydata = new { sendMessage };
            string messageString = "";
             messageString = JsonConvert.SerializeObject(telemetrydata);

            var message = new Message(Encoding.ASCII.GetBytes(messageString));
            await s_deviceClient.SendEventAsync(message);
        }
    }
}
