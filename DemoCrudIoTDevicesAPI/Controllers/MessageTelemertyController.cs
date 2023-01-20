using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoCrudIoTDevicesAPI.Controllers
{
    public class MessageTelemertyController : Controller
    {

        private readonly ISendMessage _messageoperation;
        private readonly string _connectionString;
        //  private readonly string _container;

        public MessageTelemertyController(ISendMessage sendmessage, IConfiguration iConfig)
        {
            _messageoperation = sendmessage;


        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost("SendMessageToTelemetry")]
        public IActionResult AddNewDevice(string message)
        {

            _messageoperation.SendDeviceToCloudMessagesAsync(message);
            return Ok();

        }
    }
}
