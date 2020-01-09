using System;
using System.Drawing;

namespace TheQuest
{
    class Ghost : Enemy
    {
        public Ghost(Game game, Point location) : base(game, location, 8) { }

        public override void Move(Random random)
        {
            if (HitPoints < 1) return;
            int option = random.Next(1, 3);
            if (option == 1)
                Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            if (NearPlayer())
                game.HitPlayer(3, random);
        }
    }
}
