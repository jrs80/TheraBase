using Microsoft.AspNetCore.Mvc;
using TherapistDatabase.Models;

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
                
        public IActionResult AddProviderToDatabase(Provider p)
        {
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


        public IActionResult UpdateProviderToDatabase(Provider provider)
        {
            repo.UpdateProvider(provider);
            return RedirectToAction("ViewProvider", new { id = provider.EmployeeID });
        }
        
    }
}
