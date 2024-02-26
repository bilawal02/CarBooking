using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Car { get; set; }
        public SelectList Makes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }
            Car = await _context.Cars.FirstOrDefaultAsync(x=>x.CarId == carId);
            if (Car==null)
            {
                return NotFound();
            }
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _context.Attach(Car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/CarPages/Index");
        }
        private bool carExists(int? id)
        {
            return _context.Cars.Any(x => x.CarId == id);
        }
    }
}
