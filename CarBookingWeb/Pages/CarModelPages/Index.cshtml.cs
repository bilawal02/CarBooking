using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    //[Authorize]
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //private readonly IGenericRepository<CarModel> _repository;
        //public IndexModel(IGenericRepository<CarModel> repository)
        //{
        //    _repository = repository;
        //}

        private readonly ICarModelRepository _repository;
        public IndexModel(ICarModelRepository repository)
        {
            _repository = repository;
        }

        public IList<CarModel> CarModels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            //CarModels = await _context.CarModels.Include(x=>x.CarMaker).ToListAsync();
            CarModels = await _repository.GetCarModels();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? recordId)
        {
            if (recordId <= 0 || recordId == null)
            {
                return NotFound();
            }
            //var carModel = await _context.CarModels.FindAsync(recordId);
            var carModel = await _repository.GetSingleAsync(recordId.Value);
            if (carModel != null)
            {
                //_context.CarModels.Remove(carModel);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(recordId.Value);
            }
            return RedirectToPage("./Index");
        }
    }
}
