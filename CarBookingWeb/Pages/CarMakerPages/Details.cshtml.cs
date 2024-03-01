using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingModels.Models;
using CarBookingWeb.DataContext;

namespace CarBookingWeb.Pages.CarMakerPages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CarMaker CarMaker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carmaker = await _context.CarMakers.FirstOrDefaultAsync(m => m.Id == id);
            if (carmaker == null)
            {
                return NotFound();
            }
            else
            {
                CarMaker = carmaker;
            }
            return Page();
        }
    }
}
