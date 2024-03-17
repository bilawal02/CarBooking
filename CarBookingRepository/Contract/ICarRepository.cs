using CarBookingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Contract
{
    public interface ICarRepository:IGenericRepository<Car>
    {
        Task<Car> GetCarWithDetails(int id);
        Task<bool> IsLicensePlateExists(string plateNo);
        Task<List<Car>> GetCarsWithDetails();
    }
}
