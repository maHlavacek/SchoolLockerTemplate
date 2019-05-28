using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface IPupilOverViewDTO
    {
        string FirstName { get; set; }
        string LastName { get; set; }
    }
}
