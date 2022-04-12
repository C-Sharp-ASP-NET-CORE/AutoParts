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
            data = _data;
        }
        public IActionResult Add()
        {
            return View(new AddPartFormModel
            {
                Categories = this.GetPartCategories()
            });
        }

        public IActionResult All(string brand, string searchTerm)
        {
            var partsQuery = this.data.Parts.AsQueryable();

            if (!string.IsNullOrWhiteSpace(brand))
            {
                partsQuery = partsQuery.Where(p => p.CarBrand == brand);
            }

            if (!string.IsNullOrWhiteSpace(searchTerm))
            {
                partsQuery = partsQuery
                                    .Where(p =>
                                    p.Name.ToLower().Contains(searchTerm.ToLower())
                                    || (p.CarBrand + " " + p.CarModel).ToLower().Contains(searchTerm.ToLower())
                                    || p.Description.ToLower().Contains(searchTerm.ToLower()));
            }

            var totalParts = partsQuery.Count();

            var parts = partsQuery
                                .Skip(1 * AllPartsViewModel.PartsPerPage)
                                .Take(AllPartsViewModel.PartsPerPage)
                                .Select(p => new PartListingViewModel
                                {
                                    Id = p.Id,
                                    Name = p.Name,
                                    CarBrand = p.CarBrand,
                                    CarModel = p.CarModel,
                                    ImageUrl = p.ImageUrl,
                                    Category = p.Category.Name
                                })
                                .ToList();

            var carBrands = this.data.Parts
                                        .Select(p => p.CarBrand)
                                        .Distinct()
                                        .OrderBy(br => br)
                                        .ToList();

            return View(new AllPartsViewModel
            {
                Brands = carBrands,
                Parts = parts,
                SearchTerm = searchTerm,
                TotalParts = totalParts
            });
        }

        [HttpPost]
        public IActionResult Add(AddPartFormModel part)
        {
            if (!this.data.Categories.Any(c => c.Id == part.CategoryId))
            {
                this.ModelState.AddModelError(nameof(part.CategoryId), "Category does not exist");
            }

            if (!ModelState.IsValid)
            {
                part.Categories = this.GetPartCategories();
                return View(part);
            }

            var myPart = new Part
            {
                Name = part.Name,
                SerialNumber = part.SerialNumber,
                Manufacturer = part.Manufacturer,
                CarBrand = part.CarBrand,
                CarModel = part.CarModel,
                Price = decimal.Parse(part.Price),
                Date = DateTime.Parse(part.Date),
                ImageUrl = part.ImageUrl,
                IsUserd = part.IsUserd,
                Description = part.Description,
                CategoryId = part.CategoryId
            };

            this.data.Parts.Add(myPart);
            this.data.SaveChanges();

            return RedirectToAction(nameof(All));
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
