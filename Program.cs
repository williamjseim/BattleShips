namespace BattleShips
{
    internal class Program
    {
        bool placingShip = false;
        bool choosingShip = true;
        Grid grid = new Grid();
        string[] ships = { "Scoutboat", "Uboat", "Destroyer", "BattleShip", "HangarShip", };
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.SetBufferSize(150, 150);
            program.PrintGrids();
            program.ChooseShip();
            program.PlacingShip();
        }
        void PrintGrids()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < grid.playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.playerGrid.GetLength(1); j++)
                {
                    if (grid.playerGrid[i, j].Occupied)
                    {
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("#");
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.White;
                        Console.Write("#");
                    }
                }
                Console.Write("\n");
            }
            Console.SetCursorPosition(12, 0);
            foreach (string item in ships)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(item);
                Console.CursorLeft = 12;
            }
        }
        void ChooseShip()
        {
            Console.SetCursorPosition(12, 0);
            int i = 0;
            Console.SetCursorPosition(ships[i].Length + 12, i);
            while (choosingShip)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (i < ships.Length - 1)
                        {
                            i++;
                            Console.SetCursorPosition(ships[i].Length+12, i);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (i > 0)
                        {
                            i--;
                            Console.SetCursorPosition(ships[i].Length+12, i);
                        }
                        break;
                    case ConsoleKey.Enter:
                        choosingShip = false;
                        grid.ChooseShip(i);
                        Console.SetCursorPosition(0, 0);
                        grid.PlaceShip(Console.CursorLeft, Console.CursorTop);
                        Console.SetCursorPosition(0, 0);
                        placingShip = true;
                        PlacingShip();
                        break;
                }
            }
        }

        void PlacingShip()
        {
            int top = 0;
            int left = 0;
            while (placingShip)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if(top > 0)
                        top--;
                        PrintGrids();
                        grid.PlaceShip(left ,top);
                        break;
                    case ConsoleKey.DownArrow:
                        if(top < 10 - (1 + ((int)grid.Choosen)) && grid.Rotated)
                        {
                            top++;
                        }
                        else if (top < 9&&!grid.Rotated)
                        {
                            top++;
                        }
                        PrintGrids();
                        grid.PlaceShip(left, top);
                        break;
                    case ConsoleKey.LeftArrow:
                        if(left > 0)
                        left--;
                        PrintGrids();
                        grid.PlaceShip(left, top);
                        break;
                    case ConsoleKey.RightArrow:
                        if(left < 10 - (1 + ((int)grid.Choosen)) && !grid.Rotated)
                        {
                            left++;
                        }
                        else if (left < 9&&grid.Rotated)
                        {
                            left++;
                        }
                        PrintGrids();
                        grid.PlaceShip(left, top);
                        break;
                    case ConsoleKey.Backspace:
                        placingShip=false;
                        choosingShip=true;
                        PrintGrids();
                        ChooseShip();
                        break;
                    case ConsoleKey.R:
                        if(grid.Rotated&&left > ((int)grid.Choosen))
                        {
                            left = 10 - (1 + ((int)grid.Choosen));
                        }
                        else if (!grid.Rotated && top > ((int)grid.Choosen))
                        {
                            top = 10 - (1+((int)grid.Choosen));
                        }
                        grid.RotateShip();
                        PrintGrids();
                        grid.PlaceShip(left,top);
                        break;
                    case ConsoleKey.Enter:
                        placingShip = false;
                        PlaceShip(top,left);
                        break;
                }
                Console.SetCursorPosition(left, top);
            }
        }

        void PlaceShip(int left,int top)
        {
            for (int i = 0; i < grid.playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.playerGrid.GetLength(1); j++)
                {
                    if (grid.playerGrid[i,j].OccupiedWith == grid.Choosen)
                    {
                        grid.playerGrid[i,j].Occupied = false;
                    }
                }
            }
            Console.SetCursorPosition(left,top);
            if (grid.Rotated && (int)grid.Choosen + left < 10 && top < 10&& CheckForShips(left,top))
            {
                for (int i = 0; i < (int)grid.Choosen + 1; i++)
                {
                    grid.playerGrid[left,top].OccupiedWith = grid.Choosen;
                    grid.playerGrid[left++,top].Occupied = true;
                }
            }
            else if (!grid.Rotated&&left < 10&& (int)grid.Choosen + top < 10&& CheckForShips(left, top))
            {
                for (int i = 0; i < (int)grid.Choosen+1; i++)
                {
                    grid.playerGrid[left, top].OccupiedWith = grid.Choosen;
                    grid.playerGrid[left, top++].Occupied = true;
                }
            }
            else
            {
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("Error");
                Console.WriteLine("shouldnt be here (placeship)");
                Thread.Sleep(1000);
                Console.SetCursorPosition(5, 15);
                Console.WriteLine("          ");
                Console.WriteLine("                              ");
            }
            PrintGrids();
            choosingShip = true;
            ChooseShip();
        }

        bool CheckForShips(int left,int top)
        {
            if (!grid.Rotated)
            {
                for (int i = 0; i < ((int)grid.Choosen)+1; i++)
                {
                    if(grid.playerGrid[left, top++].Occupied)
                    {
                        return false;
                    }
                }
            }
            else if (grid.Rotated)
            {
                for (int i = 0; i < ((int)grid.Choosen) + 1; i++)
                {
                    if (grid.playerGrid[left++, top].Occupied)
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}
