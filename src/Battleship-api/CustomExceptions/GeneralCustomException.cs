using System;

namespace BattleShip.Api.CustomExceptions
{
    public class GeneralCustomException : Exception
    {
        public string EntityType { get; }
        public string ErrorMessage { get; }
        public GeneralCustomException(string entityType, string errorMessage ,string basErrorMessage) :
            base(basErrorMessage)
        {
            EntityType = entityType;
            ErrorMessage = errorMessage;
        }
    }
}
