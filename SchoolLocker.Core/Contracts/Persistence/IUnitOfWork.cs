using System;
using System.Threading.Tasks;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface IUnitOfWork: IDisposable
    {


        IPupilRepository PupilRepository { get; }
        IBookingRepository BookingRepository { get; }
        ILockerRepository LockerRepository { get; }

        int SaveChanges();

        Task<int> SaveChangesAsync();

        void DeleteDatabase();

        void MigrateDatabase();
    }
}
