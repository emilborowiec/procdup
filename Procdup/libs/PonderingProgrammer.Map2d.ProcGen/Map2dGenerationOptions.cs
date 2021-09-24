using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Map2d.ProcGen
{
    public class Map2dGenerationOptions
    {
        [Range(8, 1024, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Width { get; set; } = 24;
        [Range(8, 1024, ErrorMessage = "Value for {0} must be between {1} and {2}.")]

        public int Height { get; set; } = 24;
        public int Area => Width * Height;
    }
}
