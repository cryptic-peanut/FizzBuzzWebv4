using System.Collections.Generic;
using System.Linq;
using FizzBuzzWebv4.Data;
using FizzBuzzWebv4.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace FizzBuzzWebv4.Pages
{
    public class HistoriaDBModel : PageModel
    {
        private readonly FizzBuzzContext _context;
        private readonly ILogger<HistoriaDBModel> _logger;
        public HistoriaDBModel(ILogger<HistoriaDBModel> logger, FizzBuzzContext context)
        {
            _logger = logger;
            _context = context;
        }
        public IList<FizzBuzz> Fizzbuzz { get; set; }

        public void OnGet()
        {
            Fizzbuzz = _context.FizzBuzz.FromSqlRaw("select top 10 * from FizzBuzz order by Date desc").ToList();
        }
    }
}
