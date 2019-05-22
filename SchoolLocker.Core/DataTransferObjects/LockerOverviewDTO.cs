using SchoolLocker.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class LockerOverviewDTO : ILockerOverViewDTO
    {
        public int Number { get; set; }
        public int CountBookings { get; set; }
        public DateTime From { get ; set; }
        public DateTime To { get ; set; }
    }
}
