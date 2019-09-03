using System;

namespace BattleShip.Api.CustomExceptions
{
    public class InsertFailedException : GeneralCustomException
    {
        public InsertFailedException(string entityType, string errorMessage) :
            base(entityType, errorMessage, $"{entityType} Insert Failed Error")
        {
        }
    }
}
