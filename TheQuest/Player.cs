using System;
using System.Collections.Generic;
using System.Drawing;

namespace TheQuest
{
    class Player : Mover
    {
        private Weapon equipedWeapon;

        public int HitPoints { get; private set; }

        private List<Weapon> inventory = new List<Weapon>();
        public IEnumerable<string> Weapons
        {
            get
            {
                List<string> names = new List<string>();
                foreach (Weapon weapon in inventory)
                    names.Add(weapon.Name);
                return names;
            }
        }

        public Player(Game game, Point location) : base(game, location)
        {
            HitPoints = 10;
        }

        public void Hit(int maxDamage, Random random)
        {
            HitPoints -= random.Next(1, maxDamage);
        }

        public void IncreaseHealth(int health, Random random)
        {
            HitPoints += random.Next(1, health);
        }

        public void Equip(string weaponName)
        {
            foreach (Weapon weapon in inventory)
                if (weapon.Name == weaponName)
                    equipedWeapon = weapon;
        }

        public void Move(Direction direction)
        {
            location = Move(direction, game.Boundaries);
            if (!game.WeaponInRoom.PickedUp)
            {
                //verificar que esta cerca
                //  levantar el arma en la sala (agregar a inventario)
                //  verificar si es la unica en el inventario
                //      equiparla
                if (Nearby(game.WeaponInRoom.Location, MoveInterval))
                {
                    inventory.Add(game.WeaponInRoom);
                    game.WeaponInRoom.PickUpWeapon();
                    if (inventory.Count == 1)
                        equipedWeapon = game.WeaponInRoom;
                }
            }
        }

        public void Attack(Direction direction, Random random)
        {
            //si no tiene arma equipada sale
            //usa el método attack del arma equipada
            //verificar que es poción (if (this 'is' that))
            //  verificar que fue usada (as potion)
            //      eliminar del inventario y eliminar el arma equipada
            if (equipedWeapon == null) return;
            equipedWeapon.Attack(direction, random);
            if (equipedWeapon is IPotion)
            {
                IPotion potion = equipedWeapon as IPotion;
                if (potion.Used)
                {
                    inventory.Remove(equipedWeapon);
                    equipedWeapon = null;
                }
            }
        }

    }
}
