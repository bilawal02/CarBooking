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
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<CarMaker> _repository;
        public IndexModel(IGenericRepository<CarMaker> repository)
        {
            _repository = repository;
        }

        public IList<CarMaker> CarMaker { get;set; } = default!;

        public async Task OnGetAsync()
        {
            //CarMaker = await _context.CarMakers.ToListAsync();
            CarMaker = await _repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? recordId)
        {
            if (recordId <= 0 || recordId == null)
            {
                return NotFound();
            }
            //var carMaker = await _context.CarMakers.FindAsync(recordId);
            var carMaker = await _repository.GetSingleAsync(recordId.Value);
            if (carMaker != null)
            {
                //_context.CarMakers.Remove(carMaker);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(recordId.Value);
            }
            return RedirectToPage("./Index");
        }
    }
}
