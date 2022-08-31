using Microsoft.AspNetCore.Mvc;
using TherapistDatabase.Models;
using System.Web;
using System.Net.Http.Headers;

namespace TherapistDatabase.Controllers
{
    public class ProviderController : Controller
    {
        private readonly IProviderRepository repo;

        public ProviderController(IProviderRepository repo)
        {
            this.repo = repo;
        }

        public IActionResult Index() => View(repo.GetAllProviders());

        public IActionResult AddProvider() => View(new Provider());

        public IActionResult ViewProvider(int id)
        {
            var provider = repo.GetProvider(id);
            if(provider == null) return View("ProviderNotFound");
            return View(provider);
        }
                
        public IActionResult AddProviderToDatabase(Provider p, List<IFormFile> files)
        {
            
            /* TODO: Add checking for file size, remove the stuff about multiple files, check if img is already in images directory before
             *       copying, etc.  Same on UpdateProviderToDatabase below.
             */
            long size = files.Sum(f => f.Length);
            var filePaths = new List<string>();
            foreach(var formFile in files) {
                if(formFile.Length > 0) {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);
                    filePaths.Add(filePath);
                    using(var stream = new FileStream(filePath, FileMode.Create)) {
                        formFile.CopyTo(stream);                         //copy file to images directory using windows conventions
                        p.PhotoPath = $"~/images/{formFile.FileName}";   //send file path info to db--stored with unix notation for display via html
                    }

                }
            }

            repo.AddProvider(p);
            return RedirectToAction("Index");
        }

        public IActionResult DeleteProvider(int id)
        {
            repo.DeleteProvider(id);
            return RedirectToAction("Index");
        }

        public IActionResult UpdateProvider(int id)
        {
            var p = repo.GetProvider(id);
            if(p == null) return View("ProviderNotFound");
            return View(p);
        }

        public IActionResult UpdateProviderToDatabase(Provider p, List<IFormFile> files)
        {
            long size = files.Sum(f => f.Length);
            var filePaths = new List<string>();
            foreach(var formFile in files) {
                if(formFile.Length > 0) {
                    var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", formFile.FileName);
                    filePaths.Add(filePath);
                    using(var stream = new FileStream(filePath, FileMode.Create)) {
                        formFile.CopyTo(stream);                        //copy file to images directory using windows conventions
                        p.PhotoPath = $"~/images/{formFile.FileName}";   //send file path info to db--stored with unix notation for display via html
                    }

                }
            }
            repo.UpdateProvider(p);
            return RedirectToAction("ViewProvider", new { id = p.EmployeeID });
        }
    }
}
