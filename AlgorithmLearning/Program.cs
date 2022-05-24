using System;

namespace AlgorithmLearning
{
    class Program
    {
        static readonly string[] Menu =
            {
                "Algorithm Learning",
                "Please select an option below:",
                "1) Searches",
                "Q) Quit"
            };

        static readonly MenuBuilder menuBuilder = new MenuBuilder(80, '#');

        static void Main()
        {
            bool quit = false;

            while(!quit)
            {
                Console.WriteLine(menuBuilder.ToString(Menu));
                var key = Console.ReadKey();

                switch(key.Key)
                {
                    case ConsoleKey.D1:
                        Application.Searches.Menu.Run(menuBuilder);
                        break;
                    case ConsoleKey.Q:
                        quit = true;
                        break;

                    default:
                        Console.WriteLine(" is an invalid selection, please try again.");
                        break;
                }
            }
            
        }
    }
}
