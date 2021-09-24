using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace PonderingProgrammer.Map2d.ProcGen.PackedRectangles
{
    public class PackedRectanglesGenerationOptions : Map2dGenerationOptions, IValidatableObject
    {
        public int MinRectSize { get; set; } = 4;
        public int MaxRectSize { get; set; } = 12;
        [Required]
        [Range(1, 100)]
        public int RectCount { get; set; } = 20;
        [Required]
        [Range(0, 32)]
        public int CorridorLength { get; set; } = 0;

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (MinRectSize < 1) 
                yield return new ValidationResult("minRectSize must be at least 1", new []{nameof(MinRectSize)});
            if (MaxRectSize > Width/2) 
                yield return new ValidationResult("maxRectSize cannot be greater than area half width", new []{nameof(MaxRectSize)});
            if (MaxRectSize > Height/2) 
                yield return new ValidationResult("maxRectSize cannot be greater than area half height", new []{nameof(MaxRectSize)});
            if (MaxRectSize < MinRectSize) 
                yield return new ValidationResult("maxRectSize cannot be lower than minRectSize", new []{nameof(MaxRectSize)});
        }
    }
}
