using System.Threading.Tasks;
using SchoolLocker.Core.Contracts.Entities;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface IPupilRepository
    {
        void AddPupil(Pupil pupil);
        Pupil GetPupilById(int id);
        void DeletePupil(int id);
        void ChangePupil(Pupil pupil);
        Pupil[] GetPupils();
    }
}
