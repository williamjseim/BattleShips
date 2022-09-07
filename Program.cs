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
        }
        void ChooseShip()
        {
            Console.SetCursorPosition(12, 0);
            foreach (string item in ships)
            {
                Console.WriteLine(item);
                Console.CursorLeft = 12;
            }
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
                        ships[i] = "";
                        break;
                }
            }
        }
        void PlacingShip()
        {
            int down = 0;
            int left = 0;
            while (placingShip)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if(down > 0)
                        down--;
                        PrintGrids();
                        grid.PlaceShip(left ,down);
                        break;
                    case ConsoleKey.DownArrow:
                        down++;
                        PrintGrids();
                        grid.PlaceShip(left, down);
                        break;
                    case ConsoleKey.LeftArrow:
                        if(left > 0)
                        left--;
                        PrintGrids();
                        grid.PlaceShip(left, down);
                        break;
                    case ConsoleKey.RightArrow:
                        left++;
                        PrintGrids();
                        grid.PlaceShip(left, down);
                        break;
                    case ConsoleKey.Backspace:
                        placingShip=false;
                        choosingShip=true;
                        PrintGrids();
                        ChooseShip();
                        break;
                    case ConsoleKey.R:
                        grid.RotateShip();
                        PrintGrids();
                        grid.PlaceShip(left,down);
                        break;
                    case ConsoleKey.Enter:
                        placingShip = false;
                        PlaceShip(down,left);
                        break;
                }
                Console.SetCursorPosition(left, down);
            }
        }

        void PlaceShip(int left,int top)
        {
            Console.SetCursorPosition(left,top);
            if (grid.Rotated)
            {
                for (int i = 0; i < (int)grid.Choosen + 1; i++)
                {
                    grid.playerGrid[left++,top].Occupied = true;
                }
            }
            else if (!grid.Rotated)
            {
                for (int i = 0; i < (int)grid.Choosen+1; i++)
                {
                    grid.playerGrid[left, top++].Occupied = true;
                }
            }
            else
            {
                Console.WriteLine("shouldnt be here (placeship)");
            }
            PrintGrids();
            choosingShip = true;
            ChooseShip();
        }
    }
}
