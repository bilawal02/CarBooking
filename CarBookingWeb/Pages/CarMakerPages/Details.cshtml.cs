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
    public class DetailsModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public DetailsModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IGenericRepository<CarMaker> _repository;
        public DetailsModel(IGenericRepository<CarMaker> repository)
        {
            _repository = repository;
        }

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
    }
}
