using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _dbContext;
        private bool _disposed;

        public UnitOfWork()
        {
            _dbContext = new ApplicationDbContext();
            BookingRepository = new BookingRepository(_dbContext);
            LockerRepository = new LockerRepository(_dbContext);
            PupilRepository = new PupilRepository(_dbContext);
        }

        public IBookingRepository BookingRepository { get; }

        public ILockerRepository LockerRepository { get; }
        public IPupilRepository PupilRepository { get; }


        /// <summary>
        ///     Repository-übergreifendes Speichern der Änderungen
        /// </summary>
        public void Save()
        {
            var entities = _dbContext.ChangeTracker.Entries()
               .Where(entity => entity.State == EntityState.Added
                                || entity.State == EntityState.Modified)
               .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }
            _dbContext.SaveChanges();
        }

        public Task<int> SaveChangesAsync()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }
            return _dbContext.SaveChangesAsync();
        }

        /// <summary>
        /// Repository-übergreifendes Speichern der Änderungen
        /// </summary>
        public int SaveChanges()
        {
            var entities = _dbContext.ChangeTracker.Entries()
                .Where(entity => entity.State == EntityState.Added
                                 || entity.State == EntityState.Modified)
                .Select(e => e.Entity);
            foreach (var entity in entities)
            {
                ValidateEntity(entity);
            }

            return _dbContext.SaveChanges();
        }

        /// <summary>
        /// Validierungen auf DbContext-Ebene
        /// </summary>
        /// <param name="entity"></param>
        private void ValidateEntity(object entity)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }
            }
            _disposed = true;
        }

        public void DeleteDatabase()
        {
            _dbContext.Database.EnsureDeleted();
        }

        public void MigrateDatabase()
        {
            _dbContext.Database.Migrate();
        }

    }

   
}
