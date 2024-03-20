using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace CarBookingWeb.Pages.CarModelPages
{
    //[Authorize]
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<CarMaker> _carMakerRepository;

        public CreateModel(IGenericRepository<CarModel> carModelRepository, IGenericRepository<CarMaker> carMakerRepository)
        {
            _carModelRepository = carModelRepository;
            _carMakerRepository = carMakerRepository;
        }

        public async Task<IActionResult> OnGet()
        {
            await LoadInitialDataDropDown();
            return Page();
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList Makes { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }
            CarModel.CreatedDate = DateTime.Now;
            //_context.CarModels.Add(CarModel);
            //await _context.SaveChangesAsync();

            await _carModelRepository.AddAsync(CarModel);

            return RedirectToPage("./Index");
        }
        private async Task LoadInitialDataDropDown()
        {
            //Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            Makes = new SelectList(await _carMakerRepository.GetAllAsync(), "Id", "Name");
        }
    }
}
