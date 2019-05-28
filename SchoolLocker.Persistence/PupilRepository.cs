using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using SchoolLocker.Core.Contracts;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Persistence
{
    internal class PupilRepository : IPupilRepository
    {
        private readonly ApplicationDbContext _dbContext;

        public PupilRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public PupilOverViewDTO[] GetPupilOverViewDTOs()
        {
            return _dbContext.Pupils.Select(p => new PupilOverViewDTO
            {
                FirstName = p.FirstName,
                LastName = p.LastName
            }
            ).OrderBy(o => o.LastName)
            .ToArray();
        }
    }
}