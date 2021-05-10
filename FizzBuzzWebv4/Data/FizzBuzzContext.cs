using FizzBuzzWebv4.Models;
using Microsoft.EntityFrameworkCore;

namespace FizzBuzzWebv4.Data
{
    public class FizzBuzzContext : DbContext
    {
        public FizzBuzzContext(DbContextOptions options) : base(options) { }
        public DbSet<FizzBuzz> FizzBuzz { get; set; }
    }
}