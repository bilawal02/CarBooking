using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class IndexModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public IndexModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        //private readonly IGenericRepository<Car> _repository;
        //public IndexModel(IGenericRepository<Car> repository)
        //{
        //    _repository = repository;
        //}

        private readonly ICarRepository _repository;
        public IndexModel(ICarRepository repository)
        {
            _repository = repository;
        }

        public IList<Car> Cars { get; set; }


        public async Task OnGetAsync()
        {
            //Cars = await _context.Cars.Include(x=>x.CarMaker).Include(x => x.CarColor).Include(x => x.CarModel).ToListAsync();
            //Cars = await _context.Cars.ToListAsync();
            Cars = await _repository.GetCarsWithDetails();
        }

        //[HttpPost]
        //public async Task<IActionResult> OnPostDelete(int? carId)
        //{
        //    if (carId == null)
        //    {
        //        return NotFound();
        //    }
        //    var car = await _context.Cars.FindAsync(carId);
        //    if (car != null)
        //    {
        //        _context.Cars.Remove(car);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToPage("/CarPages/Index");
        //}

        //[HttpPost]
        //public async Task<IActionResult> OnPostDelete(int? carId)
        //{
        //    if (carId <= 0 || carId == null)
        //    {
        //        return NotFound();
        //    }
        //    var car = await _context.Cars.FindAsync(carId);
        //    if (car != null)
        //    {
        //        _context.Cars.Remove(car);
        //        await _context.SaveChangesAsync();
        //    }
        //    return RedirectToPage("./Index");
        //}

        [HttpPost]
        public async Task<IActionResult> OnPostDelete(int? recordId)
        {
            if (recordId <= 0 || recordId == null)
            {
                return NotFound();
            }
            //var car = await _context.Cars.FindAsync(recordId);
            var car = await _repository.GetSingleAsync(recordId.Value);
            if (car != null)
            {
                //_context.Cars.Remove(car);
                //await _context.SaveChangesAsync();

                await _repository.DeleteAsync(recordId.Value);
            }
            return RedirectToPage("./Index");
        }
    }
}
