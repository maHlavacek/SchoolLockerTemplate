﻿using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    class BookingDTO
    {
        public int LockerNumber { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateTime From { get; set; }
        public DateTime? To { get; set; }
    }
}
