using AutoParts.Core.Models.Part;
using AutoParts.Infrastructure.Data;
using AutoParts.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace AutoParts.Controllers
{
    public class PartsController : Controller
    {
        private readonly AutoPartsDbContext data;

        public PartsController(AutoPartsDbContext _data)
        {
            data= _data;
        }
        public IActionResult Add()
        {
            return View(new AddPartFormModel
            {
                Categories = this.GetPartCategories()
            });
        }

        [HttpPost]
        public IActionResult Add(AddPartFormModel part)
        {
            if (!ModelState.IsValid)
            {
                part.Categories = this.GetPartCategories();
                return View(part);
            }

            return RedirectToAction("Index", "Home");
        }

        private IEnumerable<PartCategoryViewModel> GetPartCategories()
            => data.Categories
                  .Select(c => new PartCategoryViewModel
                  {
                      Id = c.Id,
                      Name = c.Name
                  })
                  .ToList();
    }
}
