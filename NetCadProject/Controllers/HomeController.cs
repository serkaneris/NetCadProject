using NetCadProject.Helpers;
using NetCadProject.Models;
using NetCadProject.Models.Enums;
using Newtonsoft.Json;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NetCadProject.Controllers
{
    public class HomeController : Controller
    {
        private Logger logger = LogManager.GetCurrentClassLogger();
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult CreateShape(ShapeType shapeType)
        {
            string clientAddress = HttpContext.Request.UserHostAddress; 
            var shape = new ShapeBuilder(shapeType).Draw();

            
            logger.Trace("Client:"+HttpContext.Request.UserHostAddress + " " + JsonConvert.SerializeObject(shape, Formatting.Indented));
            
            return Json(shape);
        }
    }
}