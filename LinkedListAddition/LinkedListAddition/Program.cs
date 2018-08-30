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
            //test variables
            int[] testArray = new int[] { 1, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 1 };
            ListNode llOne = new ListNode(2);
            llOne.next = new ListNode(4);
            llOne.next.next = new ListNode(3);
            ListNode llTwo = new ListNode(5);
            llTwo.next = new ListNode(6);
            llTwo.next.next = new ListNode(4);
            ListNode llLong = new ListNode(1);
            ListNode llThree = new ListNode(9);
            llThree.next = new ListNode(9);
            ListNode llFour = new ListNode(1);
            ListNode addRunner = llLong;
            for (int i = 1; i < testArray.Length; i++)
            {
                addRunner.next = new ListNode(testArray[i]);
                addRunner = addRunner.next;
            }
            //test
            ListNode runner = AddTwoNumbers(llThree, llFour);
            //Display
            Console.WriteLine("Expected 708");
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
            int carryOver = 0;
            int startValue = l1.val + l2.val;
            if (startValue >= 10)
            {
                carryOver = 1;
                startValue = startValue - 10;
            }
            else
            {
                carryOver = 0;
            }
            l1 = l1.next;
            l2 = l2.next;
            ListNode lA = new ListNode(startValue);
            if (l1 == null && l2 == null && carryOver > 0)
            {
                lA.next = new ListNode(carryOver);
            }
            ListNode runner = lA;
            while (l1 != null || l2 != null || carryOver ==1)
            {
                int listOneValue;
                int listTwoValue;
                if (l1 == null)
                {
                    listOneValue = 0;
                }
                else
                {
                    listOneValue = l1.val;
                    l1 = l1.next;
                }
                if (l2 == null)
                {
                    listTwoValue = 0;
                }
                else
                {
                    listTwoValue = l2.val;
                    l2 = l2.next;
                }
                int stepValue = listOneValue + listTwoValue;
                stepValue += carryOver;
                ListNode tempNode = lA;
                if (stepValue >= 10)
                {
                    carryOver = 1;
                    runner.next = new ListNode(stepValue-10);
                }
                else
                {
                    carryOver = 0;
                    runner.next = new ListNode(stepValue);
                }
                runner = runner.next;
                //lA.next = tempNode;
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