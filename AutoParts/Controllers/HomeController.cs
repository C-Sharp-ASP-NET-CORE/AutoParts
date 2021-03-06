using AutoParts.Core.Constants;
using AutoParts.Infrastructure.Data;
using AutoParts.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Distributed;
using System.Diagnostics;

namespace AutoParts.Controllers
{
    public class HomeController : BaseController
    {
        private readonly ILogger<HomeController> logger;
        private readonly IDistributedCache cache;
        private readonly IFileService fileService;

        public HomeController(
            ILogger<HomeController> _logger, 
            IDistributedCache _cache,
            IFileService _fileService)
        {
            logger = _logger;
            cache = _cache;
            fileService = _fileService;
        }

        public async Task<IActionResult> Index()
        {
            ViewData[MessageConstant.SuccessMessage] = "Welcome!";

            DateTime dateTime = DateTime.Now;
            var cachedData = await cache.GetStringAsync("cachedTime");

            if (cachedData == null)
            {
                cachedData = dateTime.ToString();
                DistributedCacheEntryOptions cacheOptions = new DistributedCacheEntryOptions()
                {
                    SlidingExpiration = TimeSpan.FromSeconds(20),
                    AbsoluteExpiration = DateTime.Now.AddSeconds(60)
                };

                await cache.SetStringAsync("cachedTime", cachedData, cacheOptions);
            }

            return View(nameof(Index), cachedData);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [HttpGet]
        public IActionResult UploadFile()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadFile(IFormFile file)
        {
            try
            {
                if (file != null && file.Length > 0)
                {
                    using (var stream = new MemoryStream())
                    {
                        await file.CopyToAsync(stream);

                        var fileToSave = new ApplicationFile()
                        {
                            FileName = file.FileName,
                            Content = stream.ToArray()
                        };

                        await fileService.SaveFileAsync(fileToSave);
                    }
                }
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "HemoController/UploadFile");

                TempData[MessageConstant.ErrorMessage] = "Couldn't upload the file";
            }

            TempData[MessageConstant.SuccessMessage] = "File uploaded";

            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}