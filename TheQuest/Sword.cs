using System;
using System.Drawing;

namespace TheQuest
{
    class Sword : Weapon
    {
        private const int radius = 10;
        private const int damage = 3;

        public Sword(Game game, Point location) : base(game, location) { }

        public override string Name { get { return "Sword"; } }

        public override void Attack(Direction direction, Random random)
        {
            switch (direction)
            {
                case Direction.Up:
                    if (!DamageEnemy(direction, radius, damage, random))
                        if (!DamageEnemy(Direction.Right, radius, damage, random))
                            DamageEnemy(Direction.Left, radius, damage, random);
                    break;
                case Direction.Down:
                    if (!DamageEnemy(direction, radius, damage, random))
                        if (!DamageEnemy(Direction.Left, radius, damage, random))
                            DamageEnemy(Direction.Right, radius, damage, random);
                    break;
                case Direction.Left:
                    if (!DamageEnemy(direction, radius, damage, random))
                        if (!DamageEnemy(Direction.Up, radius, damage, random))
                            DamageEnemy(Direction.Down, radius, damage, random);
                    break;
                case Direction.Right:
                    if (!DamageEnemy(direction, radius, damage, random))
                        if (!DamageEnemy(Direction.Down, radius, damage, random))
                            DamageEnemy(Direction.Up, radius, damage, random);
                    break;
                default:
                    break;
            }
        }
    }
}
