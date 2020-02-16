using System;
using System.IO;

namespace Logic
{
    public class CombinationsCalculator
    {
        /// <summary>
        /// A program that reads the amount of money from a file and writes to the file the number of ways to collect this amount in coins of 1, 5, 10, 50 and 100.
        /// </summary>
        /// <param name="args"></param>
        public static void Main(string[] args)
        {
            int N;
            string inpPath = "../input.txt";
            string outPath = "../output.txt";
            try
            {
                using (StreamReader sr = new StreamReader(inpPath, System.Text.Encoding.Default))
                {
                    N = Int32.Parse(sr.ReadLine());
                    if (N < 0)
                    {
                        throw new ArgumentException("Incorrect input");
                    }
                }
            }
            catch
            {
                throw new ArgumentException("Incorrect input");
            }

            using (StreamWriter sw = new StreamWriter(outPath, false, System.Text.Encoding.Default))
            {
                sw.WriteLine(sum(N));
            }

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="value">Value of coin</param>
        /// <param name="i"> = N / 5, where N is sum of money (number of step)</param>
        /// <returns>The number of new combinations generated data type of coins(in combination with all smaller ones) at a specific step - the "five"</returns>
        static int newCombinations(int value, int i)
        {
            switch (value)
            {
                case 1:
                    if (i == 0)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                case 5: 
                    if (i >= 1)
                    {
                        return 1;
                    }
                    else
                    {
                        return 0;
                    }
                case 10:
                    if (i >= 2)
                    {
                        return newCombinations(5, i - 1) + newCombinations(10, i - 2);
                    }
                    else
                    {
                        return 0;
                    }
                case 50:
                    if (i >= 5)
                    {
                        return newCombinations(10, i - 8) + newCombinations(50, i - 10);
                    }
                    else
                    {
                        return 0;
                    }
                case 100:
                    if (i >= 5)
                    {
                        return newCombinations(50, i - 10) + newCombinations(100, i - 20);
                    }
                    else
                    {
                        return 0;
                    }
                default:
                    return 0;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="N">Sum of money</param>
        /// <returns>number of exchange methods for this step</returns>
        public static int sum(int N)
        {
            int i = N / 5;
            if (N >= 0)
            {
                return sum(N - 5) + newCombinations(1, i) + newCombinations(5, i) + newCombinations(10, i) + newCombinations(50, i) + newCombinations(100, i);
            }
            else
            {
                return 0;
            }
        }
    }
}
