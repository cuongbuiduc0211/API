using DatabaseAccess.Entities;
using DatabaseAccess.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseAccess.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CarWorldContext _context;
        public UnitOfWork(CarWorldContext context)
        {
            _context = context;
            BrandRepository = new BrandRepository(_context);
            UserRepository = new UserRepository(_context);
            CarRepository = new CarRepository(_context);
            AccessoryRepository = new AccessoryRepository(_context);
            ProposalRepository = new ProposalRepository(_context);
            EventRepository = new EventRepository(_context);
        }
        public IBrandRepository BrandRepository { get; private set; }
        public IUserRepository UserRepository { get; private set; }
        public ICarRepository CarRepository { get; private set; }
        public IAccessoryRepository AccessoryRepository { get; private set; }
        public IProposalRepository ProposalRepository { get; private set; }
        public IEventRepository EventRepository { get; private set; }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
        
     
    }
}
