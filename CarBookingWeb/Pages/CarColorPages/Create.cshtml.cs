using CarBookingModels.Models;
using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CarBookingWeb.Pages.CarColorPages
{
    public class CreateModel : PageModel
    {
        //private readonly ApplicationDbContext _context;
        //public CreateModel(ApplicationDbContext context)
        //{
        //    _context = context;
        //}
        private readonly IGenericRepository<CarColor> _repository;
        public CreateModel(IGenericRepository<CarColor> repository)
        {
            _repository = repository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public CarColor CarColor { get; set; } = default!;

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            CarColor.CreatedDate = DateTime.Now;
            //_context.CarColors.Add(CarColor);
            //await _context.SaveChangesAsync();

            await _repository.AddAsync(CarColor);

            return RedirectToPage("./Index");
        }
    }
}
