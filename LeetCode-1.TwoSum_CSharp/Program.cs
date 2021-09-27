using System;
using System.Collections.Generic;

namespace LeetCode_1.TwoSum_CSharp
{
    class Program
    {
        static string ArrayToString(int[] datas)
        {
            string output = "";

            foreach(var data in datas)
            {
                if (output != "")
                    output += ", ";

                output += data.ToString();
            }

            return output;
        }

        static void Main(string[] args)
        {
            Solution s = new Solution();

            int[] nums = { 2, 7, 11, 15 };
            int target = 9;
            int[] results = s.TwoSum(nums, target);

            var input = ArrayToString(nums);
            var output = ArrayToString(results);

            Console.WriteLine($"input: nums:[{input}], target:{target}");
            Console.WriteLine($"output:[{output}]");
        }
    }

    public class Solution
    {
        public int[] TwoSum(int[] nums, int target)
        {
            Dictionary<int, List<int>> numbers = new Dictionary<int, List<int>>();
            for (int i = 0; i < nums.Length; ++i)
            {
                if (!numbers.TryGetValue(nums[i], out List<int> idxs))
                {
                    idxs = new List<int>();
                    numbers[nums[i]] = idxs;
                }

                idxs.Add(i);
            }

            int diff = 0;

            for (int i = 0; i < nums.Length; ++i)
            {
                diff = target - nums[i];

                if (numbers.TryGetValue(diff, out List<int> idxs))
                {
                    foreach (int idx in idxs)
                    {
                        if (i == idx)
                            continue;

                        return new int[] { i, idx };
                    }
                }
            }

            return null;
        }
    }
}
