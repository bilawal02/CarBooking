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
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public DeleteModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //private readonly IGenericRepository<CarModel> _repository;
        //public DeleteModel(IGenericRepository<CarModel> repository)
        //{
        //    _repository = repository;
        //}

        private readonly ICarModelRepository _repository;
        public DeleteModel(ICarModelRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carmodel = await _context.CarModels.Include(x => x.CarMaker).FirstOrDefaultAsync(m => m.Id == id);
            var carmodel = await _repository.GetCarModelWithDetails(id.Value);

            if (carmodel == null)
            {
                return NotFound();
            }
            else
            {
                CarModel = carmodel;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carmodel = await _context.CarModels.FindAsync(id);
            var carmodel = await _repository.GetSingleAsync(id.Value);
            if (carmodel != null)
            {
                CarModel = carmodel;
                //_context.CarModels.Remove(CarModel);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(id.Value);
            }

            return RedirectToPage("./Index");
        }
    }
}
