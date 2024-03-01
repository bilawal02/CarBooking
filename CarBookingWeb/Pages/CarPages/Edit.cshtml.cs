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
        public SelectList Models { get; set; }
        public SelectList Colors { get; set; }

        public async Task<IActionResult> OnGetAsync(int? carId)
        {
            if (carId == null)
            {
                return NotFound();
            }
            Car = await _context.Cars.FirstOrDefaultAsync(x=>x.Id == carId);
            if (Car==null)
            {
                return NotFound();
            }
            await LoadInitialDataDropDown();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }
            _context.Attach(Car).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return RedirectToPage("/CarPages/Index");
        }
        private bool carExists(int? id)
        {
            return _context.Cars.Any(x => x.Id == id);
        }
        private async Task LoadInitialDataDropDown()
        {
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            Models = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
            Colors = new SelectList(await _context.CarColors.ToListAsync(), "Id", "Name");
        }
    }
}
