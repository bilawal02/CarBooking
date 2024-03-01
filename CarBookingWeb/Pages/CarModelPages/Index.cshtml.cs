using CarBookingModels.Models;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<CarModel> CarModels { get; set; } = default!;

        public async Task OnGetAsync()
        {
            CarModels = await _context.CarModels.Include(x=>x.CarMaker).ToListAsync();
        }
    }
}
