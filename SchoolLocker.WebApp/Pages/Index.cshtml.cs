using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;

namespace SchoolLocker.WebApp.Pages
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public LockerOverViewDTO[] LockerOverViewDTOs { get; set; }

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
            ViewData["Message"] = "Lockers Overview";
            LockerOverViewDTOs = _unitOfWork.LockerRepository.GetLockerOverViewDTOs();
        }
    }
}
