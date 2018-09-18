using System;

namespace LeetCodeReverseInt
{
    //Given a 32-bit signed integer, reverse digits of an integer.
    class Program
    {
        static void Main(string[] args)
        {
            int firstTest = 132;
            int secondTest = -132;
            int thirdTest = 1534236469;

            Console.WriteLine(ReversInt(firstTest));
            Console.ReadLine();
            Console.WriteLine(ReversInt(secondTest));
            Console.ReadLine();
            Console.WriteLine(ReversInt(thirdTest));
            Console.ReadLine();
        }

        //Blind method
        public static int ReversInt(int input)
        {
            //Convert input to a string so we can manipulate it as an array
            string inputString = input.ToString();
            //init our output string
            string outputString = "";
            //Set our loop to pull the last digit and put it in front of our output string
            for (int i = inputString.Length - 1; i >= 0; i--)
            {
                if (inputString[i].ToString() == "-")
                {
                    outputString = inputString[i].ToString() + outputString;
                }
                else
                {
                    outputString = outputString + inputString[i].ToString();
                }
            }
            int answerInt;
            //Try to parse the string into an int
            bool canParse = int.TryParse(outputString, out answerInt);
            //If successful return int if not return 0
            if (canParse)
            {
                return answerInt;
            }
            else
            {
                return 0;
            }
        }

       //Researched method
       public static int BetterReverse(int input)
        {
            int answerInt = 0;
            while (input != 0)
            {
                //Pull off our last digit using mod 10
                int step = input % 10;
                //Reduce our input
                input /= 10;
                //If our answer is greater than the int max / 10 it will overflow
                //If our answer is = to our max value and our step value is > 7 it will also overflow
                if (answerInt > int.MaxValue / 10 || (answerInt == int.MaxValue / 10 && step > 7)) return 0;
                //Same logic for the negative side
                if (answerInt < int.MinValue / 10 || (answerInt == int.MinValue / 10 && step > -8)) return 0;
                //Add our step value to our answer value
                answerInt = answerInt * 10 + step;
            }
            return answerInt;
        }
    }
}
