using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class DetailsModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public DetailsModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public Car Car { get; set; }
        //public async Task<IActionResult> OnGetAsync(int? carId)
        //{
        //    if (carId == null)
        //    {
        //        return NotFound();
        //    }
        //    //Car = await _context.Cars.FindAsync(carId);
        //    Car = await _context.Cars.Include(x=>x.CarMaker).Include(x => x.CarModel).Include(x => x.CarColor).FirstOrDefaultAsync(x=>x.Id == carId);
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
            //Car = await _context.Cars.FindAsync(id);
            Car = await _context.Cars.Include(x => x.CarMaker).Include(x => x.CarModel).Include(x => x.CarColor).FirstOrDefaultAsync(x => x.Id == id);
            if (Car == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
