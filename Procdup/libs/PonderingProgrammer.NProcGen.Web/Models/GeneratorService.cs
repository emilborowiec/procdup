using PonderingProgrammer.Map2d;
using PonderingProgrammer.Map2d.ProcGen;
using PonderingProgrammer.Map2d.ProcGen.BuddingRectangles;
using PonderingProgrammer.Map2d.ProcGen.PackedRectangles;
using PonderingProgrammer.Map2d.ProcGen.PoppingRectangles;

namespace PonderingProgrammer.NProcGen.Web.Models
{
    public class GeneratorService
    {
        private PoppingRectangles _poppingRectangles = new PoppingRectangles();
        private BuddingRectangles _buddingRectangles = new BuddingRectangles();
        private PackedRectangles _packedRectangles = new PackedRectangles();

        public IGridMap GenerateWithPoppingRectangles(PoppingRectanglesGenerationOptions options)
        {
            return _poppingRectangles.Generate(options);
        }

        public IGridMap GenerateWithBuddingRectangles(BuddingRectanglesGenerationOptions options)
        {
            return _buddingRectangles.Generate(options);
        }

        public IGridMap GenerateWithPackedRectangles(PackedRectanglesGenerationOptions options)
        {
            return _packedRectangles.Generate(options);
        }
    }
}
