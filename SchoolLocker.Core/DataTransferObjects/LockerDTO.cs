using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class LockerDTO
    {
        public int CountBookings { get; set; }
        public int Number { get; set; }
        [DataType(DataType.Date)]
        public DateTime From { get; set; }
        [DataType(DataType.Date)]

        public DateTime? To { get; set; }
    }
}
