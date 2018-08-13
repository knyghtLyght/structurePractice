using System;
using System.Collections.Generic;

namespace SCITest
{
    public class Program
    {
        static void Main(string[] args)
        {
            
        }

        public static int CoinCount(int[] coinArray, int targetValue)
        {
            //Sort our array so we know we are starting with our largest denomination
            Array.Sort(coinArray);
            //Declare variables to track our steps and answers
            int remainder = 0;
            int coins = 0;
            //For loop to pass through all our possible coin denomination
            for (int i = coinArray.Length-1; i >= 0; i--)
            {
                //Use modulus to find our remainder
                remainder = targetValue % coinArray[i];
                //Add the number of coins we can fit in our target value
                coins += (targetValue - remainder) / coinArray[i];
                //Set the new target value to our remainder for the next pass through the loop
                targetValue = remainder;
            }
            //If we get through the loop and still have something left we can't give a good answer
            if (targetValue != 0)
            {
                return -1;
            }
            return coins;
        }

        public static List<int[]> tripletsSumZero(int[] inputArray)
        {
            List<int[]> answerList = new List<int[]>();
            HashSet<int[]> setTest = new HashSet<int[]>();
            //For each element in the array...
            for (int i = 0; i < inputArray.Length - 2; i++)
            {
                //Check every other element...
                for (int j = i + 1; j < inputArray.Length - 1; j++)
                {
                    //with every other element
                    for (int k = j + 1; k < inputArray.Length; k++)
                    {
                        //if our combination sums to 0...
                        if (inputArray[i] + inputArray[j] + inputArray[k] == 0)
                        {
                            //Create a new array with our members
                            int[] newTriplet = new int[] { inputArray[i], inputArray[j], inputArray[k] };
                            //sort it to insure the desired order
                            Array.Sort(newTriplet);
                            //Check if it exists in our hash to prevent duplicates
                            if (setTest.Add(newTriplet))
                            {
                                //Add it to our return list
                                answerList.Add(newTriplet);
                            }
                        }
                    }
                }
            }
            return answerList;
        }
    }

    //Node class to define what objects our tree is made of
    public class Node
    {
        public int Value { get; set; }
        public Node LeftChild { get; set; }
        public Node RightChild { get; set; }
    }

    public class MyTree
    {
        public Node Root { get; set; }

        //Build the tree

        public void Insert(int value)
        {
            Node newNode = new Node() { Value = value };
            //If it is the first thing we insert make it the root
            if (Root == null)
            {
                Root = newNode;
            }
            else
            {
                //Setup a queue to insert things in order
                Queue<Node> stepQueue = new Queue<Node>();
                stepQueue.Enqueue(Root);
                Node runner = Root;
                bool inserted = false;
                while (inserted == false)
                {
                    //If either of the children for our current node are empty add our new node.
                    if (runner.LeftChild == null)
                    {
                        runner.LeftChild = newNode;
                        //We made our insert so break the while loop on the next loop
                        inserted = true;
                    }
                    else if (runner.RightChild == null)
                    {
                        runner.RightChild = newNode;
                        inserted = true;
                    }
                    //Add the next nodes to the queue that will be checked
                    if (runner.LeftChild != null)
                    {
                        stepQueue.Enqueue(runner.LeftChild);
                    }
                    if (runner.RightChild != null)
                    {
                        stepQueue.Enqueue(runner.RightChild);
                    }
                    //Move our runner forward in the queue
                    runner = stepQueue.Dequeue();
                }
            }
        }

        //Find the Traversal string

        public string LevelOrderSplitTRaversal()
        {
            //Setup our variables
            string traversalString = "";
            int levelNodes = 0;
            char[] formating = { ' ', ',' };
            //Init our queue to keep track of our place in the tree
            Queue<Node> stepQueue = new Queue<Node>();
            stepQueue.Enqueue(Root);
            while (stepQueue.Count > 0)
            {
                //set the number of nodes in this level
                levelNodes = stepQueue.Count;
                //Init the string that will hold the level values
                string levelString = "";
                while (levelNodes > 0)
                {
                    //Grab our next node from the queue
                    Node currentNode = stepQueue.Dequeue();
                    levelString = $"{levelString} {currentNode.Value},";
                    //Add the next nodes to the queue
                    if (currentNode.LeftChild != null)
                    {
                        stepQueue.Enqueue(currentNode.LeftChild);
                    }
                    if (currentNode.RightChild != null)
                    {
                        stepQueue.Enqueue(currentNode.RightChild);
                    }
                    //Keep track of when we have hit the next level
                    levelNodes--;
                }
                //Format and add the level to the return string
                levelString = levelString.Trim(formating);
                traversalString = $"{traversalString} [{levelString}],";
            }
            //Format and return the string
            traversalString = traversalString.Trim(formating);
            return traversalString;
        }
    }
}
