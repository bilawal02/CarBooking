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

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? recordId)
        {
            if (recordId <= 0 || recordId == null)
            {
                return NotFound();
            }
            var carMaker = await _context.CarMakers.FindAsync(recordId);
            if (carMaker != null)
            {
                _context.CarMakers.Remove(carMaker);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
