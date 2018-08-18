using System;

namespace LinkedListAddition
{
    class Program
    {
        /*
        You are given two non-empty linked lists representing two non-negative integers. 
        The digits are stored in reverse order and each of their nodes contain a single digit. 
        Add the two numbers and return it as a linked list.
        You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        Input: (2 -> 4 -> 3) + (5 -> 6 -> 4)
        Output: 7 -> 0 -> 8
        Explanation: 342 + 465 = 807.
        failed test:
        [1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1]
        [5,6,4]
        */
        static void Main(string[] args)
        {
            int[] testArray = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            ListNode llOne = new ListNode(2);
            llOne.next = new ListNode(4);
            llOne.next.next = new ListNode(3);
            ListNode llTwo = new ListNode(5);
            llTwo.next = new ListNode(6);
            llTwo.next.next = new ListNode(4);
            ListNode llLong = new ListNode(1);
            ListNode addRunner = llLong;
            for (int i = 1; i < testArray.Length; i++)
            {
                addRunner.next = new ListNode(testArray[i]);
                addRunner = addRunner.next;
            }
            Console.WriteLine("Expected 708");
            ListNode runner = AddTwoNumbers(llLong, llTwo);
            while (runner != null)
            {
                Console.Write($"{runner.val}");
                runner = runner.next;
            }
            Console.ReadLine();
        }

        public static ListNode AddTwoNumbers(ListNode l1, ListNode l2)
        {
            //Setup variables
            string lOneString = "";
            string lTwoString = "";
            //parse the linked lists into strings
            while (l1 != null)
            {
                lOneString = $"{l1.val}{lOneString}";
                l1 = l1.next;
            }
            while (l2 != null)
            {
                lTwoString = $"{l2.val}{lTwoString}";
                l2 = l2.next;
            }
            //Parse the strings into ints then into a sum
            ulong longtest = ulong.Parse(lOneString);
            ulong total = longtest + ulong.Parse(lTwoString);
            //Covert the int sum into a string to then covert it back into linked lists
            string sTotal = total.ToString();
            //Setup our answer list
            ListNode lA = new ListNode(int.Parse(sTotal[sTotal.Length-1].ToString()));
            //Setup a runner to pass new values into our answer list
            ListNode runner = lA;
            for (int i = sTotal.Length-2; i >= 0; i--)
            {
                runner.next = new ListNode(int.Parse(sTotal[i].ToString()));
                runner = runner.next;
            }
            return lA;
        }
    }

    public class ListNode
    {
        public int val;
        public ListNode next;
        public ListNode(int x) { val = x; }
    }

}
