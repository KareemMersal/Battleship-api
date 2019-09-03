using System;

namespace BattleShip.Api.CustomExceptions
{
    public class ValidationModelException : GeneralCustomException
    {
        public ValidationModelException(string entityType, string errorMessage) :
                base(entityType, errorMessage, $"{entityType} Validation Error")
        {
        }
    }
}
