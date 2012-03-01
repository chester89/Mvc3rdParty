using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mvc3rdParty.Core;
using Mvc3rdParty.Core.Entities;
using Mvc3rdParty.Web.Models;

namespace Mvc3rdParty.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IRepository<Stock> stockRepository;

        public HomeController(IRepository<Stock> stockRepository)
        {
            this.stockRepository = stockRepository;
        }

        public ActionResult Index()
        {
            var model = new ListModel()
                            {
                                Stocks = stockRepository.GetAll().ToList()
                            };
            return View(model);
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View(new LoginModel());
        }

        [HttpPost]
        public ActionResult Login(LoginModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            return RedirectToAction("Index");
        }
    }
}
