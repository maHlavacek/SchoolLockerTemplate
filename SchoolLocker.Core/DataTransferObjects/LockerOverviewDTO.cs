using SchoolLocker.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class LockerOverViewDTO : ILockerOverViewDTO
    {
        public int Number { get; set; }
        public int CountBookings { get; set; }
        public string From { get; set; }
        public string To { get ; set; }
    }
}
