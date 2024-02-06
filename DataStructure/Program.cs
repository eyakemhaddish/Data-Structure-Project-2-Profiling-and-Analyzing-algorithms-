//using System;
//using System.Diagnostics;
//using OxyPlot;
//using OxyPlot.Series;
//using OxyPlot.Axes;

//class Program
//{
//    static void Main()
//    {
//        // Define input sizes for testing
//        int[] inputSizes = { 1000, 5000, 10000 };

//        // Perform profiling and analysis for each sorting algorithm
//        var bubbleSortResults = ProfileAndAnalyzeAlgorithm("Bubble Sort", BubbleSort, inputSizes);
//        var selectionSortResults = ProfileAndAnalyzeAlgorithm("Selection Sort", SelectionSort, inputSizes);
//        var insertionSortResults = ProfileAndAnalyzeAlgorithm("Insertion Sort", InsertionSort, inputSizes);

//        // Generate and display the graph
//        GenerateGraph(bubbleSortResults, selectionSortResults, insertionSortResults);

//        Console.WriteLine("Profiling and analysis completed. Press any key to exit.");
//        Console.ReadKey();
//    }

//    // Method to profile and analyze a sorting algorithm for different scenarios
//    static AlgorithmResults ProfileAndAnalyzeAlgorithm(string algorithmName, Action<int[]> algorithm, int[] inputSizes)
//    {
//        Console.WriteLine($"Profiling {algorithmName}");

//        AlgorithmResults algorithmResults = new AlgorithmResults(algorithmName);

//        // Perform profiling for each input size
//        foreach (int size in inputSizes)
//        {
//            // Generate input data for each scenario
//            int[] bestCaseInput = GenerateBestCaseInput(size);
//            int[] averageCaseInput = GenerateAverageCaseInput(size);
//            int[] worstCaseInput = GenerateWorstCaseInput(size);

//            // Perform profiling for each scenario
//            long bestCaseTime = ProfileAlgorithm(algorithm, bestCaseInput);
//            long averageCaseTime = ProfileAlgorithm(algorithm, averageCaseInput);
//            long worstCaseTime = ProfileAlgorithm(algorithm, worstCaseInput);

//            // Store the results
//            algorithmResults.AddResult(size, bestCaseTime, averageCaseTime, worstCaseTime);
//        }

//        return algorithmResults;
//    }

//    // Method to profile the execution time of a sorting algorithm
//    static long ProfileAlgorithm(Action<int[]> algorithm, int[] input)
//    {
//        Stopwatch stopwatch = new Stopwatch();
//        stopwatch.Start();

//        algorithm(input);

//        stopwatch.Stop();
//        return stopwatch.ElapsedMilliseconds;
//    }

//    // Bubble Sort implementation
//    static void BubbleSort(int[] arr)
//    {
//        int n = arr.Length;
//        for (int i = 0; i < n - 1; i++)
//        {
//            for (int j = 0; j < n - i - 1; j++)
//            {
//                if (arr[j] > arr[j + 1])
//                {
//                    // Swap arr[j] and arr[j+1]
//                    int temp = arr[j];
//                    arr[j] = arr[j + 1];
//                    arr[j + 1] = temp;
//                }
//            }
//        }
//    }

//    // Selection Sort implementation
//    static void SelectionSort(int[] arr)
//    {
//        int n = arr.Length;
//        for (int i = 0; i < n - 1; i++)
//        {
//            int minIndex = i;
//            for (int j = i + 1; j < n; j++)
//            {
//                if (arr[j] < arr[minIndex])
//                {
//                    minIndex = j;
//                }
//            }
//            int temp = arr[minIndex];
//            arr[minIndex] = arr[i];
//            arr[i] = temp;
//        }
//    }

//    // Insertion Sort implementation
//    static void InsertionSort(int[] arr)
//    {
//        int n = arr.Length;
//        for (int i = 1; i < n; ++i)
//        {
//            int key = arr[i];
//            int j = i - 1;

//            while (j >= 0 && arr[j] > key)
//            {
//                arr[j + 1] = arr[j];
//                j = j - 1;
//            }
//            arr[j + 1] = key;
//        }
//    }

//    // Method to generate an already sorted input array (best case scenario)
//    static int[] GenerateBestCaseInput(int size)
//    {
//        int[] input = new int[size];
//        for (int i = 0; i < size; i++)
//        {
//            input[i] = i + 1;
//        }
//        return input;
//    }

