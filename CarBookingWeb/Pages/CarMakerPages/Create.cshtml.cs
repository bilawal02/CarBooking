using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;

namespace CarBookingWeb.Pages.CarMakerPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarMaker CarMaker { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarMaker.CreatedDate = DateTime.Now;
            _context.CarMakers.Add(CarMaker);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
