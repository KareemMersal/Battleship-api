using System;

namespace BattleShip.Api.CustomExceptions
{
    public class DuplicateEntryException : Exception
    {
        private string EntityType { get; }

        public DuplicateEntryException(string entityType, Exception innerException = null) :
            base($"{entityType} Already Exists", innerException)
        {
            EntityType = entityType;
        }
    }
}
