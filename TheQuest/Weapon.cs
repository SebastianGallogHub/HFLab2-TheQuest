using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace TheQuest
{
    abstract class Weapon: Mover
    {
        public bool PickedUp { get; private set; }

        public Weapon (Game game,Point location ):base(game,location)
        {
            PickedUp = false;
        }

        public abstract string Name { get; }

        public abstract void Attack(Direction direction, Random random);

        protected bool DamageEnemy(Direction direction, int radius, int damage, Random random)
        {
            Point target = game.PlayerLocation;
            for (int distance = 0; distance < radius; distance++)
                foreach (Enemy enemy in game.Enemies)
                    if(Nearby(enemy.Location,target,distance))
                    {
                        enemy.Hit(damage, random);
                        return true;
                    }
        }

        public bool Nearby(Point p1, Point p2, int distance)
        {
            //Compara dos puntos y devuelve verdadero si se encuentran a la distancia determinada
            return false;
        }
    }
}
