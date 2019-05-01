using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Assessment_3___Sorting
{
    class Reader
    {        
        public double[] Read(string file, int numRead) // function that read the file
        {
            int stepCounter = 0;
            double[] data = new double[numRead]; // create an array for numbers
            StreamReader readLines = new StreamReader(file); // initiate the reader
            int i = 0;
            while (!readLines.EndOfStream) //while there is still things to read
            {
                string strValue = readLines.ReadLine();
                bool isNumber = double.TryParse(strValue, out double result); // check if what is read is float
                if (isNumber)
                {
                    data[i] = result;
                    i++;
                    stepCounter++;
                }
                if (!isNumber)
                {
                    stepCounter++;
                }
            }
            //foreach (var element in data)
            //{
            //    Console.WriteLine(element);
            //}
            //Console.ReadLine();
            Console.WriteLine("File Read Steps: {0}", stepCounter++);
            return data;
        }
    }
}
