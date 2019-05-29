using System;
using System.Threading.Tasks;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface IBookingRepository
    {
        Task AddRangeAsync(Booking[] bookings);

        BookingDTO[] GetBookingBetweenDate(int lockerNumber, DateTime from, DateTime to);
    }
}
