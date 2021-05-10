using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC.Models;
using Logic;

namespace MVC.Controllers
{
    public class PublicApiController : Controller
    {
        //Action Methods devuelven models a diferencia de los objetos ActionResult MVC
        public ActionResult Index()
        {
            PublicApiLogic publicApiLogic = new PublicApiLogic();
            PublicApiView view = new PublicApiView();
            view.content = publicApiLogic.GetAll();

            return View(view);
        }
    }
}