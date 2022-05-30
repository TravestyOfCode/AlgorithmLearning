using System;

namespace AlgorithmLearning.Application.Searches
{
    public static class BinarySearch
    {
        private static readonly string[] menu =
        {
            "Binary Search",
            "A search algorithm that locates the position of a value within a sorted array by comparing the target to the middle element of the array. If they are not equal, the half in which the target cannot be in is eliminated and the search repeats on the remaining half, until the target value is found. If the search ends with the remaining half being empty, the value is not in the array.",
            "",
            "Given the array: { 2, 3, 5, 7, 8, 9, 10 }",
            "Enter the value to locate, or 'Q' to quit."
        };

        private static readonly int[] nums = new int[] { 2, 3, 5, 7, 8, 9, 10 };

        public static string Locate(int target)
        {
            int start = 0;
            int end = nums.Length - 1;
            int mid = (end - start) / 2;

            while (start <= end)
            {
                if (nums[mid] == target)
                    return $"Target '{target}' found at index {mid}";

                if (nums[mid] > target)
                {
                    end = mid - 1;
                }
                else
                {
                    start = mid + 1;
                }

                mid = start + ((end - start) / 2);
            }

            return $"Target '{target}' was not found.";
        }

        public static void Run(MenuBuilder menuBuilder)
        {
            bool quit = false;
            Console.Clear();

            while (!quit)
            {
                Console.WriteLine(menuBuilder.ToString(menu));

                var input = Console.ReadLine();

                if(input.Equals("q", StringComparison.OrdinalIgnoreCase))
                {
                    quit = true;
                }
                else
                {
                    if(int.TryParse(input, out int value))
                    {
                        Console.WriteLine(Locate(value));
                    }
                    else
                    {
                        Console.WriteLine(" is not a valid selection. Please try again.");
                    }
                }
            }
        }
    }
}
