using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarColorPages
{
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<CarColor> _repository;
        public IndexModel(IGenericRepository<CarColor> repository)
        {
            _repository = repository;
        }

        public IList<CarColor> CarColors { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //CarColors = await _context.CarColors.ToListAsync();
            CarColors = await _repository.GetAllAsync();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? recordId)
        {
            if (recordId <= 0 || recordId == null)
            {
                return NotFound();
            }
            //var carColor = await _context.CarColors.FindAsync(recordId);
            var carColor = await _repository.GetSingleAsync(recordId.Value);
            if (carColor != null)
            {
                //_context.CarColors.Remove(carColor);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(recordId.Value);
            }
            return RedirectToPage("./Index");
        }
    }
}
