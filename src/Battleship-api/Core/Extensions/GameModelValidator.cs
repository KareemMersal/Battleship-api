using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using BattleShip.Api.Features;

namespace BattleShip.Api.Core.Extensions
{
    public class GameModelValidatorExt<T> where T : DataModel
    {
        
        public (bool isValid, List<ValidationResult> results) TryValidation(T model)
        {
            var validationResults = new List<ValidationResult>();
            var context = new ValidationContext(model, null, null);
            var isValid = Validator.TryValidateObject(model, context, validationResults, true);
            return (isValid, validationResults);
        }
    }
}
