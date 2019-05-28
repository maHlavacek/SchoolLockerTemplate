using SchoolLocker.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class LockerOverViewDTO : ILockerOverViewDTO
    {
        public int Number { get; set; }
        public int CountBookings { get; set; }
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]

        public DateTime? To { get ; set; }
    }
}
