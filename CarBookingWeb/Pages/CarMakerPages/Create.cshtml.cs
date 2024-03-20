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
using CarBookingRepository.Contract;

namespace CarBookingWeb.Pages.CarMakerPages
{
    //[Authorize]
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<CarMaker> _repository;
        public CreateModel(IGenericRepository<CarMaker> repository)
        {
            _repository = repository;
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

            //_context.CarMakers.Add(CarMaker);
            //await _context.SaveChangesAsync();
            await _repository.AddAsync(CarMaker);

            return RedirectToPage("./Index");
        }
    }
}
