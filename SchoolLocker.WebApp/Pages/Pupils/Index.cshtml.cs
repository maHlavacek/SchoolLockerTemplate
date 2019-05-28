using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;

namespace SchoolLocker.WebApp.Pages.Pupils
{
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public PupilOverViewDTO[] PupilOverViewDTOs { get; private set; }

        public void OnGet()
        {
            ViewData["Message"] = "Index";
            PupilOverViewDTOs = _unitOfWork.PupilRepository.GetPupilOverViewDTOs();
        }
    }
}