using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Threading;
using System.Threading.Tasks;
using Messages;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using NServiceBus;
using WarehouseWorkerUI.PickLists;
using WarehouseWorkerUI.PickLists.DataModels;

namespace WarehouseWorkerUI.Controllers
{
    [Route("/")]
    public class HomeController : Controller
    {
        static int messagesSent;
        private readonly ILogger<HomeController> _log;
        private readonly IProvidePickLists _providePickLists;
        private readonly IMessageSession _messageSession;

        public HomeController(IMessageSession messageSession, ILogger<HomeController> logger, IProvidePickLists providePickLists)
        {
            _messageSession = messageSession;
            _log = logger;
            _providePickLists = providePickLists;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            List<PickList> pickLists = await _providePickLists.GetPickLists();
            return View(pickLists);
        }

        [HttpPost]
        public async Task<ActionResult> MarkAsReadyToShip(string pickListId)
        {

            var command = new MarkPackageAsReadyToShip(pickListId);

            // Send the command
            await _messageSession.Send(command)
                .ConfigureAwait(false);

            _log.LogInformation($"Sending {command.GetType()}, PickListId = {pickListId}");


            return View();
        }
    }
}
