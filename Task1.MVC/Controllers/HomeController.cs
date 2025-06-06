using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Task1.MVC.Data;
using Task1.MVC.Services;

namespace Task1.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPersonService _personService;

        public HomeController(IPersonService personService)
        {
            _personService = personService;
        }

        public ActionResult Index(int page = 1, int pageSize = 10)
        {
            var sw = Stopwatch.StartNew();

            var viewModel = _personService.GetPersons(page, pageSize);

            sw.Stop();

            viewModel.Elapsed = sw.Elapsed.TotalMilliseconds.ToString("F2");

            return View(viewModel);
        }
    }
}