using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialDataDropDown();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList Makes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }
            CarModel.CreatedDate = DateTime.Now;
            _context.CarModels.Add(CarModel);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
        private async Task LoadInitialDataDropDown()
        {
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
        }
    }
}
