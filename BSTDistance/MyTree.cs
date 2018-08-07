using System;
using System.Collections.Generic;
using System.Text;

namespace BSTDistance
{
    class MyTree
    {
        public Node Root { get; set; }

        //Build the tree

        public MyTree(int root)
        {
            Root = new Node() { Value = root };
        }

        public void Insert(Node node, int value)
        {
            if(value > node.Value)
            {
                if(node.RightChild != null)
                {
                    Insert(node.RightChild, value);
                }
                else
                {
                    node.RightChild = new Node() { Value = value };
                }
            }
            if(value < node.Value)
            {
                if(node.LeftChild != null)
                {
                    Insert(node.LeftChild, value);
                }
                else
                {
                    node.LeftChild = new Node() { Value = value };
                }
            }
        }

        //Traverse the tree

        public string InOrder()
        {
            return InOrdertraversal(Root, "");
        }

        public string InOrdertraversal(Node root, string responseString)
        {
            if (root.LeftChild != null)
            {
                responseString = InOrdertraversal(root.LeftChild, responseString);
            }
            responseString = responseString + root.Value.ToString();
            if (root.RightChild != null)
            {
                responseString = InOrdertraversal(root.RightChild, responseString);
            }
            return responseString;
        }

        public string PreOrder()
        {
            return PreOrdertraversal(Root, "");
        }

        public string PreOrdertraversal(Node root, string responseString)
        {
            responseString = responseString + root.Value.ToString();
            if (root.LeftChild != null)
            {
                responseString = InOrdertraversal(root.LeftChild, responseString);
            }
            if (root.RightChild != null)
            {
                responseString = InOrdertraversal(root.RightChild, responseString);
            }
            return responseString;
        }

        //Find the nodes

        public Node FindNode(Node node, int targetValue)
        {
            //If our input is null or our target return the input
            if (node == null || node.Value == targetValue)
            {
                return node;
            }
            //Because BST we know the structure of our nodes
            if (node.Value > targetValue)
            {
                return FindNode(node.LeftChild, targetValue);
            }
            else
            {
                return FindNode(node.LeftChild, targetValue);
            }
        }

        public int FindDistance(Node node, int targetValue, int currentDistance)
        {
            if (node == null || node.Value == targetValue)
            {
                return currentDistance;
            }
            currentDistance = currentDistance++;
            if (node.Value > targetValue)
            {
                return FindDistance(node.LeftChild, targetValue, currentDistance);
            }
            else
            {
                return FindDistance(node.LeftChild, targetValue, currentDistance);
            }
        }

        public Node FindNodeIteritive(int targetValue)
        {
            Queue<Node> stepQueue = new Queue<Node>();
            stepQueue.Enqueue(Root);
            Node runner = Root;
            while (stepQueue.Peek() != null)
            {
                //If we find what we want return it
                if (runner.Value == targetValue)
                {
                    return runner;
                }
                //If not move add the children to the queue and increment distance
                if (runner.Value > targetValue)
                {
                    stepQueue.Enqueue(runner.LeftChild);
                }
                else
                {
                    stepQueue.Enqueue(runner.RightChild);
                }
                //Drop the checked value
                stepQueue.Dequeue();
                //Set the new value to be checked
                runner = stepQueue.Peek();
            }
            //If we don't find the node in question return null
            return null;
        }

        public Node LCA(Node root, int nodeValue1, int nodeValue2)
        {
            if (root == null)
            {
                return null;
            }
            if (root.Value == nodeValue1 || root.Value == nodeValue2)
            {
                return root;
            }
            Node left = LCA(root.LeftChild, nodeValue1, nodeValue2);
            Node right = LCA(root.RightChild, nodeValue1, nodeValue2);
            if (left != null && right != null)
            {
                return root;
            }
            else
            {
                return (left != null ? left : right);
            }
        }

        public int NodeDistance(int nodeValue1, int nodeValue2)
        {
            Node lca = LCA(Root, nodeValue1, nodeValue2);
            return FindDistance(lca, nodeValue1, 0) + FindDistance(lca, nodeValue2, 0);
        }
    }
}
