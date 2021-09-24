using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PonderingProgrammer.Map2d.ProcGen;
using PonderingProgrammer.Map2d.ProcGen.BuddingRectangles;
using PonderingProgrammer.Map2d.ProcGen.PackedRectangles;
using PonderingProgrammer.Map2d.ProcGen.PoppingRectangles;
using PonderingProgrammer.Map2d.Svg;
using PonderingProgrammer.NProcGen.Web.Models;
using PonderingProgrammer.NtsToSvg;
using Svg;

namespace PonderingProgrammer.NProcGen.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GeneratorService _service = new GeneratorService();
        private readonly Map2dSvgRenderer _renderer = new Map2dSvgRenderer();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View(new MapViewModel());
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult PoppingRectangles()
        {
            return View(new PoppingRectanglesViewModel() { Options = new PoppingRectanglesGenerationOptions() });
        }
        
        public IActionResult BuddingRectangles()
        {
            return View(new BuddingRectanglesViewModel() { Options = new BuddingRectanglesGenerationOptions() });
        }
        
        public IActionResult PackedRectangles()
        {
            return View(new PackedRectanglesViewModel() { Options = new PackedRectanglesGenerationOptions() });
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        public IActionResult GenerateWithPoppingRectangles(PoppingRectanglesGenerationOptions options)
        {
            if (!ModelState.IsValid)
            {
                return View("PoppingRectangles", new PoppingRectanglesViewModel() { Options = options });
            }
            var map = _service.GenerateWithPoppingRectangles(options);
            var svg = _renderer.RenderToSvg(map, MapViewModel.Scale);

            var viewModel = new PoppingRectanglesViewModel() {Options = options, Svg = svg.GetHtml()};
            return View("PoppingRectangles", viewModel);
        }
        
        public IActionResult GenerateWithBuddingRectangles(BuddingRectanglesGenerationOptions options)
        {
            if (!ModelState.IsValid)
            {
                return View("BuddingRectangles", new BuddingRectanglesViewModel() { Options = options });
            }
            var map = _service.GenerateWithBuddingRectangles(options);
            var svg = _renderer.RenderToSvg(map, MapViewModel.Scale);

            var viewModel = new BuddingRectanglesViewModel() {Options = options, Svg = svg.GetHtml()};
            return View("BuddingRectangles", viewModel);
        }
        
        public IActionResult GenerateWithPackedRectangles(PackedRectanglesGenerationOptions options)
        {
            if (!ModelState.IsValid)
            {
                return View("PackedRectangles", new PackedRectanglesViewModel() { Options = options });
            }
            var map = _service.GenerateWithPackedRectangles(options);
            var svg = _renderer.RenderToSvg(map, MapViewModel.Scale);

            var viewModel = new PackedRectanglesViewModel() {Options = options, Svg = svg.GetHtml()};
            return View("PackedRectangles", viewModel);
        }
    }
}
