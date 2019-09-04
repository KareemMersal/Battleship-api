using BattleShip.Api.Domain;

namespace BattleShip.Api
{
    public static class Constants
    {
        public static class ApiVersion
        {
            public const string V1 = "v1";
        }

        public class GameShips
        {
            public GameShips()
            {
                Ships[0] = new Ship(4);
                Ships[1] = new Ship(3);
                Ships[2] = new Ship(2);
                Ships[3] = new Ship(2);
            }
            public Ship[] Ships
            {
                get;
            } = new Ship[4];
        }
    }
}
