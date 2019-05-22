using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    internal class LockerRepository : ILockerRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public LockerRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public LockerOverViewDTO[] GetLockerOverViewDTOs()
        {
            return _dbContext.Lockers.Select(l => new LockerOverViewDTO
            {
                CountBookings = l.Bookings.Count(),
                Number = l.Number,
                From = l.Bookings.FirstOrDefault().From,
                To = l.Bookings.FirstOrDefault().To
            }).ToArray();
        }
    }
}