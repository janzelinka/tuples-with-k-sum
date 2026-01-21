using System.Runtime.InteropServices;

namespace Tuples
{
    public class Program
    {
        private static readonly List<int> _items = new List<int>() { 1, -1, 2, -5, 3, 2, 4, 1, 9, -4, 3, -2, 4, 1, 5, 7, 12, -6, 5 };
        public static void Main(string[] args)
        {
            var result = new List<List<int>>();
            GetKTuples(_items, 3, 2);
        }

        public static void GetKTuples(
             List<int> items,
             int targetSum,
             int k)
        {
            var result = new List<List<int>>();
            Backtrack(items, targetSum, k, 0, new List<int>(), result);

            foreach (var tuple in result)
            {
                Console.WriteLine($"({string.Join(", ", tuple)})");
            }
        }

        private static void Backtrack(
            List<int> items,
            int remainingSum,
            int k,
            int startIndex,
            List<int> current,
            List<List<int>> result)
        {
           if (current.Count == k)
            {
                if (remainingSum == 0)
                {
                    result.Add([.. current]);
                }
                return;
            }

           for(var i = startIndex; i < items.Count; i++)
            {
                current.Add(items[i]);
                Backtrack(items, remainingSum - items[i], k, i + 1, current, result);
                current.RemoveAt(current.Count - 1);
            }
        }


    }
}