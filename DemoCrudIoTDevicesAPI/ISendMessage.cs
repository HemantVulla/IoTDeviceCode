using Microsoft.Azure.Devices.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI
{
   public interface ISendMessage
    {
        Task SendDeviceToCloudMessagesAsync(string sendMessage);
    }
}
