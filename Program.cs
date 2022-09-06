namespace BattleShips
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Program program = new Program();
            Grid[,] playerGrid = new Grid[10, 10];
            Grid[,] enemyGrid = new Grid[10, 10];
            for (int i = 0; i < playerGrid.GetLength(0); i++)
            {
                for (int j = 0; j < playerGrid.GetLength(1); j++)
                {
                    Console.Write("#");
                }
                Console.Write("\n");
            }
            Console.SetBufferSize(150, 150);
            program.ChooseShip();
            program.CursorMover();
        }
        void ChooseShip()
        {
            string[] ships = { "HangarShip", "BattleShip", "Destroyer", "Uboat", "Scoutboat" };
            Console.SetCursorPosition(12, 0);
            foreach (string item in ships)
            {
                Console.WriteLine(item);
                Console.CursorLeft = 12;
            }
            int i = 0;
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.DownArrow:
                        if (i < ships.Length - 1)
                        {
                            i++;
                            Console.SetCursorPosition(ships[i].Length, i);
                        }
                        break;
                    case ConsoleKey.UpArrow:
                        if (i > 0)
                        {
                            i--;
                            Console.SetCursorPosition(ships[i].Length, i);
                        }
                        break;
                }

        }
        void CursorMover()
        {
            int down = 0;
            int left = 0;
            while (true)
            {
                switch (Console.ReadKey().Key)
                {
                    case ConsoleKey.UpArrow:
                        if(down > 0)
                        down--;
                        break;
                    case ConsoleKey.DownArrow:
                        down++;
                        break;
                    case ConsoleKey.LeftArrow:
                        if(left > 0)
                        left--;
                        break;
                    case ConsoleKey.RightArrow:
                        left++;
                        break;
                }
                Console.SetCursorPosition(left, down);
            }
        }
    }
}