using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Car> Cars { get; set; }


        public async Task OnGetAsync()
        {
            Cars = await _context.Cars.ToListAsync();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }
            var car = await _context.Cars.FindAsync(carId);
            if (car != null)
            {
                _context.Cars.Remove(car);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("/CarPages/Index");
        }
    }
}
