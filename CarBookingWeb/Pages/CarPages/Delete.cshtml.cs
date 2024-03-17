using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class DeleteModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public DeleteModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //private readonly IGenericRepository<Car> _repository;
        //public DeleteModel(IGenericRepository<Car> repository)
        //{
        //    _repository = repository;
        //}

        private readonly ICarRepository _repository;
        public DeleteModel(ICarRepository repository)
        {
            _repository = repository;
        }

        [BindProperty]
        public Car Car { get; set; }

        //public async Task<IActionResult> OnGetAsync(int? carId)
        //{
        //    if (carId == null)
        //    {
        //        return NotFound();
        //    }
        //    Car = await _context.Cars.Include(x=>x.CarMaker).FirstOrDefaultAsync(x=>x.Id == carId);
        //    if (Car == null)
        //    {
        //        return NotFound();
        //    }
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id <= 0 || id == null)
            {
                return NotFound();
            }
            //Car = await _context.Cars.Include(x => x.CarMaker).FirstOrDefaultAsync(x => x.Id == id);
            Car = await _repository.GetCarWithDetails(id.Value);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }

        //public async Task<IActionResult> OnPostAsync(int? carId)
        //{
        //    if (carId == null)
        //    {
        //        return NotFound();
        //    }
        //    Car = await _context.Cars.FindAsync(carId);
        //    if (Car != null)
        //    {
        //        _context.Cars.Remove(Car);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToPage("/CarPages/Index");
        //}
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id <= 0 || id == null)
            {
                return NotFound();
            }
            //Car = await _context.Cars.FindAsync(id);
            Car = await _repository.GetSingleAsync(id.Value);
            if (Car != null)
            {
                //_context.Cars.Remove(Car);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(id.Value);
            }
            return RedirectToPage("./Index");
        }
    }
}
