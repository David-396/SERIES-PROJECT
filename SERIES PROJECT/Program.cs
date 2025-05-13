using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SERIES_PROJECT
{

    internal class Program
    {
        //the series of numbers if the user entered a series as a command line argument
        static string[] input_args;

        //the series of numbers
        static double[] series = { -1 };
        //if the series is valid or not
        static bool IfSeriesInvalid = true;


        //if the user need to enter a new option or not
        static bool IfGetNewOption = true;
        //what option the user chose
        static string input_option = "0";


        //if the user want to continue the program or not
        static bool IfContinueProgram = true;





        //function to print the enter series message
        static void PrintEnterSeries()
        {

            Console.WriteLine("please enter a series of numbers (at least 3 numbers): ");
        }


        //function to print the format of the series
        static void PrintTheFormatOfTheSeries()
        {
            Console.WriteLine("enter the series in the format : [num],[num],[num],...");
        }


        //function to get the series again from the user
        static string GetTheSeriesAgain()
        {
            PrintTheFormatOfTheSeries();
            string input_series = Console.ReadLine();
            return input_series;
        }


        //function to convert the string to array of strings
        static string[] ConvertStringToArray(string input)
        {

            string[] stringArr = input.Split(',');
            return stringArr;
        }


        //function to convert a string to double
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


        //function to convert the string array to double array
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
                    IfSeriesInvalid = true;
                    series = new double[0];
                    return;
                }
            }
            series = doubleList;
            IfSeriesInvalid = false;
        }



        //function to print the wrong series message
        static void PrintWrongSeries()
        {

            Console.WriteLine("the values/format/series-length you entered is invalid ");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }



        //function to check if the series is valid
        static bool IfInvalideSeries(double[] arr)
        {
            try
            {
                if (arr.Length >= 3)
                {
                    foreach (double num in arr)
                    {
                        if (num < 0)
                        {
                            return true;
                        }
                    }
                    return false;
                }
                return true;
            }
            catch
            {
                return true;
            }
        }



            //function to manage the series input
            // while the series is invalid the user need to enter a new series
        static void GET_SERIES_MANAGER(string[] input_args)
        {
            while (IfSeriesInvalid)
            {
                string input_series = string.Empty;
                if (input_args.Length == 0)     //if the user didn't enter a series as a command line argument - he need to enter now
                {
                    PrintEnterSeries();
                    input_series = GetTheSeriesAgain();
                }
                else
                {
                    input_series = input_args[0];       //if the user entered a series as a command line argument - we take it
                }

                string[] stringArray = ConvertStringToArray(input_series);
                ConvertStringArrayToDoubleArray(stringArray);
                IfSeriesInvalid = IfInvalideSeries(series);


                if (IfSeriesInvalid)        //if continue the loop - print error and reset the command line args so the user
                {
                    PrintWrongSeries();
                    input_args = new string[0];
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("the series: ");
                    PrintAnArray(series);
                    Console.WriteLine();
                }
            }
        }







        //function to print the menu
        static void PrintTheMenu()
        {

            Console.WriteLine();
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
            Console.WriteLine();
        }


        //function to read the option from the menu
        static string GetTheOptionFromMenu()
        {

            string input_option = Console.ReadLine();
            return input_option;
        }


        //function to validate the option input
        static bool ValidationOfTheOption(string option)
        {

            string[] options = { "1", "2", "3", "4", "5", "6", "7", "8", "9", "10" };
            return (options.Contains(option));
        }



        //function to print the wrong option message
        static void PrintWrongOption()
        {

            Console.WriteLine("invalid option please try again");
        }


        //function to manage the option input
        // while the option input not valid the user need to enter a new option
        static void OPTION_MANAGER()
        {
            do
            {
                PrintTheMenu();
                input_option = GetTheOptionFromMenu();
                if (ValidationOfTheOption(input_option))
                {
                    IfGetNewOption = false;
                    return;
                }
                PrintWrongOption();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            while (IfGetNewOption);
        }







        //function to replace the series
        //1
        static void ReplaceTheSeriesManager_opt1()
        {

            IfSeriesInvalid = true;
            series = new double[] { -1 };
            Console.Clear();
            GET_SERIES_MANAGER(new string[0]);
        }



        //function to print the series in original order
        //2
        static void PrintTheSeriesInOriginalOrderManager_opt2(double[] series_arr)
        {

            Console.WriteLine("the original order of the series: ");
            foreach (double num in series)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


        //function to print the series in reverse order
        //3
        static void PrintTheSeriesInReverseManager_opt3(double[] series_arr)
        {

            Console.WriteLine("the reversed series: ");
            PrintAnArray(ReverseArr(series_arr));
        }


        //function to reverse the array
        static double[] ReverseArr(double[] arr)
        {

            double[] reversed_arr = new double[series.Length];
            int reversed_i = 0;
            for (int i = series.Length - 1; i > -1; i--)
            {
                reversed_arr[reversed_i] = series[i];
                reversed_i++;
            }
            return reversed_arr;
        }



        //function to print the series in ascending order
        //4
        static void PrintTheSeriesInAscendingOrderManager_opt4()
        {

            Console.WriteLine("the sorted series: ");
            PrintAnArray(SortArr(series));
        }


        // function to sort the array in ascending order
        static double[] SortArr(double[] series_arr)
        {

            double[] sorted_arr = (double[])series_arr.Clone();

            for (int i = 0; i < series_arr.Length; i++)
            {
                int min_index = i;
                for (int j = i + 1; j < series_arr.Length; j++)
                {
                    if (series_arr[j] < series_arr[min_index])
                    {
                        min_index = j;
                    }
                }
                double temp = sorted_arr[i];
                sorted_arr[i] = sorted_arr[min_index];
                sorted_arr[min_index] = temp;
            }
            return sorted_arr;
        }


        //function to print the maximum number in the series
        //5
        static void PrintTheMaxNumInSeriesManager_opt5()
        {

            Console.WriteLine($"{FindMaxInArr(series)} is the maximum number in the series");
        }


        //function to get the maximum number in an array
        static double FindMaxInArr(double[] arr)
        {
            double max_num = arr[0];
            foreach (double num in arr)
            {
                if (num > max_num)
                {
                    max_num = num;
                }
            }
            return max_num;
        }



        //function to print the minimum number in the series
        //6
        static void PrintTheMinNumInSeriesManager_opt6()
        {

            Console.WriteLine($"{FindMinInArr(series)} is the minimum number in the series");
        }


        //function to get the minimum number in an array
        static double FindMinInArr(double[] arr)
        {
            double min_num = arr[0];
            foreach (double num in arr)
            {
                if (num < min_num)
                {
                    min_num = num;
                }
            }
            return min_num;
        }


        //function to print the average of the series
        //7
        static void PrintTheAverageOfTheSeriesManager_opt7()
        {

            Console.WriteLine($"{SumArr(series) / series.Length} is the average of the series");
        }





        //function to print the length of the series
        //8
        static void printTheLengthOfTheSeriesManager_opt8()
        {

            Console.WriteLine($"{series.Length} values you entered in the series");
        }


        //function to print summary of the array
        //9
        static void PrintTheSumOfTheSeriesManager_opt9()
        {
            Console.WriteLine($"{SumArr(series)} is the summary of the series");
        }


        //function to print and exit message
        //10
        static void PrintExitMessageManager_opt10()
        {
            Console.WriteLine("BYE!");
            IfContinueProgram = false;
        }



        //function to calculate the sum of the series
        static double SumArr(double[] arr)
        {
            double sum = 0;
            foreach (double num in arr)
            {
                sum += num;
            }
            return sum;
        }



        //function to print any double array
        static void PrintAnArray(double[] arr)
        {

            Console.WriteLine();
            foreach (double num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


        //function to manage the selection of the option
        static void SELECTION_MANAGER()
        {

            switch (input_option)
            {
                case "1":
                    Console.Clear();
                    ReplaceTheSeriesManager_opt1();
                    break;

                case "2":
                    Console.Clear();
                    PrintTheSeriesInOriginalOrderManager_opt2(series);
                    break;

                case "3":
                    Console.Clear();
                    PrintTheSeriesInReverseManager_opt3(series);
                    break;

                case "4":
                    Console.Clear();
                    PrintTheSeriesInAscendingOrderManager_opt4();
                    break;

                case "5":
                    Console.Clear();
                    PrintTheMaxNumInSeriesManager_opt5();
                    break;

                case "6":
                    Console.Clear();
                    PrintTheMinNumInSeriesManager_opt6();
                    break;

                case "7":
                    Console.Clear();
                    PrintTheAverageOfTheSeriesManager_opt7();
                    break;

                case "8":
                    Console.Clear();
                    printTheLengthOfTheSeriesManager_opt8();
                    break;

                case "9":
                    Console.Clear();
                    PrintTheSumOfTheSeriesManager_opt9();
                    break;

                case "10":
                    Console.Clear();
                    PrintExitMessageManager_opt10();
                    break;

                default:
                    Console.Clear();
                    PrintWrongOption();
                    break;
            }
        }


        //function to manage the program
        static void ProgramManager()
        {
            while (IfContinueProgram)
            {

                GET_SERIES_MANAGER(input_args);
                OPTION_MANAGER();
                SELECTION_MANAGER();

            }
        }


        //Main function to start the program
        static void Main(string[] args)
        {

            input_args = args;
            ProgramManager();
        }
    }
}
