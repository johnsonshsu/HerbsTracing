using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace HerbsTracing.Controllers
{
    [Route("[controller]")]
    public class BASP014Controller : Controller
    {
        private readonly ILogger<BASP014Controller> _logger;

        public BASP014Controller(ILogger<BASP014Controller> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View("Error!");
        }
    }
}