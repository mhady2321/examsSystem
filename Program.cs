using System;
using System.Diagnostics;

namespace examsSystem
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject subject = new Subject(1, "c#");
            subject.CreateExam();
            Console.WriteLine();
            Console.Clear();
            Console.WriteLine("Do you want to take exam now ?? .. [yes to proceed, no to cancel]");

            string userInput = Console.ReadLine().Trim().ToLower();

            if (userInput == "yes")
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                subject.SubExam.ShowExam();
                sw.Stop();
                Console.WriteLine($"Elapsed Time  : {sw.Elapsed}");
            }
            else if (userInput == "no")
            {
                Console.WriteLine("You chose not to take the exam.");
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter 'yes' or 'no'.");
            }
        }
    }
}
