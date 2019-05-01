using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3___Sorting
{
    class Searching
    {
        public void BinarySearch(double[] array, double searchValue, int arrayLength, out bool isFound, out int searchPosition, out double closestValue)
        {

            closestValue = 0;
            searchPosition = 0;
            int left;
            int midpoint = 0;
            int right;
            left = 0;
            right = arrayLength - 1;
            string lastUsed = "left";
            isFound = false;

            while (left <= right)
            {
                midpoint = (left + right) / 2;

                if (searchValue == array[midpoint])
                {
                    isFound = true;
                    closestValue = array[midpoint];
                    searchPosition = midpoint;
                    break;
                }
                else if (searchValue > array[midpoint])
                {
                    left = midpoint + 1;
                    lastUsed = "left";
                }
                else
                {
                    right = midpoint - 1;
                    lastUsed = "right";
                }
                
            }


            if (!isFound)
            {
                if (lastUsed == "left")
                {
                    Console.WriteLine(array[midpoint]);
                    double differenceBelow = searchValue - array[midpoint];
                    double differenceAbove = array[midpoint + 1] - searchValue;
                    if (differenceBelow < differenceAbove)
                    {
                        closestValue = array[midpoint];
                        searchPosition = midpoint;
                        Console.WriteLine("I have chosen the below option as the difference calculation gave {0}  and {1}", differenceBelow, differenceAbove);
                    }
                    else
                    {
                        closestValue = array[midpoint + 1];
                        searchPosition = midpoint + 1;
                        Console.WriteLine("I have chosen the above option as the difference calculation gave {0}  and {1}", differenceAbove, differenceBelow);
                    }
                }
                else
                {

                    Console.WriteLine(array[midpoint]);
                    double differenceBelow = searchValue - array[midpoint - 1];
                    double differenceAbove = array[midpoint] - searchValue;
                    if (differenceBelow < differenceAbove)
                    {
                        closestValue = array[midpoint - 1];
                        searchPosition = midpoint - 1;
                        Console.WriteLine("I have chosen the below option as the difference calculation gave {0}  and {1}", differenceBelow, differenceAbove);
                    }
                    else
                    {
                        closestValue = array[midpoint];
                        searchPosition = midpoint;
                        Console.WriteLine("I have chosen the above option as the difference calculation gave {0}  and {1}", differenceAbove, differenceBelow);
                    }
                }
            }
        }

        public void interpolationSearch(double[] array, double searchValue, out bool isFound, out int searchPosition, out double closestValue)
        {
            closestValue = 0;
            searchPosition = 5;
            isFound = false;
            string lastUsed = "left";
            int left = 0;
            int right = (array.Length - 1);

            while (left <= right && searchValue >= array[left] && searchValue <= array[right])
            {
                if (left == right)
                {
                    if (array[left] == searchValue)
                    {
                        isFound = true;
                        searchPosition = left;
                    }
                }

                // Estimates position of search term in the array bases on the interpolation calculation
                int pos =  Convert.ToInt32(left + (((right - left) / (array[right] - array[left])) * (searchValue - array[left])));

                 
                if (array[pos] == searchValue)
                {
                    isFound = true;
                    searchPosition = pos;
                }

                //if in right side move left up to middle
                if (array[pos] < searchValue)
                {
                    left = pos + 1;
                    lastUsed = "left";
                }
                //if in left side move right down to middle
                else
                {
                    right = pos - 1;
                    lastUsed = "right";
                }
            }

            //calculate nearest value
            //if (!isFound)
            //{
            //    Console.WriteLine(right);
            //    Console.WriteLine(right + 1);
            //    Console.WriteLine(array[right]);
            //    Console.WriteLine(array[right + 1]);
            //    double differenceBelow = searchValue - array[right];
            //    double differenceAbove = array[right + 1] - searchValue;
            //    if (differenceBelow < differenceAbove)
            //    {
            //        closestValue = array[right];
            //        searchPosition = right;
            //        Console.WriteLine("I have chosen the below option as the difference is {0} which is less than {1}", differenceBelow, differenceAbove);
            //    }
            //    else
            //    {
            //        closestValue = array[right + 1];
            //        searchPosition = right + 1;
            //        Console.WriteLine("I have chosen the above option as the difference is {0} which is less than {1}", differenceAbove, differenceBelow);
            //    }
            //}

            if (!isFound)
            {
                
                if (lastUsed == "left")
                {
                    Console.WriteLine(array[left]);
                    Console.WriteLine(array[left-1]);
                    double differenceBelow = searchValue - array[left];
                    double differenceAbove = array[left - 1] - searchValue;
                    if (differenceBelow > differenceAbove)
                    {
                        closestValue = array[left];
                        searchPosition = left;
                        Console.WriteLine("I have chosen the below option as the difference calculation gave {0}  and {1}", differenceBelow, differenceAbove);
                    }
                    else
                    {
                        closestValue = array[left - 1];
                        searchPosition = left - 1;
                        Console.WriteLine("I have chosen the above option as the difference calculation gave {0}  and {1}", differenceAbove, differenceBelow);
                    }
                }
                else
                {

                    Console.WriteLine(array[right]);
                    Console.WriteLine(array[right+1]);
                    double differenceBelow = searchValue - array[right - 1];
                    double differenceAbove = array[right] - searchValue;
                    if (differenceBelow > differenceAbove)
                    {
                        closestValue = array[right + 1];
                        searchPosition = right + 1;
                        Console.WriteLine("I have chosen the below option as the difference calculation gave {0}  and {1}", differenceBelow, differenceAbove);
                    }
                    else
                    {
                        closestValue = array[right];
                        searchPosition = right;
                        Console.WriteLine("I have chosen the above option as the difference calculation gave {0}  and {1}", differenceAbove, differenceBelow);
                    }
                }
            }
        }
    }
}
