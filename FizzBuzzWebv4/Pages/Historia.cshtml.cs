using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FizzBuzzWebv4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWebv4.Pages
{
    public class HistoriaModel : PageModel
    {
        public FizzBuzz FizzBuzz { get; set; }
        public void OnGet()
        {
            var SessionAddress = HttpContext.Session.GetString("SessionAddress");
            if (SessionAddress != null)
                FizzBuzz = JsonConvert.DeserializeObject<FizzBuzz>(SessionAddress);
        }
    }
}
