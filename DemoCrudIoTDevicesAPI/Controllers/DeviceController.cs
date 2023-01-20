using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI.Controllers
{
    public class DeviceController : Controller
    {
        private readonly IDeviceOperation _deviceoperation;
        private readonly string _connectionString;
      //  private readonly string _container;

        public DeviceController(IDeviceOperation deviceoperation, IConfiguration iConfig)
        {
            _deviceoperation = deviceoperation;
          
          
        }
        //public IActionResult Index()
        //{
        //    return View();
        //}

        [HttpPost("AddDevice")]
        public IActionResult AddNewDevice(string deviceID)
        {

            _deviceoperation.AddDeviceAsync(deviceID);
            return Ok();

        }


        [HttpGet("GetDeviceDetails")]
        public async Task<List<string>> DeviceDetails(string deviceID)
        {
            return await _deviceoperation.GetDeviceDetails(deviceID);
        }


        [HttpGet("DeleteDevice")]
        public async Task<IActionResult> DeleteDetails(string deviceID)
        {
           await _deviceoperation.DeleteDeviceAsync(deviceID);
            return Ok();
           // return File(content, System.Net.Mime.MediaTypeNames.Application.Octet, fileName);
        }
    }
}
