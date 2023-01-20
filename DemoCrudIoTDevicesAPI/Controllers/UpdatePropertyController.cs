using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI.Controllers
{
    public class UpdatePropertyController : Controller
    {

        private readonly IUpdateProperty _update;
        private readonly string _connectionString;
        //  private readonly string _container;

        public UpdatePropertyController(IUpdateProperty update, IConfiguration iConfig)
        {
            _update = update;


        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPut("UpdateDesired")]
        public IActionResult UpdateDesired(string deviceID,string propertyName, string propertyValue)
        {

            _update.UpdateDesiredProperty(deviceID, propertyName, propertyValue);
            return Ok();

        }

        [HttpPut("UpdateReported")]
        public IActionResult UpdateReported(string propertyValue)
        {

            _update.UpdateReportedProperty(propertyValue);
            return Ok();

        }
    }
}