//    // Method to generate a randomly shuffled input array (average case scenario)
//    static int[] GenerateAverageCaseInput(int size)
//    {
//        Random random = new Random();
//        int[] input = new int[size];
//        for (int i = 0; i < size; i++)
//        {
//            input[i] = random.Next(1, size + 1);
//        }
//        return input;
//    }

//    // Method to generate an input array sorted in reverse order (worst case scenario)
//    static int[] GenerateWorstCaseInput(int size)
//    {
//        int[] input = new int[size];
//        for (int i = 0; i < size; i++)
//        {
//            input[i] = size - i;
//        }
//        return input;
//    }

//    // Method to generate and display the graph
//    static void GenerateGraph(params AlgorithmResults[] algorithmResults)
//    {
//        var plotModel = new PlotModel();

//        // Configure the X-axis
//        var xAxis = new LinearAxis
//        {
//            Position = AxisPosition.Bottom,
//            Title = "Input Size"
//        };
//        plotModel.Axes.Add(xAxis);

//        // Configure the Y-axis
//        var yAxis = new LinearAxis
//        {
//            Position = AxisPosition.Left,
//            Title = "Execution Time (ms)"
//        };
//        plotModel.Axes.Add(yAxis);

//        // Add line series for each algorithm
//        foreach (var result in algorithmResults)
//        {
//            var lineSeries = new LineSeries
//            {
//                Title = result.AlgorithmName,
//                StrokeThickness = 2
//            };

//            foreach (var dataPoint in result.Results)
//            {
//                lineSeries.Points.Add(new DataPoint(dataPoint.Size, dataPoint.Time));
//            }

//            plotModel.Series.Add(lineSeries);
//        }

//        // Create and display the plot view
//        //var plotView = new OxyPlot.WindowsForms.PlotView
//        //{
//        //    Model = plotModel
//        //};

//        //// Display the plot view in a new window
//        //var form = new System.Windows.Forms.Form
//        //{
//        //    Width = 800,
//        //    Height = 600
//        //};
//        //form.Controls.Add(plotView);
//        //form.ShowDialog();
//    }
//}

//// Helper class to store algorithm results
//class AlgorithmResults
//{
//    public string AlgorithmName { get; private set; }
//    public List<ResultData> Results { get; private set; }

//    public AlgorithmResults(string algorithmName)
//    {
//        AlgorithmName = algorithmName;
//        Results = new List<ResultData>();
//    }

//    public void AddResult(int size, long bestCaseTime, long averageCaseTime, long worstCaseTime)
//    {
//        Results.Add(new ResultData(size, bestCaseTime, averageCaseTime, worstCaseTime));
//    }
//}

//// Helper class to store individual result data
//class ResultData
//{
//    public int Size { get; private set; }
//    public long Time { get; private set; }

//    public ResultData(int size, long bestCaseTime, long averageCaseTime, long worstCaseTime)
//    {
//        Size = size;

//        // Choose the time value based on the scenario (best, average, or worst case)
//        switch (size)
//        {
//            case 1000:
//                Time = bestCaseTime;
//                break;
//            case 5000:
//                Time = averageCaseTime;
//                break;
//            case 10000:
//                Time = worstCaseTime;
//                break;
//        }
//    }
//}



using System;
using System.Diagnostics;
using System.Drawing;

class Program
{
    static void Main()
    {
        // Define input sizes for testing
        int[] inputSizes = { 1000, 5000, 10000 };

        // Perform profiling and analysis for each sorting algorithm
        ProfileAndAnalyzeAlgorithm("Bubble Sort", BubbleSort, inputSizes);
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine();
        ProfileAndAnalyzeAlgorithm("Selection Sort", SelectionSort, inputSizes);
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------------");
        Console.WriteLine();
        ProfileAndAnalyzeAlgorithm("Insertion Sort", InsertionSort, inputSizes);

        Console.WriteLine("Profiling and analysis completed. Press any key to exit.");
        Console.ReadKey();
    }

    // Method to profile and analyze a sorting algorithm for different scenarios












    static void ProfileAndAnalyzeAlgorithm(string algorithmName, Action<int[]> algorithm, int[] inputSizes)
    {
        Console.WriteLine($"Profiling {algorithmName}");

        // Perform profiling for each input size
        foreach (int size in inputSizes)
        {
            // Generate input data for each scenario
            int[] bestCaseInput = GenerateBestCaseInput(size);
            int[] averageCaseInput = GenerateAverageCaseInput(size);
            int[] worstCaseInput = GenerateWorstCaseInput(size);

            // Perform profiling for each scenario
            long bestCaseTime = ProfileAlgorithm(algorithm, bestCaseInput);
            long averageCaseTime = ProfileAlgorithm(algorithm, averageCaseInput);
            long worstCaseTime = ProfileAlgorithm(algorithm, worstCaseInput);

            // Output the results
            Console.WriteLine($"Input Size: {size}");
            Console.WriteLine($"Best Case Time: {bestCaseTime} ms");
            Console.WriteLine($"Average Case Time: {averageCaseTime} ms");
            Console.WriteLine($"Worst Case Time: {worstCaseTime} ms");
            Console.WriteLine();
          
        }
    }

