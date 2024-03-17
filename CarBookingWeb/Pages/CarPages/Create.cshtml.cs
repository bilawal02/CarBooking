using CarBookingModels.Models;
using CarBookingRepository.Contract;
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
        //private readonly ApplicationDbContext _context;
        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        //private readonly IGenericRepository<Car> _carRepository;
        private readonly ICarRepository _carRepository;
        private readonly IGenericRepository<CarMaker> _carMakerRepository;
        private readonly IGenericRepository<CarColor> _carColorRepository;
        //private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly ICarModelRepository _carModelRepository;
        public CreateModel(ICarRepository carRepository, IGenericRepository<CarMaker> carMakerRepository, IGenericRepository<CarColor> carColorRepository, ICarModelRepository carModelRepository)
        {
            _carRepository = carRepository;
            _carMakerRepository = carMakerRepository;
            _carColorRepository = carColorRepository;
            _carModelRepository = carModelRepository;
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
            if (await _carRepository.IsLicensePlateExists(Cars.LicensePlateNumber))
            {
                ModelState.AddModelError(nameof(Cars.LicensePlateNumber), "License Plate Number Already Exists");
            }
            if (!ModelState.IsValid)
            {
                //await LoadCarMakerDropDown();
                //await LoadCarModelDropDown();
                //await LoadCarColorDropDown();
                await LoadInitialDataDropDown();
                return Page();
            }
            Cars.CreatedDate = DateTime.Now;
            //await _context.Cars.AddAsync(Cars);
            //await _context.SaveChangesAsync();

            await _carRepository.AddAsync(Cars);
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
            //Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            //Colors = new SelectList(await _context.CarColors.ToListAsync(), "Id", "Name");

            Makes = new SelectList(await _carMakerRepository.GetAllAsync(), "Id", "Name");
            Colors = new SelectList(await _carColorRepository.GetAllAsync(), "Id", "Name");
        }

        public async Task<IActionResult> OnGetLoadingCarModels(int carMakerId)
        {
            //var carModels=await _context.CarModels.Where(x=>x.CarMakerId == carMakerId).ToListAsync();
            //return new JsonResult(carModels);
            return new JsonResult(await _carModelRepository.GetCarModelsByCarMaker(carMakerId));
        }
    }
}
