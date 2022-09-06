namespace BattleShips
{
    internal class Program
    {
        bool placingShip = false;
        bool choosingShip = true;
        Grid grid = new Grid();
        static void Main(string[] args)
        {
            Program program = new Program();
            Console.SetBufferSize(150, 150);
            program.PrintGrids();
            program.ChooseShip();
            program.CursorMover();
        }
        void PrintGrids()
        {
            Console.SetCursorPosition(0, 0);
            for (int i = 0; i < grid.playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < grid.playerGrid.GetLength(1); j++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");
            }
        }
        void ChooseShip()
        {
            string[] ships = { "Scoutboat", "Uboat", "Destroyer", "BattleShip", "HangarShip",   };
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
                        CursorMover();
                        break;
                }
            }
        }
        void CursorMover()
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
                }
                Console.SetCursorPosition(left, down);
            }
        }
    }
}
