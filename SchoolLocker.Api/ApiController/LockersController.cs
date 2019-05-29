using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLocker.Api.ApiController
{
    [Route("api/lockers")]
    [ApiController]
    public class LockersController
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockersController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<int[]> Get()
        {
            return _unitOfWork.LockerRepository.GetLockersIntArray();
        }
    }
}
