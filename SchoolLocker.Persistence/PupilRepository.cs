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

        public void AddPupil(Pupil pupil)
        {
            _dbContext.Add(pupil);
            _dbContext.SaveChanges();
        }

        public void ChangePupil(Pupil pupil)
        {
            var pupilToChange = _dbContext.Pupils.Find(pupil.Id);
            if(pupilToChange == null)
            {
                return;
            }
            _dbContext.Entry(pupilToChange).CurrentValues.SetValues(pupil);
            _dbContext.SaveChanges();
        }

        public void DeletePupil(int id)
        {
            var pupil = _dbContext.Pupils.SingleOrDefault(p => p.Id == id);
            _dbContext.Pupils.Remove(pupil);
            _dbContext.SaveChanges();
        }

        public Pupil GetPupilById(int id)
        {
            return _dbContext.Pupils.SingleOrDefault(p => p.Id == id);
        }


        public Pupil[] GetPupils()
        {
            return _dbContext.Pupils.ToArray();
        }
    }
}