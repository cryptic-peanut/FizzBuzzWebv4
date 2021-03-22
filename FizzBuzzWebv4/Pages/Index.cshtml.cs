using FizzBuzzWebv4.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;

namespace FizzBuzzWebv4.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        [BindProperty(SupportsGet = true)]
        public string Name { get; set; }
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (string.IsNullOrWhiteSpace(Name))
                Name = "User";
        }

        public IActionResult OnPost()
        {
            if (FizzBuzz.Number % 3 == 0 && FizzBuzz.Number % 5 == 0)
                FizzBuzz.Result = "Fizzbuzz";
            else if (FizzBuzz.Number % 3 == 0)
                FizzBuzz.Result = "Fizz";
            else if (FizzBuzz.Number % 5 == 0)
                FizzBuzz.Result = "Buzz";
            else
                FizzBuzz.Result = "";
            if (ModelState.IsValid)
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
            return Page();
        }
    }
}
