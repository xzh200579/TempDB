﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TempDB.Controllers
{
    public class GlobalPageController : Controller
    {
        // GET: GlobalPage
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main()
        {
            return View();
        }
        public ActionResult Top()
        {
            return View();
        }
        public ActionResult Left()
        {
            return View();
        }
    }
}