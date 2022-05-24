using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AlgorithmLearning.Application.Searches
{
    public static class Menu
    {
        private readonly static string[] menu =
        {
            "Search Algorithms",
            "These algorithms are used to search collections for criteria. Select an     algorithm below to learn more.",
            "1) Binary Search",
            "2) Breadth First Search",
            "3) Depth First Search",
            "R) Return to Main Menu"
        };

        public static void Run(MenuBuilder menuBuilder)
        {
            bool quit = false;
            Console.Clear();
            
            while (!quit)
            {
                Console.WriteLine(menuBuilder.ToString(menu));

                var key = Console.ReadKey();

                switch(key.Key)
                {
                    case ConsoleKey.R:
                        quit = true;
                        Console.Clear();
                        break;

                    default:
                        Console.WriteLine(" is not a valid selection. Please try again.");
                        break;
                }
            }
        }
    }
}
