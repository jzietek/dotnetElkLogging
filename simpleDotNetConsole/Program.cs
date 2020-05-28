using System;
using Serilog;

namespace simpleDotNetConsole
{
    class Program
    {
        static void Main(string[] args) //Args format: ITERATIONS_COUNT ITERATION_DELAY
        {
            Log.Logger = new LoggerConfiguration()
                .WriteTo.File("simpleDotNetConsole.log")
                .WriteTo.Console()
                .CreateLogger();

            if (args.Length < 2)
            {
                Log.Error("Missing expected command line arguments: ITERATIONS_COUNT ITERATION_DELAY_MILLISECONDS");
                return;
            }
            int iterationsCount = 0;
            if(!int.TryParse(args[0], out iterationsCount))
            {
                Log.Error("Invalid iteartaions count paramaeter. Termianting!");
                return;
            }

            int iterationDelay = 0;
            if(!int.TryParse(args[1], out iterationDelay))
            {
                Log.Error("Invalid iteartaions delay paramaeter. Termianting!");
                return;
            }

            Random r = new Random(DateTime.Now.Millisecond);

            int counter = 0;
            while (counter < iterationsCount)
            {
                ShowRandomLogMessage(r);

                System.Threading.Thread.Sleep(iterationDelay);
                counter++;
            }
        }

        private static void ShowRandomLogMessage(Random r)
        {
            int n = r.Next(100);

            if (n < 10)
            {
                Log.Error($"This is some random error number {n}");
            }
            if (n < 50)
            {
                Log.Warning($"This is some random warning number {n}");
            }
            else
            {
                Log.Information($"This is some random info number {n}");
            }
        }
    }
}
