using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using NetTopologySuite.Geometries;
using PonderingProgrammer.NtsToSvg;
using Svg;

namespace PonderingProgrammer.NtsToSvgSample.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public string Svg { get; set; }

        public void OnGet()
        {
            var factory = new GeometryFactory();
            var poly = factory.CreatePolygon(new Coordinate[]
            {
                new Coordinate(0, 0), new Coordinate(100, 100), new Coordinate(200, 0), new Coordinate(0, 0)
            });
            var line = factory.CreateLineString(new Coordinate[]
            {
                new Coordinate(50, 50), new Coordinate(200, 50), new Coordinate(150, 100),
            });
            
            var svg = new SvgDocument();
            svg.Children.Add(Mapper.Map(poly));
            svg.Children.Add(Mapper.Map(line));
            Svg = svg.GetHtml();
        }
    }
}
