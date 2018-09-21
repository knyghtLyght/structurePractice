using System;
using System.Collections.Generic;

namespace medianOfArraysLeetCode
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] firstTest = new int[] { 1,3};
            int[] secondtest = new int[] { 2 };
            int[] thirdTest = new int[] { 1, 2 };
            int[] FourTest = new int[] { 3, 4 };

            Console.WriteLine(FindMedianSortedArrays(thirdTest, FourTest));
            Console.ReadLine();
        }
        /// <summary>
        /// Function that calculate the median of two sorted arrays
        /// </summary>
        /// <param name="nums1">Sorted int array</param>
        /// <param name="nums2">Sorted int array</param>
        /// <returns>Returns the median of both arrays as a double</returns>
        public static double FindMedianSortedArrays(int[] nums1, int[] nums2)
        {
            //init our iterators and merged list
            int nums1Iterator = 0;
            int nums2Iterator = 0;
            List<int> mergedList = new List<int>();
            //Set a loop to manage our merge sort. Since they are sorted already it stays simple
            while (nums1Iterator < nums1.Length && nums2Iterator < nums2.Length)
            {
                //Find where the selected element fits
                if (nums1[nums1Iterator] < nums2[nums2Iterator])
                {
                    //Add our selected element
                    mergedList.Add(nums1[nums1Iterator]);
                    //Move our pointer to the next array element
                    nums1Iterator++;
                }
                else
                {
                    mergedList.Add(nums2[nums2Iterator]);
                    nums2Iterator++;
                }
            }
            //If one array runs out faster than the other we just dump the second one on to the end
            while (nums1Iterator < nums1.Length)
            {
                mergedList.Add(nums1[nums1Iterator]);
                nums1Iterator++;
            }
            while (nums2Iterator < nums2.Length)
            {
                mergedList.Add(nums2[nums2Iterator]);
                nums2Iterator++;
            }
            //Check if our total is an even or odd list
            if (mergedList.Count % 2 == 0)
            {
                //If it is even find the two center points and their median
                return (mergedList[mergedList.Count / 2] + mergedList[(mergedList.Count / 2) - 1]) / 2.0;
            }
            else
            {
                //if it is odd simply find the center point an return
                return mergedList[mergedList.Count / 2];
            }
        }
    }
}