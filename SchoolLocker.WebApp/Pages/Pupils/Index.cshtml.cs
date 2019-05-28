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
    public class IndexModel : PageModel
    {
        private readonly IUnitOfWork _unitOfWork;

        public IndexModel(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Pupil[] Pupils { get; private set; }

        public void OnGet()
        {
            ViewData["Message"] = "Index";
            Pupils = _unitOfWork.PupilRepository.GetPupils();
        }
        public IActionResult OnPostDeleteSelected(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Pupils/Delete", new { id = Id });
        }

        public IActionResult OnPostDetailsSelected(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Pupils/Details", new { id = Id });
        }
        public IActionResult OnPostEditSelected(int Id)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }
            return RedirectToPage("/Pupils/Edit", new { id = Id });
        }
    }
}