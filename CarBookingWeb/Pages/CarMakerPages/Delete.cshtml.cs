using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingRepository.Contract;

namespace CarBookingWeb.Pages.CarMakerPages
{
    //[Authorize]
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public DeleteModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IGenericRepository<CarMaker> _repository;
        public DeleteModel(IGenericRepository<CarMaker> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public CarMaker CarMaker { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carmaker = await _context.CarMakers.FirstOrDefaultAsync(m => m.Id == id);
            var carmaker = await _repository.GetSingleAsync(id.Value);

            if (carmaker == null)
            {
                return NotFound();
            }
            else
            {
                CarMaker = carmaker;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carmaker = await _context.CarMakers.FindAsync(id);
            var carmaker = await _repository.GetSingleAsync(id.Value);
            if (carmaker != null)
            {
                CarMaker = carmaker;
                //_context.CarMakers.Remove(CarMaker);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
