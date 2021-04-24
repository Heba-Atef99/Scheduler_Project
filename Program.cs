using System;
using System.Collections.Generic;
using System.Linq;

namespace RR_trial
{
    class Program
    {
        static void Main(string[] args)
        {
            //int counter=0, x, total_time_taken = 0, time_quantum; //x is the remaining no. of processe
            Console.WriteLine("Enter number of Processes: ");
            int num_process = Convert.ToInt32(Console.ReadLine());

            Process[] mat_process = new Process[num_process]; //an array of processes taken from user

            //the history of processes as the element of this array consists of 3 parts
            //first the process id, second the start time of the process, third the end time of the process
            List<sh_element> scheduler_history_list = new List<sh_element>();

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

                
                //Console.WriteLine("Priority: ");
                //mat_process[i].set_Priority(Convert.ToInt32(Console.ReadLine()));
            }
        

        //        //SFJ_Preemptive(mat_process, scheduler_history);
                Round_Robin(mat_process,scheduler_history_list);

        }

        static void Round_Robin(Process[] mat_process,List<sh_element> scheduler_history_list )
        {
            int counter = 0, x, total_time_taken = 0, time_quantum; //x is the remaining no. of processes
            int num_process = mat_process.Length;
            Console.WriteLine("Enter Time Quantum");
            time_quantum = Convert.ToInt32(Console.ReadLine());
            //sort the array of processes acc to arrival time
            Process[] sorted_mat_process = new Process[num_process]; 
            for (int i = 0; i < num_process; i++)
            {
                //initialize the sorted processes
                sorted_mat_process[i] = new Process(0, 0, 0, 0, 0);
            }
            sorted_mat_process = mat_process.OrderBy(p => p.get_Arrival_Time()).ToArray();
            x = num_process; //initially the number of remaining processes equals all no. of processes
            int j;
            //List<sh_element> scheduler_history_list = new List<sh_element>();
            for (total_time_taken = 0, j = 0; x != 0;)
            {
                if (sorted_mat_process[j].get_Burst_Time() <= time_quantum && sorted_mat_process[j].get_Burst_Time() > 0)
                {
                    scheduler_history_list.Add(new sh_element()
                    {
                        process_id = sorted_mat_process[j].get_Process_ID(),
                        start = total_time_taken,
                        end = (total_time_taken + sorted_mat_process[j].get_Burst_Time())
                    }
                                );
                    total_time_taken = total_time_taken + sorted_mat_process[j].get_Burst_Time();
                    sorted_mat_process[j].set_Burst_Time(0);
                    x--;
                    counter++;
                }
                else if (sorted_mat_process[j].get_Burst_Time() > 0)
                {
                    //sh_element process_element = new sh_element();
                    //process_element.set_all(sorted_mat_process[j].get_Process_ID(),
                    //    total_time_taken, (total_time_taken + time_quantum));
                    //scheduler_history_list.Add(process_element);
                    scheduler_history_list.Add(new sh_element()
                    {
                        process_id = sorted_mat_process[j].get_Process_ID(),
                        start = total_time_taken,
                        end = (total_time_taken + time_quantum)
                    });


                    sorted_mat_process[j].set_Burst_Time(sorted_mat_process[j].get_Burst_Time() - time_quantum);
                    total_time_taken = total_time_taken + time_quantum;
                    counter++;
                }
                if (j == num_process - 1) //loop around the processes again
                {
                    j = 0;
                }
                else if (sorted_mat_process[j + 1].get_Arrival_Time() <= total_time_taken) //if a new process has arrived
                {
                    j++;
                }
                else
                {
                    j = 0;
                }
            }
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("process id " + scheduler_history_list[i].process_id + " starts at "
                        + scheduler_history_list[i].start + " and ends at " + scheduler_history_list[i].end);
            }
            Console.WriteLine("total time taken is " + total_time_taken);
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

        }    


    }//brace of class program
}//brace of namespace
