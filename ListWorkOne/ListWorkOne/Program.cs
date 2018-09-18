using System;
using System.Collections.Generic;

namespace ListWorkOne
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
        //Given the numTrips and the possibleTrips and coordinateness, Find the shortest numTrips. Return a list of initial coordinateness.
        public List<List<int>> BestTrips(int numTrips,
                                             List<int[,]> coordinateness,
                                             int possibleTrips)
        {

        }

        //Given deviceCapacity find all combinations of optimal foregroundAppList and backgroundAppList.
        //A pair is optimal if their is not another pair that sums to a greater value but is still less than the device capacity
        public List<List<int>> optimalUtilization(int deviceCapacity,
                                             List<List<int>> foregroundAppList,
                                             List<List<int>> backgroundAppList)
        {
            //Set our comparable max
            int max = 0;
            //Make our empty list if we found no applicable results
            List<List<int>> answerList = new List<List<int>>();
            //Check each forgroundApp against each backgroundApp
            for (int i = 0; i < foregroundAppList.Count; i++)
            {
                for (int k = 0; k < backgroundAppList.Count; k++)
                {
                    //If we find a matching pair add it to our list and record its total memory value
                    int memUsage = foregroundAppList[i][1] + backgroundAppList[k][1];
                    if (memUsage <= deviceCapacity)
                    {
                        if (foregroundAppList[i][1] + backgroundAppList[k][1] >= max)
                        {
                            answerList.Add(new List<int> { foregroundAppList[i][0], backgroundAppList[k][0] });
                            max = foregroundAppList[i][1] + backgroundAppList[k][1];
                        }
                    }
                }
            }
            return answerList;
        }
    }
}
