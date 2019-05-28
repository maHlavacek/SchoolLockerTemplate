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
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public PupilOverViewDTO Pupil { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
           // ViewData["Message"] = "Create";
        }
        public void OnPost(string firstName, string lastname)
        {
            ViewData["Message"] = "Create";
            Pupil = new PupilOverViewDTO { FirstName = firstName, LastName = lastname };
            //_unitOfWork.PupilRepository.AddPupil(new PupilOverViewDTO { FirstName = firstName, LastName = lastname });
        }
    }
}