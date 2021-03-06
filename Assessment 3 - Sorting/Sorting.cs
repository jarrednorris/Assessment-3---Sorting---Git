﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assessment_3___Sorting
{
    class Sorting
    {
        
        public int mergeSortCounter = 0;
        public int mergeCounter = 0;
        public int quickSortCounter = 0;
        public int partitionCounter = 0;

        public double[] bubbleSort(double[] array, int arrayLength)
        {
            int stepCounter = 0;
            for (int i = 0; i < arrayLength - 1; i++)
            {
                for (int j = 0; j < arrayLength - 1 - i; j++)
                {
                    stepCounter++;
                    if (array[j + 1] < array[j])
                    {
                        double temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("bubbleSort() Steps: {0}", stepCounter);
            return array;
        }

        

        public double[] mergeSort(double[] array)
        {
            
            double[] left;
            double[] right;
            double[] result = new double[array.Length];
            
            
            //return once recursion is complete
            if (array.Length <= 1)
                return array;

            int midpoint = array.Length / 2;
            
            //make left and right array
            left = new double[midpoint];

            if (array.Length % 2 == 0)
                right = new double[midpoint];
            
            //if array has an odd number of elements, the right array will have one more element than left
            else
                right = new double[midpoint + 1];


            //fill the arrays

            for (int i = 0; i < midpoint; i++)
            {
                left[i] = array[i];
                mergeSortCounter++;
            }

            int x = 0;
            
            for (int i = midpoint; i < array.Length; i++)
            {
                right[x] = array[i];
                x++;
                mergeSortCounter++;
            }


            //sort left
            left = mergeSort(left);


            //sort right
            right = mergeSort(right);


            //merge left and right
            result = merge(left, right);


            return result;
        }

        

        public double[] merge(double[] left, double[] right)
        {
            
            int resultLength = right.Length + left.Length;
            double[] result = new double[resultLength];
            int indexLeft = 0, indexRight = 0, indexResult = 0;
            //while either array still has an element
            
            while (indexLeft < left.Length || indexRight < right.Length)
            {
                mergeCounter++;
                //if both arrays have elements  
                if (indexLeft < left.Length && indexRight < right.Length)
                {
                    //If item on left array is less than item on right array, add that item to the result array 
                    if (left[indexLeft] <= right[indexRight])
                    {
                        result[indexResult] = left[indexLeft];
                        indexLeft++;
                        indexResult++;
                    }
                    // else the item in the right array wll be added to the results array
                    else
                    {
                        result[indexResult] = right[indexRight];
                        indexRight++;
                        indexResult++;
                    }
                }
                //if only the left array still has elements, add all its items to the results array
                else if (indexLeft < left.Length)
                {
                    result[indexResult] = left[indexLeft];
                    indexLeft++;
                    indexResult++;
                }
                //if only the right array still has elements, add all its items to the results array
                else if (indexRight < right.Length)
                {
                    result[indexResult] = right[indexRight];
                    indexRight++;
                    indexResult++;
                }
            }
            return result;
        }

        public double[] quickSort(double[] array, int left, int right)
        {
            quickSortCounter++;
            if (left < right)
            {
                int pivot = Partition(array, left, right);

                if (pivot > 1)
                {
                    quickSort(array, left, pivot - 1);
                }
                if (pivot + 1 < right)
                {
                    quickSort(array, pivot + 1, right);
                }
            }
            return array;
        }

        private int Partition(double[] array, int left, int right)
        {
            double pivot = array[left];
            while (true)
            {

                while (array[left] < pivot)
                {
                    left++;
                    partitionCounter++;
                }

                while (array[right] > pivot)
                {
                    right--;
                    partitionCounter++;
                }

                if (left < right)
                {
                    if (array[left] == array[right]) return right;

                    double temp = array[left];
                    array[left] = array[right];
                    array[right] = temp;


                }
                else
                {
                    return right;
                }
            }
            
        }

    }
}
