using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.UnitOfWorks
{
    public interface IUnitOfWork : IDisposable
    {
        IBrandRepository BrandRepository { get; }
        IUserRepository UserRepository { get; }
        ICarRepository CarRepository { get; }
        IAccessoryRepository AccessoryRepository { get; }
        IProposalRepository ProposalRepository { get; }
        IEventRepository EventRepository { get; }
        Task SaveAsync();
    }
}
