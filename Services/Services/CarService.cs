using AutoMapper;
using DatabaseAccess.Entities;
using DatabaseAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Models;

namespace Services.Services
{
    public class CarService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public CarService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateNewCar(CarItem carItem)
        {
            Car existedCar = await _unitOfWork.CarRepository.GetFirstOrDefault(
                                                q => q.Name.ToLower().Equals(carItem.Name));
            if (existedCar != null)
            {
                return false;
            }
            else
            {
                Car newCar = _mapper.Map<Car>(carItem);
                Brand carBrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(
                                                    q => q.Name == carItem.Name);
                newCar.BrandId = carBrand.Id;
                newCar.CreatedDate = DateTime.UtcNow;
                newCar.IsDeleted = false;
                await _unitOfWork.CarRepository.Add(newCar);
                await _unitOfWork.SaveAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Car>> GetAllCars()
        {
            return await _unitOfWork.CarRepository.GetAll(null, o => o.OrderBy(s => s.Name), "Brand");
        }

        public async Task<Car> GetCarById(int id)
        {
            return await _unitOfWork.CarRepository.GetFirstOrDefault(q => q.Id == id, "Brand");
        }

        public async Task<IEnumerable<Car>> GetCarByName(string carName)
        {
            return await _unitOfWork.CarRepository.GetAll(q => q.Name.Contains(carName),
                                                            o => o.OrderBy(s => s.Name), "Brand");
        }

        public async Task<bool> UpdateCar(int id, CarItem carItem)
        {
            Car existedCar = await _unitOfWork.CarRepository.Get(id);
            if (existedCar != null)
            {
                existedCar = _mapper.Map<CarItem, Car>(carItem);
                Brand carBrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(
                                                    q => q.Name == carItem.Name);
                existedCar.BrandId = carBrand.Id;
                existedCar.Id = id;
                _unitOfWork.CarRepository.Update(existedCar);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveCar(int id)
        {
            Car car = await _unitOfWork.CarRepository.Get(id);
            if (car != null)
            {
                car.IsDeleted = true;
                _unitOfWork.CarRepository.Update(car);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
