using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolLocker.Api.ApiController
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController
    {
        private readonly IUnitOfWork _unitOfWork;

        public BookingsController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<BookingDTO[]> Get(int lockerNumber, DateTime from, DateTime to)
        {
            if (lockerNumber <= 0)
            {
                return new BadRequestResult();
            }
            BookingDTO[] booking = _unitOfWork.BookingRepository.GetBookingBetweenDate(lockerNumber, from, to);
            if (booking == null)
            {
                return new NotFoundResult();
            }

            return booking;
        }
    }
}
