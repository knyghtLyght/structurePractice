using System;

namespace BSTDistance
{
    class Program
    {
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 6, 5, 8, 9, 4, 2, 1 };
            MyTree testTree = new MyTree(testArray[0]);
            for (int i = 1; i < testArray.Length-1; i++)
            {
                testTree.Insert(testTree.Root, testArray[i]);
            }
            Console.WriteLine(testTree.InOrder());
            Console.ReadLine();
            Console.WriteLine(testTree.PreOrder());
            Console.ReadLine();
        }
    }
}
