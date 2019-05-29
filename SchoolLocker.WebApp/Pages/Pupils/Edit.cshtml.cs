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
    public class EditModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;
        [BindProperty]
        public Pupil Pupil { get; set; }

        public EditModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Pupil = _unitOfWork.PupilRepository.GetPupilById(id);
        }
        public IActionResult OnPostEdit()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            _unitOfWork.PupilRepository.ChangePupil(Pupil);
            return RedirectToPage("/Pupils/Index");
        }

    }
}