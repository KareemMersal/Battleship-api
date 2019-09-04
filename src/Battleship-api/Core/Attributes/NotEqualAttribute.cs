using System.ComponentModel.DataAnnotations;

namespace BattleShip.Api.Core.Attributes
{
    public class NotEqualAttribute : ValidationAttribute
    {
        private string OtherProperty { get; set; }

        public NotEqualAttribute(string otherProperty , string errorMessage) 
            : base(errorMessage)
        {
            OtherProperty = otherProperty;
        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            // get other property value
            var otherPropertyInfo = validationContext.ObjectType.GetProperty(OtherProperty);
            var otherValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance);

            // verify values
            if (value.ToString().Equals(otherValue.ToString()))
                return new ValidationResult(string.Format("{0} should not be equal to {1}.", validationContext.MemberName, OtherProperty));
            else
                return ValidationResult.Success;
        }
    }
}
