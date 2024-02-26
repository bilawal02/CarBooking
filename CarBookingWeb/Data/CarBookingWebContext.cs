using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using CarBookingModels.Models;

namespace CarBookingWeb.Data
{
    public class CarBookingWebContext : DbContext
    {
        public CarBookingWebContext (DbContextOptions<CarBookingWebContext> options)
            : base(options)
        {
        }

        public DbSet<CarBookingModels.Models.CarMaker> CarMaker { get; set; } = default!;
    }
}
