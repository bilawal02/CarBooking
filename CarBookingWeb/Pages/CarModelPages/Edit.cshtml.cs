using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public EditModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList Makes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var carmodel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);
            if (carmodel == null)
            {
                return NotFound();
            }
            CarModel = carmodel;
            await LoadInitialDataDropDown();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }

            _context.Attach(CarModel).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CarMakerExists(CarModel.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            return RedirectToPage("./Index");
        }

        private bool CarMakerExists(int id)
        {
            return _context.CarModels.Any(e => e.Id == id);
        }

        private async Task LoadInitialDataDropDown()
        {
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
        }
    }
}
