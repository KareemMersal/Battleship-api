using System;

namespace BattleShip.Api.CustomExceptions
{
    public class InvalidDataException : GeneralCustomException
    {
        public InvalidDataException(
            string entityType, 
            string errorMessage) :
            base(entityType , errorMessage , "Invalid Data Exception")
        {
        }
    }
}
