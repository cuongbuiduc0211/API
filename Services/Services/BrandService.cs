using AutoMapper;
using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
using DatabaseAccess.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Utility.Enum;
using Utility.Models;

namespace Services.Services
{
    public class BrandService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public BrandService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<bool> CreateNewBrand(BrandItem brandItem)//model front end truyền vào
        {
            //entity - database
            Brand existedBrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(
                                                   q => q.Name.ToLower().Equals(brandItem.Name));
            if (existedBrand != null)
            {
                return false; 
            }
            else
            {
                Brand newBrand = _mapper.Map<Brand>(brandItem);
                newBrand.Type = (int) Enum.Parse(typeof(BrandType), brandItem.Type);
                newBrand.CreatedDate = DateTime.UtcNow;
                newBrand.IsDeleted = false;
                await _unitOfWork.BrandRepository.Add(newBrand);
                await _unitOfWork.SaveAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Brand>> GetAllBrandsOfCar()
        {
            return await _unitOfWork.BrandRepository.GetAll(q => q.Type == (int)BrandType.Car,
                                                            o => o.OrderBy(s => s.Name));
        }
        public async Task<IEnumerable<Brand>> GetAllBrandsOfAccessory()
        {
            return await _unitOfWork.BrandRepository.GetAll(q => q.Type == (int)BrandType.Accessory,
                                                            o => o.OrderBy(s => s.Name));
        }
        public async Task<Brand> GetBrandById(int id)
        {
            return await _unitOfWork.BrandRepository.Get(id);
        }

        public async Task<IEnumerable<Brand>> GetBrandByName(string brandName)
        {
            return await _unitOfWork.BrandRepository.GetAll(q => q.Name.Contains(brandName),
                                                            o => o.OrderBy(s => s.Name));
        }

        public async Task<bool> UpdateBrand(int id, BrandItem brandItem)
        {
            Brand existedbrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(q => q.Id == id);
            if (existedbrand != null)
            {
                existedbrand = _mapper.Map<BrandItem, Brand>(brandItem);
                existedbrand.Id = id;
                _unitOfWork.BrandRepository.Update(existedbrand);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> RemoveBrand(int id)
        {
            Brand brand = await _unitOfWork.BrandRepository.Get(id);
            if (brand != null)
            {
                brand.IsDeleted = true; //soft delete
                _unitOfWork.BrandRepository.Update(brand);
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
