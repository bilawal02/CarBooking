using CarBookingWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBookingRepository.Contract
{
    public interface ICarModelRepository:IGenericRepository<CarModel>
    {
        Task<List<CarModel>> GetCarModelsByCarMaker(int carMakerId);
        Task<CarModel> GetCarModelWithDetails(int Id);
        Task<List<CarModel>> GetCarModels();
    }
}
