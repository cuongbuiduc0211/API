using AutoMapper;
using DatabaseAccess.Entities;
using DatabaseAccess.UnitOfWorks;
using Google.Apis.Auth.OAuth2;
using Google.Apis.Gmail.v1;
using Google.Apis.Gmail.v1.Data;
using Google.Apis.Services;
using Google.Apis.Util.Store;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Utility.Enum;
using Utility.Models;

namespace Services
{
    public class UserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public UserService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<User> CheckUserLogin(UserAccount userAccount)
        {
            User loginedUser = await _unitOfWork.UserRepository.GetFirstOrDefault(q => q.Email == userAccount.Email, "Role");
            if (loginedUser != null)
            {
                if (loginedUser.Role.Name.Equals("User") && loginedUser.Status == (int)UserStatus.Active)
                {
                    return loginedUser;
                }
            }
            else
            {
                // call api google để check coi là có phải email dc truyền google về hay ko
                User newUser = _mapper.Map<User>(userAccount);
                newUser.RoleId = 3;
                newUser.CreatedDate = DateTime.UtcNow;
                newUser.Status = (int)UserStatus.Active;
                await _unitOfWork.UserRepository.Add(newUser);
                await _unitOfWork.SaveAsync();
                return newUser;
            }
            return null;
        }


        public async Task<User> CheckAdminLogin(AdminAccount adminAccount)
        {
            
            User loginedUser = await _unitOfWork.UserRepository.GetFirstOrDefault(q => q.Username == adminAccount.Username, "Role");
            if (loginedUser != null)
            {
                if ((loginedUser.Role.Name.Equals("Admin") || loginedUser.Role.Name.Equals("Manager")) &&
                    (loginedUser.Status == (int)UserStatus.Active))
                {
                    if (loginedUser.Password.Equals(adminAccount.Password))
                    {
                        return loginedUser;
                    }
                }
            }
            return null;
        }
        //public async Task<bool> LogOut()
        //{

        //}
        public async Task<bool> CreateNewAccount(AdminAccount adminAccount)
        {
            User existedAccount = await _unitOfWork.UserRepository.GetFirstOrDefault(
                                                    q=> q.Username.ToLower().Equals(adminAccount.Username));
            if (existedAccount != null)
            {
                return false;
            }
            else
            {
                User newAccount = _mapper.Map<User>(adminAccount);
                newAccount.CreatedDate = DateTime.UtcNow;
                newAccount.Status = (int)UserStatus.Active;
                await _unitOfWork.UserRepository.Add(newAccount);
                await _unitOfWork.SaveAsync();
                return true;
            }
        }

        
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _unitOfWork.UserRepository.GetAll(q => q.RoleId == (int) UserRole.User,
                                                            o => o.OrderBy(s => s.Email));
        }
        public async Task<IEnumerable<User>> GetAllAdminsAndManagers()
        {
            return await _unitOfWork.UserRepository.GetAll(q => q.RoleId == (int)UserRole.Admin &&
                                    q.RoleId == (int)UserRole.Manager, o => o.OrderBy(s => s.Role.Name));
        }

        public async Task<User> GetUserById(int id)
        {
            return await _unitOfWork.UserRepository.Get(id);
        }

        public async Task<IEnumerable<User>> GetUserByFullName(string fullName)
        {
            return await _unitOfWork.UserRepository.GetAll(q => q.FullName.Contains(fullName),
                                                            o => o.OrderBy(s => s.FullName));
        }

        public async Task<bool> UpdateSelfProfile(int id, SelfProfile selfProfile)
        {
            User existedUser = await _unitOfWork.UserRepository.GetFirstOrDefault(q => q.Id == id);
            if (existedUser != null)
            {
                existedUser = _mapper.Map<SelfProfile, User>(selfProfile);
                existedUser.Id = id;
                _unitOfWork.UserRepository.Update(existedUser);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public async Task<bool> ChangePassword (int id, ChangePassword changePassword)
        {
            User existedUser = await _unitOfWork.UserRepository.GetFirstOrDefault(q => q.Id == id);
            if (existedUser != null)
            {
                if (changePassword.ConfirmedPassword.Equals(changePassword.Password))
                {
                    existedUser = _mapper.Map<ChangePassword, User>(changePassword);
                    existedUser.Id = id;
                    _unitOfWork.UserRepository.Update(existedUser);
                    await _unitOfWork.SaveAsync();
                    return true;
                }
            }
            return false;
            
            
        }

        public async Task<bool> UpdateRole(int id, UserRole userRole)
        {            
            User user = await _unitOfWork.UserRepository.Get(id);
            if (user != null)
            {
                user.RoleId = (int) userRole;
                _unitOfWork.UserRepository.Update(user);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
           
        }

        public async Task<bool> ChangeAccountStatus(int id, UserStatus userStatus)
        {
            User user = await _unitOfWork.UserRepository.Get(id);
            if (user != null)
            {
                user.Status = (int) userStatus;
                _unitOfWork.UserRepository.Update(user);
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
