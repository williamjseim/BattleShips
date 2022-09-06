using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum Ships
{
    hangarship,
    battleship,
    destroyer,
    uboat,
    scoutboat
}
namespace BattleShips
{
    internal class Grid
    {
        private bool occupied;

        public bool Occupied
        {
            get { return occupied; }
            set { occupied = value; }
        }

        private Ships occupiedWith;

        public Ships OccupiedWith
        {
            get { return occupiedWith; }
            set { occupiedWith = value; }
        }



        private bool hit;

        public bool Hit
        {
            get { return hit; }
            set { hit = value; }
        }



    }
}