    // Method to profile the execution time of a sorting algorithm
    static long ProfileAlgorithm(Action<int[]> algorithm, int[] input)
    {
        Stopwatch stopwatch = new Stopwatch();
        stopwatch.Start();

        algorithm(input);

        stopwatch.Stop();
        return stopwatch.ElapsedMilliseconds;
    }

    // Bubble Sort implementation
    static void BubbleSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            for (int j = 0; j < n - i - 1; j++)
            {
                if (arr[j] > arr[j + 1])
                {
                    // Swap arr[j] and arr[j+1]
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }

    // Selection Sort implementation
    static void SelectionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 0; i < n - 1; i++)
        {
            int minIndex = i;
            for (int j = i + 1; j < n; j++)
            {
                if (arr[j] < arr[minIndex])
                {
                    minIndex = j;
                }
            }
            int temp = arr[minIndex];
            arr[minIndex] = arr[i];
            arr[i] = temp;
        }
    }

    // Insertion Sort implementation
    static void InsertionSort(int[] arr)
    {
        int n = arr.Length;
        for (int i = 1; i < n; ++i)
        {
            int key = arr[i];
            int j = i - 1;

            while (j >= 0 && arr[j] > key)
            {
                arr[j + 1] = arr[j];
                j = j - 1;
            }
            arr[j + 1] = key;
        }
    }

    // Method to generate an already sorted input array (best case scenario)
    static int[] GenerateBestCaseInput(int size)
    {
        int[] input = new int[size];
        for (int i = 0; i < size; i++)
        {
            input[i] = i + 1;
        }
        return input;
    }

    // Method to generate a randomly shuffled input array (average case scenario)
    static int[] GenerateAverageCaseInput(int size)
    {
        Random random = new Random();
        int[] input = new int[size];
        for (int i = 0; i < size; i++)
        {
            input[i] = random.Next(1, size + 1);
        }
        return input;
    }

    // Method to generate an input array sorted in reverse order (worst case scenario)
    static int[] GenerateWorstCaseInput(int size)
    {
        int[] input = new int[size];
        for (int i = 0; i < size; i++)
        {
            input[i] = size - i;
        }
        return input;
    }

    static void Drawgraph() {
        int[] data = { 5, 3, 8, 4, 2, 7, 3, 5, 2 }; // Sample data for the graph



        // Height of the graph

        int height = 10;
        int col = 0;

        //Different colors to show the different Input Sizes we used 
        ConsoleColor[] colors = { ConsoleColor.Red, ConsoleColor.Blue, ConsoleColor.Green };


        // Draw graph
        for (int y = 0; y < height; y++)
        {
            for (int x = 0; x < data.Length; x++)
            {
                Console.ForegroundColor = colors[col];
                int bar = (int)(data[x]);

                if (height - y <= bar)
                    Console.Write("|"); // Drawing the bar

                else
                    Console.Write(" ");

                //Index 0,1,2 will be the Best case  3,4,5 will be Avg. case   6,7,8 will be worst case
                if (x == 2 || x == 5 || x == 8)
                {
                    Console.ResetColor();
                    Console.Write("                ");

                }

                col++;
                if (col > 2) col = 0;
            }

            Console.WriteLine();

        }



        // Draw the x-axis values
        Console.ResetColor();
        Console.Write("Best Case");
        Console.Write("       ");

        Console.Write("Average Case");
        Console.Write("       ");

        Console.Write("Worst Case");
        Console.Write("       ");
        Console.ForegroundColor = colors[0];
        Console.Write("| ");
        Console.ResetColor();
        Console.Write("1000 Input Size");
        Console.Write("       ");

        Console.ForegroundColor = colors[1];
        Console.Write("| ");
        Console.ResetColor();
        Console.Write("5000 Input Size");
        Console.Write("       ");

        Console.ForegroundColor = colors[2];
        Console.Write("| ");
        Console.ResetColor();
        Console.Write("10000 Input Size");
        Console.Write("       ");
        Console.ResetColor();
        Console.WriteLine();
    }

}