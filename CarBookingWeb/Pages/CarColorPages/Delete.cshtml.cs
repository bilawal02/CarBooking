using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarColorPages
{
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public DeleteModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IGenericRepository<CarColor> _repository;
        public DeleteModel(IGenericRepository<CarColor> repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public CarColor CarColor { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carcolor = await _context.CarColors.FirstOrDefaultAsync(m => m.Id == id);
            var carcolor = await _repository.GetSingleAsync(id.Value);

            if (carcolor == null)
            {
                return NotFound();
            }
            else
            {
                CarColor = carcolor;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carcolor = await _context.CarColors.FindAsync(id);
            var carcolor = await _repository.GetSingleAsync(id.Value);
            if (carcolor != null)
            {
                CarColor = carcolor;
                //_context.CarColors.Remove(CarColor);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
