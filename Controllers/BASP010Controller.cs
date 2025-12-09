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
    public class BASP010Controller : Controller
    {
        private readonly ILogger<BASP010Controller> _logger;

        public BASP010Controller(ILogger<BASP010Controller> logger)
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