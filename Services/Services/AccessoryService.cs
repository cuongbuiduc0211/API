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
    public class AccessoryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public AccessoryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<bool> CreateNewAccessory(AccessoryItem accessoryItem)
        {
            Accessory existedAccessory = await _unitOfWork.AccessoryRepository.GetFirstOrDefault(
                                                            q => q.Name.ToLower().Equals(accessoryItem.Name));
            if (existedAccessory != null)
            {
                return false;
            }else
            {
                Accessory newAccessory = _mapper.Map<Accessory>(accessoryItem);
                Brand accessoryBrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(
                                                         q => q.Name == accessoryItem.BrandName);
                newAccessory.BrandId = accessoryBrand.Id;
                newAccessory.CreatedDate = DateTime.UtcNow;
                newAccessory.IsDeleted = false;
                await _unitOfWork.AccessoryRepository.Add(newAccessory);
                await _unitOfWork.SaveAsync();
                return true;
            }
        }

        public async Task<IEnumerable<Accessory>> GetAllAccessories()
        {
            return await _unitOfWork.AccessoryRepository.GetAll(null, o => o.OrderBy(s => s.Name), "Brand");
        }

        public async Task<Accessory> GetAccessoryById(int id)
        {
            return await _unitOfWork.AccessoryRepository.GetFirstOrDefault(q => q.Id == id, "Brand");
        }

        public async Task<IEnumerable<Accessory>> GetAccessoryByName(string accessoryName)
        {
            return await _unitOfWork.AccessoryRepository.GetAll(q => q.Name.Contains(accessoryName),
                                                                o => o.OrderBy(s => s.Name), "Brand");
        }

        public async Task<bool> UpdateAccessory(int id, AccessoryItem accessoryItem)
        {
            Accessory existedAccessory = await _unitOfWork.AccessoryRepository.Get(id);
            if (existedAccessory != null)
            {
                existedAccessory = _mapper.Map<AccessoryItem, Accessory>(accessoryItem);
                Brand accessoryBrand = await _unitOfWork.BrandRepository.GetFirstOrDefault(
                                                         q => q.Name == accessoryItem.BrandName);
                existedAccessory.BrandId = accessoryBrand.Id;
                existedAccessory.Id = id;
                _unitOfWork.AccessoryRepository.Update(existedAccessory);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public async Task<bool> RemoveAccessory(int id)
        {
            Accessory accessory = await _unitOfWork.AccessoryRepository.Get(id);
            if (accessory != null)
            {
                accessory.IsDeleted = true;
                _unitOfWork.AccessoryRepository.Update(accessory);
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
