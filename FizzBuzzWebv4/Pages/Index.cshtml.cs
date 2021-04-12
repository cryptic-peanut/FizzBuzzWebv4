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
using FizzBuzzWebv4.Data;

namespace FizzBuzzWebv4.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public FizzBuzz FizzBuzz { get; set; }
        private readonly ILogger<IndexModel> _logger;
        private readonly FizzBuzzContext _context;
        public IndexModel(ILogger<IndexModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public async Task<IActionResult> OnPostAsync()
        {
            FizzBuzz.Date = DateTime.Now;
            FizzBuzz.Result = "";
            if (FizzBuzz.Number % 3 == 0)
                FizzBuzz.Result += "Fizz";
            if (FizzBuzz.Number % 5 == 0)
                FizzBuzz.Result += "buzz";
            if (FizzBuzz.Result == "")
                FizzBuzz.Result = "Brak";
            if (ModelState.IsValid)
            {
                HttpContext.Session.SetString("SessionAddress", JsonConvert.SerializeObject(FizzBuzz));
                _context.FizzBuzz.Add(FizzBuzz);
                await _context.SaveChangesAsync();
            }
            return Page();
        }
    }
}
