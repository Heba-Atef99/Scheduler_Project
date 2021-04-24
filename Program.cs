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
            int[] is_completed = new int[num_process];
            int[] burst_remaining = new int[num_process];


            //take input from user & save it in objects of processes
            for (int i = 0; i < num_process; i++)
            {
                //initialize the process
                mat_process[i] = new Process(0, 0, 0, 0, 0);

                Console.WriteLine("\n...Process {0}...", i + 1);

                Console.WriteLine("Enter Process Id: ");
                mat_process[i].set_Process_ID(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Enter Arrival Time: ");
                mat_process[i].set_Arrival_Time(Convert.ToInt32(Console.ReadLine()));

                Console.WriteLine("Enter Burst Time: ");
                mat_process[i].set_Burst_Time(Convert.ToInt32(Console.ReadLine()));
                burst_remaining[i] = mat_process[i].get_Burst_Time();

                Console.WriteLine("Priority: ");
                mat_process[i].set_Priority(Convert.ToInt32(Console.ReadLine()));
            }
            Priority_Preemptive(mat_process, scheduler_history, burst_remaining, is_completed, num_process);
        }   //SFJ_non_Preemptive(mat_process, scheduler_history);

       
        static void Priority_Preemptive(Process[] mat_process, int[,] scheduler_history,int[] burst_remaining, int[] is_completed, int num_process )
        {
                int current_time = 0;
                int completed = 0;
                int prev = 0;

                while (completed != num_process)
                {
                    int idx = -1;
                    int mx = -1;
                    for (int i = 0; i < num_process; i++)
                    {
                        if (mat_process[i].get_Arrival_Time() <= current_time && is_completed[i] == 0)
                        {
                            if (mat_process[i].get_Priority() > mx)
                            {
                                mx = mat_process[i].get_Priority();
                                idx = i;
                            }
                            if (mat_process[i].get_Priority() == mx)
                            {
                                if (mat_process[i].get_Arrival_Time() < mat_process[idx].get_Arrival_Time())
                                {
                                    mx = mat_process[i].get_Priority();
                                    idx = i;
                                }
                            }
                        }
                    }

                    if (idx != -1)
                    {
                        if (burst_remaining[idx] == mat_process[idx].get_Burst_Time())
                        {
                            scheduler_history[idx, 1] = current_time;
                            scheduler_history[idx, 0] = mat_process[idx].get_Process_ID();
                            //scheduler_history[idx, 2] = current_time;
                            // mat_process[idx].start_time = current_time;
                            //total_idle_time += p[idx].start_time - prev;
                        }
                        burst_remaining[idx] -= 1;
                        current_time++;
                        prev = current_time;

                        if (burst_remaining[idx] == 0)
                        {
                            // scheduler_history[idx, 1] = current_time;
                            //scheduler_history[idx, 0] = mat_process[idx].get_Process_ID();
                            scheduler_history[idx, 2] = current_time;
                            /*mat_process[idx].completion_time = current_time;
                            p[idx].turnaround_time = p[idx].completion_time - p[idx].arrival_time;
                            p[idx].waiting_time = p[idx].turnaround_time - p[idx].burst_time;
                            p[idx].response_time = p[idx].start_time - p[idx].arrival_time;

                            total_turnaround_time += p[idx].turnaround_time;
                            total_waiting_time += p[idx].waiting_time;
                            total_response_time += p[idx].response_time;
                            */
                            is_completed[idx] = 1;
                            completed++;
                        }
                    }
                    else
                    {
                        current_time++;
                    }
                }
                for (int i = 0; i < scheduler_history.Length; i++)
                {

                    Console.WriteLine(" " + scheduler_history[i, 0] + "\t\t" + scheduler_history[i, 1] + "\t\t " + scheduler_history[i, 2]);

                }
            }
        }
    }


