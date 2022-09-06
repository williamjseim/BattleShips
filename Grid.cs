using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
enum Ships : int
{
    uboat = 1,
    scoutboat = 2,
    destroyer = 3,
    battleship = 4,
    hangarship = 5,
}
namespace BattleShips
{
    internal class Grid
    {
        protected internal Square[,] playerGrid = new Square[10,10];
        protected internal Square[,] enemyGrid = new Square[10,10];
        private bool rotated = false;
        Ships choosen;

        protected internal void ChooseShip(int i)
        {
            choosen = (Ships)i;
        }

        protected internal void PlaceShip(int left,int top)
        {
            Console.SetCursorPosition(left, top);
            if(!rotated)
            {
                for (int j = 0; j < (int)(choosen)+1; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                }
            }
            else if (rotated)
            {
                for (int j = 0; j < (int)(choosen) + 1; j++)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("#");
                    Console.SetCursorPosition(left, top++);
                }
            }
            Console.ForegroundColor = ConsoleColor.White;
        }

        protected internal void RotateShip()
        {
            rotated = !rotated;
        }

    }
}
