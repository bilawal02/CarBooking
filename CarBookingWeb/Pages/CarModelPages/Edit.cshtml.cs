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
    public class EditModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public EditModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}

        private readonly IGenericRepository<CarModel> _carModelRepository;
        private readonly IGenericRepository<CarMaker> _carMakerRepository;
        public EditModel(IGenericRepository<CarModel> carModelRepository, IGenericRepository<CarMaker> carMakerRepository)
        {
            _carModelRepository = carModelRepository;
            _carMakerRepository = carMakerRepository;
        }

        [BindProperty]
        public CarModel CarModel { get; set; } = default!;
        public SelectList Makes { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //var carmodel = await _context.CarModels.FirstOrDefaultAsync(m => m.Id == id);
            var carmodel = await _carModelRepository.GetSingleAsync(id.Value);
            if (carmodel == null)
            {
                return NotFound();
            }
            CarModel = carmodel;
            await LoadInitialDataDropDown();
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                await LoadInitialDataDropDown();
                return Page();
            }
            CarModel.CreatedDate = DateTime.Now;
            //_context.Attach(CarModel).State = EntityState.Modified;

            await _carModelRepository.EditAsync(CarModel);

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CarModelExists(CarModel.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
            return RedirectToPage("./Index");
        }

        //private bool CarMakerExists(int id)
        //{
        //    return _context.CarModels.Any(e => e.Id == id);
        //}

        private async Task<bool> CarModelExists(int id)
        {
            return await _carModelRepository.ExistsAsync(id);
        }

        private async Task LoadInitialDataDropDown()
        {
            //Makes = new SelectList(await _context.CarMakers.ToListAsync(), "Id", "Name");
            Makes = new SelectList(await _carMakerRepository.GetAllAsync(), "Id", "Name");
        }
    }
}
