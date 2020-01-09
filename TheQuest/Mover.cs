using System;
using System.Drawing;

namespace TheQuest
{
    public enum Direction
    {
        Up,
        Down,
        Left,
        Right
    }

    abstract class Mover
    {
        protected const int MoveInterval = 10;
        protected Point location;
        public Point Location { get { return location; } }
        protected Game game;

        public Mover(Game game, Point location)
        {
            this.game = game;
            this.location = location;
        }

        public bool Nearby(Point locationToCheck, int distance)
        {
            return Nearby(location, locationToCheck, distance);
        }

        public bool Nearby(Point p1, Point p2, int distance)
        {
            return (Math.Abs(p1.X - p2.X) < distance &&
                    Math.Abs(p1.Y - p2.Y) < distance);
        }

        public Point Move(Direction direction, Rectangle boundaries)
        {
            return Move(direction, location, boundaries);
        }

        public Point Move(Direction direction, Point target, Rectangle boundaries)
        {
            Point newLocation = target;
            switch (direction)
            {
                case Direction.Up:
                    if (newLocation.Y - MoveInterval >= boundaries.Top)
                        newLocation.Y -= MoveInterval;
                    break;
                case Direction.Down:
                    if (newLocation.Y + MoveInterval <= boundaries.Top)
                        newLocation.Y += MoveInterval;
                    break;
                case Direction.Left:
                    if (newLocation.X - MoveInterval >= boundaries.Left)
                        newLocation.X -= MoveInterval;
                    break;
                case Direction.Right:
                    if (newLocation.X + MoveInterval <= boundaries.Left)
                        newLocation.X += MoveInterval;
                    break;
                default: break;
            }
            return newLocation;
        }
    }
}
