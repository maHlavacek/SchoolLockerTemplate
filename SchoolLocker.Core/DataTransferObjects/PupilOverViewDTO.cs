using SchoolLocker.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace SchoolLocker.Core.DataTransferObjects
{
    public class PupilOverViewDTO : IPupilOverViewDTO
    {
        [MinLength(2)]
        public string FirstName { get; set; }
        [MinLength(2)]
        public string LastName { get; set; }
    }
}
