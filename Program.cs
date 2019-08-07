using System;

namespace EX_6A_Manipulating_Arrays
{
    class Program
    {
        static void Main(string[] args)
        {
            //Given Arrays
            int[] arrayA = { 0, 2, 4, 6, 8, 10 };
            int[] arrayB = { 1, 3, 5, 7, 9 };
            int[] arrayC = { 3, 1, 4, 1, 5, 9, 2, 6, 5, 3, 5, 9 };
            Console.WriteLine("EX 6A - C# Manipulating Arrays:");
            //Part 1: Counting, summing, computing the mean
            CountSumMean Part1 = new CountSumMean { };
            Console.WriteLine($"\nPart 1: Counting, summing, computing the mean\n" +
                $"The mean for Array A is: {Part1.AvgArray(arrayA)}");
            Console.WriteLine($"The mean for Array B is: {Part1.AvgArray(arrayB)}");
            Console.WriteLine($"The mean for Array C is: {Part1.AvgArray(arrayC)}");

            //Part 2: Reversing arrays
            ReversingArrays Part2 = new ReversingArrays { };
            Console.WriteLine($"\nPart 2: Reversing arrays\n" +
                $"The reverse of Array A is: {Part2.PrintReverse(arrayA)}");
            Console.WriteLine($"The reverse of Array B is: {Part2.PrintReverse(arrayB)}");
            Console.WriteLine($"The reverse of Array C is: {Part2.PrintReverse(arrayC)}");

            //Part 3: Rotating arrays
            RotatingArrays Part3 = new RotatingArrays { };
            Console.WriteLine($"\nPart 3: Rotating arrays\n" +
                $"The rotation of Array A is: {Part3.PrintRotate(arrayA, "left", 2)}");
            Console.WriteLine($"The rotation of Array B is: {Part3.PrintRotate(arrayB, "right", 2)}");
            Console.WriteLine($"The rotation of Array C is: {Part3.PrintRotate(arrayC, "left", 4)}");

            //Part 4: Sorting arrays
            SortingArrays Part4 = new SortingArrays { };
            Console.WriteLine($"\nPart 4: Sorting arrays\n" +
                $"Sorted Array C: {Part4.PrintSort(arrayC)}");

            //Part BONUS ROUND Feed the sorted array into the reversing array method
            Console.WriteLine($"\n*BONUS ROUND* reverse the sorted array!\n" +
                $"The reverse of sorted Array C is: {Part2.PrintReverse(Part4.Sort(arrayC))}");

            //Pause//
            Console.ReadLine();
        }
    }
    class CountSumMean
    {
        public int CountArray(int[] value)
        { return value.Length; }
        public int SumArray(int[] value)
        {
            int sum = new int();
            for (int i = 0; i < value.Length; i++)
            {
                sum += value[i];
            }
            return sum;
        }
        public double AvgArray(int[] value)
        {
            double avg = (Convert.ToDouble(SumArray(value)) / Convert.ToDouble(CountArray(value)));
            return avg;
        }
    }
    class ReversingArrays
    {
        public int[] Reverse(int[] value)
        {
            int[] reversedValue = new int[value.Length];
            for(int i=0; i<value.Length; i++)
            {
                reversedValue[i] = value[(value.Length-1) - i];
            }
            return reversedValue;
        }
        public string PrintReverse(int[] value)
        {
            int[] reversedArray = Reverse(value);
            string arrayAsString = "";
            foreach (int num in reversedArray)
            {
                arrayAsString += Convert.ToString($"{num} ");
            }
            return arrayAsString;
        }
    }
    class RotatingArrays
    {
        public string PrintRotate(int[] value, string direction, int numOfRotations)
        {
            int[] rotatedValue = Rotate(value, direction, numOfRotations);
            string asString = "";
            foreach (int num in rotatedValue)
            {
                asString += (num.ToString() + " ");
            }
            return asString;
        }
        public int[] Rotate(int[] value, string direction, int numOfRotations)
        {
            switch (direction)
            {
                case "left":
                    for (int i = 1; i <= numOfRotations; i++)
                    {
                        RotateLeftOnce(value);
                    }
                    break;
                case "right":
                    for (int i = 1; i <= numOfRotations; i++)
                    {
                        RotateRightOnce(value);
                    }
                    break;
                default:
                    throw new Exception("Invalid Direction");
            }
            return value;
        }
        public int[] RotateLeftOnce(int[] value)
        {
            int index;
            int temp = value[0];
            for (index = 0; index < value.Length-1; index++)
            {
                value[index] = value[index + 1];
            }
            value[index] = temp;
            return value;
        }
        public int[] RotateRightOnce(int[] value)
        {
            int index;
            int temp = value[value.Length-1];
            for (index = value.Length-1; index > 0; index--)
            {
                value[index] = value[index - 1];
            }
            value[index] = temp;
            return value;
        }
    }
    class SortingArrays
    {
        public string PrintSort(int[] array)
        {
            Sort(array);
            string asString = "";
            foreach(int num in array)
            {
                asString += num.ToString() + " ";
            }
            return asString;
        }
         
        public int[] Sort(int[] inputArray)
        {
            int tempValue;
            for(int index=0; index < inputArray.Length; index++)
            {
                for(int nextIndex=index+1; nextIndex < inputArray.Length; nextIndex++)
                {
                    if (inputArray[index] > inputArray[nextIndex])
                    {
                        tempValue = inputArray[index];
                        inputArray[index] = inputArray[nextIndex];
                        inputArray[nextIndex] = tempValue;
                    }   
                }
            }
            return inputArray;
        }
    }
}
