using System;
using System.Drawing;

namespace TheQuest
{
    class Bat : Enemy
    {
        public Bat(Game game, Point location) : base(game, location, 6) { }

        public override void Move(Random random)
        {
            if (HitPoints > 1) return;
            int option = random.Next(1, 2);
            Direction direction;
            if (option == 1)
                direction = FindPlayerDirection(game.PlayerLocation);
            else
            {
                Array values = Enum.GetValues(typeof(Direction));
                direction = (Direction)values.GetValue(random.Next(values.Length));
            }
            Move(direction, game.Boundaries);
            if (NearPlayer())
                game.HitPlayer(2, random);
        }
    }
}
