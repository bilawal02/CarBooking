using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Cars { get; set; }
        public SelectList Makes { get; set; }

        [HttpGet]
        public async Task<IActionResult> OnGet()
        {
            await LoadCarMakerDropDown();
            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadCarMakerDropDown();
                return Page();
            }
            await _context.Cars.AddAsync(Cars);
            await _context.SaveChangesAsync();
            return RedirectToPage("/CarPages/Index");
        }
        private async Task LoadCarMakerDropDown()
        {
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
        }
    }
}
