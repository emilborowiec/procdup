using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Xunit;

namespace PonderingProgrammer.Map2d.ProcGen.Tests
{
    public class Map2dGenerationOptionsTest
    {
        [Fact]
        public void TestValidation()
        {
            var options = new Map2dGenerationOptions { Width = 8, Height = 128 };
            var context = new ValidationContext(options);
            var validationResults = new List<ValidationResult>();
            Assert.True(Validator.TryValidateObject(options, context, validationResults, true));
            
            options = new Map2dGenerationOptions { Width = 1, Height = 0 };
            context = new ValidationContext(options);
            Assert.False(Validator.TryValidateObject(options, context, validationResults, true));
            Assert.Equal(2, validationResults.Count);
        }
    }
}
