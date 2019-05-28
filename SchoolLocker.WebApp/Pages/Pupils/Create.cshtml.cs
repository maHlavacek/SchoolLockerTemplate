using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SchoolLocker.Core.Contracts.Persistence;
using SchoolLocker.Core.DataTransferObjects;
using SchoolLocker.Core.Entities;

namespace SchoolLocker.WebApp.Pages.Pupils
{
    public class CreateModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Pupil Pupil { get; set; }

        public CreateModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public void OnGet()
        {
        }
        public IActionResult OnPostCreate(string firstName, string lastname)
        {
            ViewData["Message"] = "Create";
            Pupil = new Pupil { FirstName = Request.Form["firstName"],
                                LastName = Request.Form["lastName"] };
            if(!ModelState.IsValid)
            {
                return Page();
            }
            _unitOfWork.PupilRepository.AddPupil(Pupil);
            _unitOfWork.SaveChanges();
            return RedirectToPage("/Index");
        }
    }
}