using System;
using System.Drawing;

namespace TheQuest
{
    class Bow : Weapon
    {
        private const int radius = 30;
        private const int damage = 1;

        public Bow(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Bow"; } }

        public override void Attack(Direction direction, Random random)
        {
            DamageEnemy(direction, radius, damage, random);
        }
    }
}
