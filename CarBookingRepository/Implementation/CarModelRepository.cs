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
    public class CarModelRepository:GenericRepository<CarModel>,ICarModelRepository
    {
        private readonly ApplicationDbContext _context;

        public CarModelRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<CarModel>> GetCarModels()
        {
            var carModels = await _context.CarModels.Include(x => x.CarMaker).ToListAsync();
            return carModels;
        }

        public async Task<List<CarModel>> GetCarModelsByCarMaker(int carMakerId)
        {
            var carModels = await _context.CarModels.Where(x => x.CarMakerId == carMakerId).ToListAsync();
            return carModels;
        }

        public async Task<CarModel> GetCarModelWithDetails(int Id)
        {
            var carModel = await _context.CarModels.Include(x => x.CarMaker).FirstOrDefaultAsync(m => m.Id == Id);
            return carModel;
        }
    }
}
