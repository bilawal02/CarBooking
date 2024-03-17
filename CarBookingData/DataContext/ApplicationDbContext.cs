using CarBookingModels.Models;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.DataContext
{
    //public class ApplicationDbContext : DbContext
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<CarMaker> CarMakers { get; set; }
        public DbSet<CarModel> CarModels { get; set; }
        public DbSet<CarColor> CarColors { get; set; }
    }
}
