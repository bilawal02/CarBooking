using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingModels.Models;
using CarBookingWeb.Data;
using CarBookingWeb.DataContext;

namespace CarBookingWeb.Pages.CarMakerPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CarMaker> CarMaker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            CarMaker = await _context.CarMakers.ToListAsync();
        }
    }
}
