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
    public class DeleteModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public Pupil Pupil { get; set; }
        [BindProperty]
        public int Id { get; set; }

        public DeleteModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet(int id)
        {
            Id = id;
            Pupil = _unitOfWork.PupilRepository.GetPupilById(id);
        }
        public IActionResult OnPostDetailsSelected(int id)
        {
            _unitOfWork.PupilRepository.DeletePupil(id);
            return RedirectToPage("/Pupils/Index");
        }

    }
}