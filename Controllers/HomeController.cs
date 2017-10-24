using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace passcode.Controllers
{
    [HttpGet]
    [Route("")]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            Random randNum = new Random();
            int? runs = HttpContext.Session.GetInt32("runs")
            if(runs == null)
            {
                runs = 0;
            }
            runs += 1;
            string availableCharacters ="abcdefghijklmnopqrstuvwxyz1234567890"
            string code = "";
            for (int i = 0; i < 14; i++)
            {
                code = code + availableCharacters[randNum.Next(0, availableCharacters.Length)];
            }
            ViewBag.code = code;
            ViewBag.runs = runs;
            HttpContext.Session.SetInt32("runs", (int)runs)
            return View();
        }
    }
}
