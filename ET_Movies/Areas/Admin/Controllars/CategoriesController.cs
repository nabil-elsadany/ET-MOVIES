﻿using ET_Movies.Data;
using Microsoft.AspNetCore.Mvc;

namespace ET_Movies.Areas.Admin.Controllars
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        ApplicationDbcontext dbcontext = new ApplicationDbcontext();
        public IActionResult Index()
        {
            return View(dbcontext.Categories);
        }
    }
}
