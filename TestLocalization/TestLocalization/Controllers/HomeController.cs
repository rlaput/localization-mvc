﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TestLocalization.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = Resources.About.TextAboutCaption1;

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = Resources.Contact.TextContactCaption;

            return View();
        }
    }
}