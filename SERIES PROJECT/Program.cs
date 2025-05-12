using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SERIES_PROJECT
{

    internal class Program
    {

        static double[] series;
        static bool IfGetTheSeriesAgain = ValidateSeries();


        static void PrintEnterSeriesAgain()
        {
            Console.WriteLine("you didn't entered the series. please enter a series of numbers");
        }


        static void PrintTheFormatOfTheSeries()
        {
            Console.WriteLine("enter the series in the format : [num] [num] ...");
        }

        
        static string GetTheSeriesAgain() 
        {
            PrintTheFormatOfTheSeries();
            string input_series = Console.ReadLine();
            return input_series;
        }


        static string[] ConvertStringToArray(string input)
        {
            string[] stringLst = input.Split(' ');
            return stringLst;
        }


        static double ConvertCharToDouble(string inputChar)
        {
            try
            {
                double num = Convert.ToDouble(inputChar);
                return num;
            }
            catch (FormatException)
            {
                return -1;
            }
        }
        

        static void ConvertStringArrayToDoubleArray(string[] stringLst)
        {
                double[] doubleList = new double[stringLst.Length];
                int current_index = 0;
                double num;

                foreach (string str in stringLst)
                {
                    num = ConvertCharToDouble(str);
                    if (num >= 0)
                    {
                        doubleList[current_index] = num;
                        current_index++;
                    }

                    else
                    {
                        IfGetTheSeriesAgain = true;
                        series = new double[0];
                        return;
                    }
                }
                series = doubleList;
                IfGetTheSeriesAgain = false;
        }



        static void PrintWrongSeries()
        {
            Console.WriteLine("the series values / format is invalid");
        }




        static void GET_SERIES_MANAGER()
        {
            while (IfGetTheSeriesAgain)
            {
                PrintEnterSeriesAgain();
                PrintTheFormatOfTheSeries();
                string input_series = GetTheSeriesAgain();
                string[] stringArray = ConvertStringToArray(input_series);
                ConvertStringArrayToDoubleArray(stringArray);

                if (IfGetTheSeriesAgain)
                {
                    PrintWrongSeries();
                }
            }
        }
        

        static bool ValidateSeries()
        {
            return (series.Length > 3);
        }







        static void PrintTheMenu()
        {
            Console.WriteLine("enter the option: ");
            Console.WriteLine("     1. Input a Series. (Replace the current series)");
            Console.WriteLine("     2. Display the series in the order it was entered.");
            Console.WriteLine("     3. Display the series in the reversed order it was entered.");
            Console.WriteLine("     4. Display the series in sorted order (from low to high).");
            Console.WriteLine("     5. Display the Max value of the series.");
            Console.WriteLine("     6. Display the Min value of the series.");
            Console.WriteLine("     7. Display the Average of the series.");
            Console.WriteLine("     8. Display the Number of elements in the series.");
            Console.WriteLine("     9. Display the Sum of the series.");
            Console.WriteLine("     10. Exit.");
        }


        static string GetTheOptionFromMenu()
        {
            string input_option = Console.ReadLine();
            return input_option;
        }


        static bool ValidationOfTheOption(string option)
        {
            string[] options = {"1","2", "3", "4", "5", "6", "7", "8", "9", "10" };
            return (options.Contains(option));
        }



        static void PrintWrongOption()
        {

        }








        static void ReplaceTheSeriesManager_opt1()
        {

        }

        static void ReplaceSeries_opt1()
        {

        }


        static void PrintTheSeriesInOriginalOrderManager_opt2()
        {

        }

        static void PrintTheSeriesInReverseManager_opt3()
        {

        }

        static void PrintTheSeriesInAscendingOrderManager_opt4()
        {
        }

        static void PrintTheMaxNumInSeriesManager_opt5()
        {

        }

        static void PrintTheMinNumInSeriesManager_opt6()
        {
        }

        static void PrintTheAverageOfTheSeriesManager_opt7()
        {

        }

        static void printTheLengthOfTheSeriesManager_opt8()
        {

        }

        static void PrintTheSumOfTheSeriesManager_opt9()
        {

        }

        static bool PrintExitMessageManager_opt10()
        {

        }




        static void ProgramManager()
        {

        }

        static void Main(string[] args)
        {
            GET_SERIES_MANAGER();
            
        }
    }
}

