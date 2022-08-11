using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataKendaraan.Controllers
{
    public class KendaraanController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult TambahData()
        {
            return View();
        }

        public IActionResult Detail()
        {
            return View();
        }

        public IActionResult Edit()
        {
            return View();
        }
    }
}
