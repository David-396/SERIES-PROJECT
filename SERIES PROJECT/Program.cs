using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace SERIES_PROJECT
{

    internal class Program
    {

        static double[] series = {-1};
        static bool IfSeriesInvalid = true;

        static bool IfGetNewOption = true;
        static string input_option = "0";

        static bool IfContinueProgram = true;

        static void PrintEnterSeries()
        {
            Console.WriteLine("please enter a series of numbers (at least 3 numbers): ");
        }


        static void PrintTheFormatOfTheSeries()
        {
            Console.WriteLine("enter the series in the format : [num],[num],[num],...");
        }

        
        static string GetTheSeriesAgain() 
        {
            PrintTheFormatOfTheSeries();
            string input_series = Console.ReadLine();
            return input_series;
        }


        static string[] ConvertStringToArray(string input)
        {
            string[] stringArr = input.Split(',');
            return stringArr;
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
                        IfSeriesInvalid = true;
                        series = new double[0];
                        return;
                    }
                }
                series = doubleList;
                IfSeriesInvalid = false;
        }



        static void PrintWrongSeries()
        {
            Console.WriteLine("the series values / format is invalid");
            System.Threading.Thread.Sleep(1000);
            Console.Clear();
        }



        static bool IfInvalideSeries(double[] arr)
        {
            try
            {
                if(arr.Length >= 3)
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



        static void GET_SERIES_MANAGER()
        {
            while (IfSeriesInvalid)
            {
                PrintEnterSeries();
                string input_series = GetTheSeriesAgain();
                string[] stringArray = ConvertStringToArray(input_series);
                ConvertStringArrayToDoubleArray(stringArray);
                IfSeriesInvalid = IfInvalideSeries(series);

                if (IfSeriesInvalid)
                {
                    PrintWrongSeries();
                }
            }
            Console.WriteLine();
        }
        

       


        



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
            Console.WriteLine("invalid option please try again");
        }


        static void OPTION_MANAGER()
        {
            do
            {
                PrintTheMenu();
                input_option = GetTheOptionFromMenu();
                if (ValidationOfTheOption(input_option))
                {
                    break;
                }
                PrintWrongOption();
                System.Threading.Thread.Sleep(1000);
                Console.Clear();
            }
            while(IfGetNewOption);
        }







        //1
        static void ReplaceTheSeriesManager_opt1()
        {
            IfSeriesInvalid = true;
            series = new double[] {-1};
            Console.Clear();
            GET_SERIES_MANAGER();
        }



        //2
        static void PrintTheSeriesInOriginalOrderManager_opt2(double[] series_arr)
        {
            Console.WriteLine("the original order of the series: ");
            foreach(double num in series)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


        //3
        static void PrintTheSeriesInReverseManager_opt3(double[] series_arr)
        {
            Console.WriteLine("the reversed series: ");
            PrintAnArray(ReverseArr(series_arr));
        }


        static double[] ReverseArr(double[] arr)
        {
            double[] reversed_arr = new double[series.Length];
            int reversed_i = 0;
            for (int i = series.Length -1; i > -1; i--)
            {
                reversed_arr[reversed_i] = series[i];
                reversed_i++;
            }
            return reversed_arr;
        }

        

        //4
        static void PrintTheSeriesInAscendingOrderManager_opt4()
        {
            Console.WriteLine("the sorted series: ");
            PrintAnArray(SortArr(series));
        }


        static double[] SortArr(double[] series_arr)
        {
            double[] sorted_arr = new double[series_arr.Length];

            for(int i=0; i< series_arr.Length; i++)
            {
                double current_min = series_arr[i];
                for (int j = i+1; j < series_arr.Length; j++)
                {
                    if(current_min > series_arr[j])
                    {
                        current_min = series_arr[j];
                    }
                }
                sorted_arr[i] = current_min;
            }
            return sorted_arr;
        }

        
        //5
        static void PrintTheMaxNumInSeriesManager_opt5()
        {
            Console.WriteLine($"{FindMaxInArr(series)} is the maximum number in the series");
        }

        static double FindMaxInArr(double[] arr)
        {
            double max_num = arr[0];
            foreach(double num in arr)
            {
                if(num > max_num)
                {
                    max_num = num;
                }
            }
            return max_num;
        }



        //6
        static void PrintTheMinNumInSeriesManager_opt6()
        {
            Console.WriteLine($"{FindMinInArr(series)} is the minimum number in the series");
        }

        static double FindMinInArr(double[] arr)
        {
            double min_num = arr[0];
            foreach(double num in arr)
            {
                if(num < min_num)
                {
                    min_num = num;
                }
            }
            return min_num;
        }


        //7
        static void PrintTheAverageOfTheSeriesManager_opt7()
        {
            Console.WriteLine($"{SumArr(series)/series.Length} is the average of the series");
        }

        



        //8
        static void printTheLengthOfTheSeriesManager_opt8()
        {
            Console.WriteLine($"{series.Length} values you entered in the series");
        }


        //9
        static void PrintTheSumOfTheSeriesManager_opt9()
        {
            Console.WriteLine($"{SumArr(series)} is the summary of the series");
        }


        //10
        static void PrintExitMessageManager_opt10()
        {
            Console.WriteLine("BYE!");
            IfContinueProgram = false;
        }



        static double SumArr(double[] arr)
        {
            double sum = 0;
            foreach (double num in arr)
            {
                sum += num;
            }
            return sum;
        }



        static void PrintAnArray(double[] arr)
        {
            foreach (double num in arr)
            {
                Console.Write(num + " ");
            }
            Console.WriteLine();
        }


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

        static void ProgramManager(string[] input_args)
        {
            while (IfContinueProgram)
            {
                //if (input_args == null)
                //{
                //    GET_SERIES_MANAGER();
                //}
                GET_SERIES_MANAGER();
                OPTION_MANAGER();
                SELECTION_MANAGER();

            }
        }
      

        static void Main(string[] args)
        {
            ProgramManager(args);
        }
    }
}

