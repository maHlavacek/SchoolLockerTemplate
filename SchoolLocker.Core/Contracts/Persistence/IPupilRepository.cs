using System.Threading.Tasks;
using SchoolLocker.Core.Contracts.Entities;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface IPupilRepository
    {
        PupilOverViewDTO[] GetPupilOverViewDTOs();

        void AddPupil(PupilOverViewDTO pupil);
    }
}
