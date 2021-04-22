using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter number of Processes: ");
            int num_process = Convert.ToInt32(Console.ReadLine());

            Process[] mat_process = new Process[num_process]; //an array of processes taken from user

            //the history of processes as the element of this array consists of 3 parts
            //first the process id, second the start time of the process, third the end time of the process
            int[,] scheduler_history = new int[num_process, 3];

            //take input from user & save it in objects of processes
            for (int i = 0; i < num_process; i++)
            {
                //initialize the process
                mat_process[i] = new Process(0, 0, 0,0);

                Console.WriteLine("\n...Process {0}...", i + 1);

                Console.WriteLine("Enter Process Id: ");
                mat_process[i].set_Process_ID(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Enter Arrival Time: ");
                mat_process[i].set_Arrival_Time(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Enter Burst Time: ");
                mat_process[i].set_Burst_Time(Convert.ToInt32(Console.ReadLine()));

               
                Console.WriteLine("Priority: ");
                mat_process[i].set_Priority(Convert.ToInt32(Console.ReadLine()));
            }
            SFJ_Preemptive(mat_process, scheduler_history);

        }

        static void SFJ_Preemptive(Process[] mat_process, int[,] scheduler_history)
        {
            //test the program
            int id, at, bt;
            for (int i = 0; i < mat_process.Length; i++)
            {
                Console.WriteLine("\n...Process {0}...", i + 1);

                id = mat_process[i].get_Process_ID();
                Console.WriteLine("Process Id: {0}", id);

                at = mat_process[i].get_Arrival_Time();
                Console.WriteLine("Enter Arrival Time: {0}", at);

                bt = mat_process[i].get_Burst_Time();
                Console.WriteLine("Enter Burst Time: {0}", bt);
            }

            //Console.ReadLine();

        }
    }
}

