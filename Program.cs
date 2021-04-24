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
                mat_process[i] = new Process(0, 0, 0, 0,0);

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
           /* 
             Process[] mat_process = new Process[4];


             mat_process[0] = new Process(1, 2, 6, 2, 0);
             mat_process[1] = new Process(2, 0, 8, 1, 0);
             mat_process[2] = new Process(3, 0, 7, 3, 0);
             mat_process[3] = new Process(4, 1, 3, 4, 0);
             int[,] scheduler_history = new int[4, 3];*/
             //Priority_non_Preemptive(mat_process, scheduler_history);
           /*  for (int i = 0; i < 4; i++)
             {
                 //Console.WriteLine(mat_process[i].get_Waiting_Time());
                 Console.WriteLine(" " + scheduler_history[i, 0] + "\t\t" + scheduler_history[i, 1] + "\t\t " + scheduler_history[i, 2]);

             }*/
           Priority_non_Preemptive(mat_process,  scheduler_history,num_process);
            /*int number = 0;
            Process Current_process = new Process(0, 0, 0, 0, 0);
            Current_process = mat_process[0];
            int End_time = 0;
            int Count = 0;
            for (int j = Count; j < mat_process.Length; j++)
            {
                for (int i = Count; i < mat_process.Length; i++)
                {
                    if (mat_process[i].get_Arrival_Time() <= End_time)
                    {
                        Current_process = mat_process[i];
                        number = i;
                        break;
                    }

                }
                for (int i = Count; i < mat_process.Length; i++)
                {
                    if (mat_process[i].get_Arrival_Time() <= End_time && mat_process[i].get_Priority() < Current_process.get_Priority())
                    {
                        Current_process = mat_process[i];
                        number = i;
                    }

                }
                scheduler_history[Count, 0] = Current_process.get_Process_ID();
                scheduler_history[Count, 1] = End_time;
                mat_process[number].set_Waiting_Time(End_time - mat_process[number].get_Arrival_Time());
                End_time = End_time + Current_process.get_Burst_Time();
                scheduler_history[Count, 2] = End_time;
                Swap(ref mat_process[number], ref mat_process[Count]);
                Count++;

            }
            for (int i = 0; i < num_process; i++)
            {

                Console.WriteLine(" " + scheduler_history[i, 0] + "\t\t" + scheduler_history[i, 1] + "\t\t " + scheduler_history[i, 2]);

            }*/
        
        //swap function
     
    }

        static void Priority_non_Preemptive(Process[] mat_process, int[,] scheduler_history, int num_process)
        {
            int number = 0;
            Process Current_process = new Process(0, 0, 0, 0, 0);
            Current_process = mat_process[0];
            int End_time = 0;
            int Count = 0;
            for (int j = Count; j < mat_process.Length; j++)
            {
                for (int i = Count; i < mat_process.Length; i++)
                {
                    if (mat_process[i].get_Arrival_Time() <= End_time)
                    {
                        Current_process = mat_process[i];
                        number = i;
                        break;
                    }

                }
                for (int i = Count; i < mat_process.Length; i++)
                {
                    if (mat_process[i].get_Arrival_Time() <= End_time && mat_process[i].get_Priority() < Current_process.get_Priority())
                    {
                        Current_process = mat_process[i];
                        number = i;
                    }

                }
                int W;
                scheduler_history[Count, 0] = Current_process.get_Process_ID();
                scheduler_history[Count, 1] = End_time;
                mat_process[number].set_Waiting_Time(End_time - mat_process[number].get_Arrival_Time());
              
               End_time = End_time + Current_process.get_Burst_Time();
                scheduler_history[Count, 2] = End_time;
                Swap(ref mat_process[number], ref mat_process[Count]);
                Count++;

            }
            for (int i = 0; i < num_process; i++)
            {
                
               
                Console.WriteLine(" " + scheduler_history[i, 0] + "\t\t" + scheduler_history[i, 1] + "\t\t " + scheduler_history[i, 2]);

            }
            for (int i = 0; i < num_process; i++)
            {


                Console.WriteLine(mat_process[i].get_Waiting_Time());

            }
        }
        //swap function
        public static void Swap(ref Process num1, ref Process num2)
        {
            Process newnum = new Process(0, 0, 0, 0, 0);
            newnum = num1;
            num1 = num2;
            num2 = newnum;
        }
    }
}