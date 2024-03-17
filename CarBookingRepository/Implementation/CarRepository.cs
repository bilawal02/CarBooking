using CarBookingRepository.Contract;
using CarBookingWeb.DataContext;
using CarBookingWeb.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Implementation
{
    public class CarRepository : GenericRepository<Car>, ICarRepository
    {
        private readonly ApplicationDbContext _context;

        public CarRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Car>> GetCarsWithDetails()
        {
            var cars = await _context.Cars.Include(x => x.CarMaker).Include(x => x.CarColor).Include(x => x.CarModel).ToListAsync();
            return cars;
        }

        public async Task<Car> GetCarWithDetails(int id)
        {
            var car = await _context.Cars.Include(x => x.CarMaker).Include(x => x.CarModel).Include(x => x.CarColor).FirstOrDefaultAsync(x => x.Id == id);
            return car;
        }

        public async Task<bool> IsLicensePlateExists(string plateNo)
        {
            return await _context.Cars.AnyAsync(x=>x.LicensePlateNumber.ToLower().Trim() ==  plateNo.ToLower().Trim());
        }
    }
}
