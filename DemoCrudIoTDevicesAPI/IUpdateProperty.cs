using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI
{
   public interface IUpdateProperty
    {
        Task UpdateDesiredProperty(string deviceID, string propertyName, string propertyValue);

        Task UpdateReportedProperty(string propertyValue);
    }
}
