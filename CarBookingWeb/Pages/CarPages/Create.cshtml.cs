using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarPages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Car Cars { get; set; }
        public SelectList Makes { get; set; }
        public SelectList Colors { get; set; }

        [HttpGet]
        public async Task<IActionResult> OnGet()
        {
            //await LoadCarMakerDropDown();
            //await LoadCarModelDropDown();
            //await LoadCarColorDropDown();
            await LoadInitialDataDropDown();
            return Page();
        }

        [HttpPost]
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                //await LoadCarMakerDropDown();
                //await LoadCarModelDropDown();
                //await LoadCarColorDropDown();
                await LoadInitialDataDropDown();
                return Page();
            }
            Cars.CreatedDate = DateTime.Now;
            await _context.Cars.AddAsync(Cars);
            await _context.SaveChangesAsync();
            return RedirectToPage("/CarPages/Index");
        }

        //private async Task LoadCarMakerDropDown()
        //{
        //    Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
        //}
        //private async Task LoadCarModelDropDown()
        //{
        //    Models = new SelectList(await _context.CarModels.ToListAsync(), "Id", "Name");
        //}
        //private async Task LoadCarColorDropDown()
        //{
        //    Colors = new SelectList(await _context.CarColors.ToListAsync(), "Id", "Name");
        //}

        private async Task LoadInitialDataDropDown()
        {
            Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            Colors = new SelectList(await _context.CarColors.ToListAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnGetLoadingCarModels(int carMakerId)
        {
            var carModels=await _context.CarModels.Where(x=>x.CarMakerId == carMakerId).ToListAsync();
            return new JsonResult(carModels);
        }
    }
}
