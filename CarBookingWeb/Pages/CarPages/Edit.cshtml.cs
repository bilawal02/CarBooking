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
    public class EditModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public EditModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<Car> _repository;
        private readonly IGenericRepository<CarMaker> _carMakerRepository;
        private readonly IGenericRepository<CarColor> _carColorRepository;
        public EditModel(IGenericRepository<Car> repository, IGenericRepository<CarMaker> carMakerRepository, IGenericRepository<CarColor> carColorRepository)
        {
            _repository = repository;
            _carMakerRepository = carMakerRepository;
            _carColorRepository = carColorRepository;
        }

        [BindProperty]
        public Car Car { get; set; }
        public SelectList Makes { get; set; }
        public SelectList Colors { get; set; }

        //public async Task<IActionResult> OnGetAsync(int? carId)
        //{
        //    if (carId == null)
        //    {
        //        return NotFound();
        //    }
        //    Car = await _context.Cars.FirstOrDefaultAsync(x=>x.Id == carId);
        //    if (Car==null)
        //    {
        //        return NotFound();
        //    }
        //    await LoadInitialDataDropDown();
        //    return Page();
        //}
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id <= 0 || id == null)
            {
                return NotFound();
            }
            //Car = await _context.Cars.FirstOrDefaultAsync(x => x.Id == id);
            Car = await _repository.GetSingleAsync(id.Value);
            if (Car == null)
            {
                return NotFound();
            }
            await LoadInitialDataDropDown();
            return Page();
        }
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }
            Car.CreatedDate = DateTime.Now;
            //_context.Attach(Car).State = EntityState.Modified;
            //await _context.SaveChangesAsync();

            await _repository.EditAsync(Car);
            return RedirectToPage("/CarPages/Index");
        }
        //private bool carExists(int? id)
        //{
        //    return _context.Cars.Any(x => x.Id == id);
        //}

        private async Task<bool> carExists(int? id)
        {
            return await _repository.ExistsAsync(id.Value);
        }
        private async Task LoadInitialDataDropDown()
        {
            //Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            //Colors = new SelectList(await _context.CarColors.ToListAsync(), "Id", "Name");

            Makes = new SelectList(await _carMakerRepository.GetAllAsync(), "Id", "Name");
            Colors = new SelectList(await _carColorRepository.GetAllAsync(), "Id", "Name");
        }
    }
}
