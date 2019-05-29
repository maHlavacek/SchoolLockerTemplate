using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.WebApp.Pages.Pupils
{
    public class DetailsModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        public Pupil Pupil { get; set; }

        public DetailsModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Pupil = _unitOfWork.PupilRepository.GetPupilById(id);
        }
    }
}