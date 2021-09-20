using AutoMapper;
using DatabaseAccess.Entities;
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
    public class EventService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        public EventService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<bool> CreateNewEvent(EventItem eventItem)
        {
            User manager = await _unitOfWork.UserRepository.GetFirstOrDefault(
                                               q => q.FullName.Equals(eventItem.Creater));
            Event existedEvent = await _unitOfWork.EventRepository.GetFirstOrDefault(
                                                    q => q.Title.ToLower().Equals(eventItem.Title));
            if (existedEvent != null)
            {
                return false;
            }
            else
            {
                Event newEvent = _mapper.Map<Event>(eventItem);
                newEvent.ManagerId = manager.Id;
                newEvent.Status = (int)EventContestStatus.RegisterTime;
                newEvent.CreatedDate = DateTime.UtcNow;
                await _unitOfWork.EventRepository.Add(newEvent);
                await _unitOfWork.SaveAsync();
                return true;
            }
        }
        public async Task<Event> GetEventById(int id)
        {
            return await _unitOfWork.EventRepository.Get(id);
        }
        public async Task<IEnumerable<Event>> GetRegisteredTimeEvents()
        {
            return await _unitOfWork.EventRepository.GetAll(
                                     q => q.Status == (int)EventContestStatus.RegisterTime);
        }

        public async Task<IEnumerable<Event>> GetOccurTimeEvents()
        {
            return await _unitOfWork.EventRepository.GetAll(
                                     q => q.Status == (int)EventContestStatus.OccurTime);
        }

        public async Task<IEnumerable<Event>> GetEvaluateAndFeedbackTimeEvents()
        {
            return await _unitOfWork.EventRepository.GetAll(
                                     q => q.Status == (int)EventContestStatus.EvaluateAndFeedbackTime);
        }

        public async Task<IEnumerable<Event>> GetFinishedTimeEvents()
        {
            return await _unitOfWork.EventRepository.GetAll(
                                     q => q.Status == (int)EventContestStatus.FinishedTime);
        }

        public async Task<bool> UpdateEvent(int id, EventItem eventItem)
        {
            User manager = await _unitOfWork.UserRepository.GetFirstOrDefault(
                                               q => q.FullName.Equals(eventItem.Editor));
            Event existedEvent = await _unitOfWork.EventRepository.Get(id);
            if (existedEvent != null)
            {
                existedEvent = _mapper.Map<EventItem, Event>(eventItem);
                existedEvent.ModifiedBy = manager.Id;
                existedEvent.ModifiedDate = DateTime.UtcNow;
                existedEvent.Id = id;
                _unitOfWork.EventRepository.Update(existedEvent);
                await _unitOfWork.SaveAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> CancelEvent(int id)
        {
            Event existedEvent = await _unitOfWork.EventRepository.Get(id);
            if (existedEvent != null)
            {
                if (DateTime.UtcNow == existedEvent.EndRegister)
                {
                    if (existedEvent.CurrentParticipants < existedEvent.MinParticipants)
                    {
                        existedEvent.Status = (int)EventContestStatus.Canceled;
                        return true;
                    }
                }
               
            }
            return false;
        }
    }
}
