using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3___Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            ArrayFetch();
        }

        static public void ArrayFetch()
        {
            Console.WriteLine("Enter filename to be read (CASE SENSITIVE | include extension '.txt'):");
            string fileName = Console.ReadLine();
            int fileNum = 0;
            string searchType = "binary";


            if (fileName == "Low_256.txt" | fileName == "Mean_256.txt" | fileName == "High_256.txt")
                fileNum = 256;
            else if (fileName == "Low_2048.txt" | fileName == "Mean_2048.txt" | fileName == "High_2048.txt")
                fileNum = 2048;
            else if (fileName == "Low_4096.txt" | fileName == "Mean_4096.txt" | fileName == "High_4096.txt")
                fileNum = 4096;
            else
                ArrayFetch();

            if (fileName == "Low_256.txt" | fileName == "Low_2048.txt" | fileName == "Low_4096.txt" | fileName == "High_256.txt" | fileName == "High_2048.txt" | fileName == "High_4096.txt")
                searchType = "binary";
            else if (fileName == "Mean_256.txt" | fileName == "Mean_2048.txt" | fileName == "Mean_4096.txt")
                searchType = "interpolate";
            else
                ArrayFetch();


            Reader readerInstance = new Reader();
            double[] array = readerInstance.Read(fileName, fileNum);
            double[] sortedArrayAsc = ArraySort(array, fileNum);
            //double[] sortedArrayDesc = sortedArrayAsc;
            //Array.Reverse(sortedArrayDesc);

            if (fileNum == 256)
            {
                Console.WriteLine("Here is every 10th value of the array in ascending order");
                for (int i = 0; i < fileNum - 1; i += 10)  //Print 10th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }

                Console.WriteLine("Here is every 10th value of the array in descending order");
                for (int i = fileNum - 1; i >= 0; i -= 10)  //Print 10th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }
            }

            if (fileNum == 2048)
            {
                Console.WriteLine("Here is every 50th value of the array in ascending order");
                for (int i = 0; i < fileNum - 1; i += 50)  //Print 50th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }

                Console.WriteLine("Here is every 50th value of the array in descending order");
                for (int i = fileNum - 1; i >= 0; i -= 50)  //Print 50th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }
            }

            if (fileNum == 4096)
            {
                Console.WriteLine("Here is every 80th value of the array in ascending order");
                for (int i = 0; i < fileNum - 1; i += 80)  //Print 80th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }

                Console.WriteLine("Here is every 80th value of the array in descending order");
                for (int i = fileNum - 1; i >= 0; i -= 80)  //Print 80th value of array
                {
                    Console.WriteLine(sortedArrayAsc[i]);
                }
            }


            //Console.WriteLine("Here is every 10th value of the array in descending order");
            //for (int i = 0; i < fileNum; i += 10)  //Print 10th value of array
            //{
            //    Console.WriteLine(sortedArrayDesc[i]);
            //}




            //SearchType();

            Console.WriteLine("Enter number to search for (datatype=double) (best determined search method - searchMethod={0}):", searchType);
            string searchTerm = Console.ReadLine();
            double.TryParse(searchTerm, out double searchValue);
            
            ArraySearch(sortedArrayAsc, searchValue, fileNum, searchType);
            

        }

        public static double[] ArraySort(double[] array, int fileNum)
        {
            Sorting sortingInstance = new Sorting();

            if (fileNum == 256)
            {
                array = sortingInstance.mergeSort(array);
            }
            else if (fileNum == 2048)
            {
                array = sortingInstance.bubbleSort(array, fileNum);
            }
            else if (fileNum == 4096)
            {
                array = sortingInstance.bubbleSort(array, fileNum);
            }

            return array;
        }

        public static void ArraySearch(double[] array, double searchValue, int fileNum, string searchType)
        {
            Searching searchingInstance = new Searching();

            if (searchType == "binary")
            {
                searchingInstance.BinarySearch(array, searchValue, fileNum, out bool isFound, out int searchPosition, out double closestValue);
                SearchResults(array, isFound, searchPosition, closestValue);
            }
            else if (searchType == "interpolate")
            {
                searchingInstance.interpolationSearch(array, searchValue, out bool isFound, out int searchPosition, out double closestValue);
                SearchResults(array, isFound, searchPosition, closestValue);
            }
            else
            {
                searchingInstance.interpolationSearch(array, searchValue, out bool isFound, out int searchPosition, out double closestValue);
                SearchResults(array, isFound, searchPosition, closestValue);
            }

            


        }

        public static void SearchResults(double[] array, bool isFound, int searchPosition, double closestValue)
        {
            if (isFound)
            {
                Console.WriteLine("This number IS present in the array at positions");
                int searchPositionTemp = searchPosition;
                Console.WriteLine(searchPositionTemp);
                while (array[searchPositionTemp - 1] == array[searchPosition])
                {
                    Console.WriteLine(searchPositionTemp - 1);
                    searchPositionTemp--;
                }
                Console.WriteLine(searchPosition);
                searchPositionTemp = searchPosition;
                while (array[searchPositionTemp + 1] == array[searchPosition])
                {
                    Console.WriteLine(searchPositionTemp + 1);
                    searchPositionTemp++;
                }
            }

            else
            {
                Console.WriteLine("This number IS NOT present in the array. The closest value is {1} at position {0} in the sorted array", searchPosition, closestValue);
            }
            Console.ReadLine();
        }

        //public static double SearchType()
        //{
        //    Console.WriteLine("Enter number to search for (datatype=double):");
        //    string searchTerm = Console.ReadLine();
        //    bool isDouble = double.TryParse(searchTerm, out double searchValue);
        //    if (isDouble)
        //    {
        //        return searchValue;
        //    }
        //    else
        //    {
        //        SearchType();
        //        return searchValue;
        //    }
        //}      
        
    }
}
