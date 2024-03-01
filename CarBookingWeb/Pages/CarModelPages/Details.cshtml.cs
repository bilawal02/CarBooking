using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public CarModel CarModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carmodel = await _context.CarModels.Include(x=>x.CarMaker).FirstOrDefaultAsync(m => m.Id == id);
            if (carmodel == null)
            {
                return NotFound();
            }
            else
            {
                CarModel = carmodel;
            }
            return Page();
        }
    }
}
