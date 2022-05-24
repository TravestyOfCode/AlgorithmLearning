namespace AlgorithmLearning.Application.Searches
{
    public static class BinarySearch
    {
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
    }
}
