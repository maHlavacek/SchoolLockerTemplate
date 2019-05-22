using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.Contracts.Persistence
{
    public interface ILockerOverViewDTO
    {
        int Number { get; set; }
        int CountBookings { get; set; }

        DateTime From { get; set; }
        DateTime To { get; set; }

    }
}
