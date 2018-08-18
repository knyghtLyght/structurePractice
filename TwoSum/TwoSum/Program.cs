using System;
using System.Collections.Generic;
using System.Collections;

namespace TwoSum
{
    class Program
    {
        /*
        Given an array of integers, return indices of the two numbers such that they add up to a specific target.
        You may assume that each input would have exactly one solution, and you may not use the same element twice.
        Given nums = [2, 7, 11, 15], target = 9,
        Because nums[0] + nums[1] = 2 + 7 = 9,
        return [0, 1].
        */
        static void Main(string[] args)
        {
            int[] testValues = new int[] { 2, 7, 11, 15 };
            int target = 9;
            int[] ansValuesBlind = TwoSum(testValues, target);
            int[] ansValuesR = TwoSumR(testValues, target);
            foreach (var item in ansValuesBlind)
            {
                Console.Write($"{item} ");
            }
            Console.WriteLine();
            foreach (var item in ansValuesBlind)
            {
                Console.Write($"{item} ");
            }
            Console.ReadLine();
        }

        //blind solution
        public static int[] TwoSum(int[] nums, int target)
        {
            //for each element in the array
            for (int i = 0; i < nums.Length; i++)
            {
                //Check every other element
                for (int k = 0; k < nums.Length; k++)
                {
                    //Don't check the same element vs itself
                    if (k != i)
                    {
                        //If the elements add up to the target return both indicies as an array
                        if (nums[i] + nums[k] == target)
                        {
                            return new int[] { i, k };
                        }
                    }
                }
            }
            return null;
        }

        //researched solution 
        public static int[] TwoSumR(int[] nums, int target)
        {
            //Create a hastable that will store our elements as keys and their indicies as values
            Hashtable checkSet = new Hashtable();
            for (int i = 0; i < nums.Length; i++)
            {
                //Find what our desired pair would be to reach the target value
                int compliment = target - nums[i];
                //If the compliment is in the hashtable we found our pair
                if (checkSet.ContainsKey(compliment))
                {
                    //Pull the value from the compliment key and return it with the current index
                    return new int[] { int.Parse(checkSet[compliment].ToString()), i };
                }
                //If we didn't find a pair add our element key and index value to the hashtable
                checkSet.Add(nums[i], i);
            }
            //If no pair was found in the input array return null.
            return null;
        }
    }
}
