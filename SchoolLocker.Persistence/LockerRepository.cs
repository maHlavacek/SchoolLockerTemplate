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

        public LockerDTO[] GetLockerOverViewDTOs()
        {
            return _dbContext.Lockers.Select(l => new LockerDTO
            {
                CountBookings = l.Bookings.Count(),
                Number = l.Number,
                From = l.Bookings.OrderByDescending(o => o.From).FirstOrDefault().From,
                To = l.Bookings.OrderByDescending(o => o.From).FirstOrDefault().To
            })
            .OrderBy(o => o.Number)
            .ToArray();
        }
    }
}