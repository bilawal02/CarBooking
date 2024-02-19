﻿using CarBookingWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Car> Cars { get; set; }
    }
}
