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
                mat_process[i].set_Arrival_Time(float.Parse(Console.ReadLine()));

                Console.WriteLine("Enter Burst Time: ");
                mat_process[i].set_Burst_Time(float.Parse(Console.ReadLine()));


                //Console.WriteLine("Priority: ");
                //mat_process[i].set_Priority(Convert.ToInt32(Console.ReadLine()));
            }
            SJF_Preemptive(mat_process, scheduler_history_list);

        }

        static void SJF_Preemptive(Process[] mat_process, List<sh_element> scheduler_history)
        {
            //save the array in a list to make operations on list easily
            List<Process> ready = mat_process.ToList();
            //sort the ready processes by the arrival time
            ready = ready.OrderBy(process => process.get_Arrival_Time()).ToList();

            //waiting list for waiting processes
            List<Process> wait = new List<Process>();

            float next_arrival = ready[1].get_Arrival_Time(); //arrival of the next process
            float current_arrival = ready[0].get_Arrival_Time(); //arrival of the next process
            float current_burst_time_left = 0; //execution time left for the process
            float current_end = 0;
            int sh_index = 0; //index of the scheduler history array

            //start a process
            if (next_arrival == current_arrival)
            {
                if(ready[0].get_Burst_Time() < ready[1].get_Burst_Time())
                {
                    //start the current process
                    scheduler_history.Add(new sh_element()
                    {
                        process_id = ready[0].get_Process_ID(),
                        start = current_arrival,
                        end = current_arrival + ready[0].get_Burst_Time()
                    });
                    sh_index++;

                    //put next process in wait & remove from ready
                    wait.Add(ready[1]);
                    ready.RemoveAt(1);
                }

                else
                {
                    //start the current process
                    scheduler_history.Add(new sh_element()
                    {
                        process_id = ready[1].get_Process_ID(),
                        start = current_arrival,
                        end = current_arrival + ready[1].get_Burst_Time()
                    });
                    sh_index++;

                    //put next process in wait & remove from ready
                    wait.Add(ready[0]);
                    ready.RemoveAt(0);
                }
            }

            else
            {
                //start the current process
                scheduler_history.Add(new sh_element()
                {
                    process_id = ready[0].get_Process_ID(),
                    start = current_arrival,
                    end = current_arrival + ready[0].get_Burst_Time()
                });
                sh_index++;
            }

            //for each process starting from process 2 
            for (int i = 1; ready.Count != 1; i++)
            {
                next_arrival = ready[1].get_Arrival_Time();
                current_arrival = ready[0].get_Arrival_Time();
                current_end = scheduler_history[sh_index - 1].end;

                if (next_arrival < current_end)
                {
                    //an intrrupt happens

                    //update the burst time
                    //current_burst_time_left = ready[0].get_Burst_Time() - (next_arrival - current_arrival);
                    current_burst_time_left = current_end - next_arrival;
                    ready[0].set_Burst_Time(current_burst_time_left);

                    if (ready[1].get_Burst_Time() < current_burst_time_left)
                    {
                        //inturrept current process
                        //end current process
                        scheduler_history[sh_index - 1].end = next_arrival;
                        wait.Add(ready[0]);
                        ready.RemoveAt(0);

                        //start next process
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = ready[0].get_Process_ID(),
                            start = next_arrival,
                            end = next_arrival + ready[0].get_Burst_Time()
                        });
                        sh_index++;
                    }
                    else
                    {
                        wait.Add(ready[1]);
                        ready.RemoveAt(1);
                    }
                }

                else if (next_arrival > current_end)
                {
                    //end current process
                    //scheduler_history[sh_index - 1].end = current_arrival + ready[0].get_Burst_Time();
                    ready.RemoveAt(0);

                    if (wait.Count > 0)
                    {
                        wait = wait.OrderBy(process => process.get_Burst_Time()).ToList();
                        //start waiting process
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = wait[0].get_Process_ID(),
                            start = scheduler_history[sh_index - 1].end,
                            end = scheduler_history[sh_index - 1].end + wait[0].get_Burst_Time()
                        });
                        sh_index++;

                        ready.Insert(0, wait[0]);
                        wait.RemoveAt(0);
                        //update burst time
                        current_burst_time_left = ready[0].get_Burst_Time() - (ready[1].get_Arrival_Time() - scheduler_history[sh_index - 1].start);
                        ready[0].set_Burst_Time(current_burst_time_left);
                    }
                    else
                    {
                        //start next process
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = ready[0].get_Process_ID(),
                            start = next_arrival,
                            end = next_arrival + ready[0].get_Burst_Time()
                        });
                        sh_index++;

                    }
                }

                else
                {
                    //next process starts right after the current process

                    //end current process
                    //scheduler_history[sh_index - 1].end = current_arrival + ready[0].get_Burst_Time();
                    scheduler_history[sh_index - 1].end = next_arrival;
                    ready.RemoveAt(0);

                    wait = wait.OrderBy(process => process.get_Burst_Time()).ToList();
                    if (ready[0].get_Burst_Time() < wait[0].get_Burst_Time())
                    {
                        //start next process
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = ready[0].get_Process_ID(),
                            start = next_arrival,
                            end = next_arrival + ready[0].get_Burst_Time()
                        });
                        sh_index++;
                    }
                    else
                    {
                        //start waiting process
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = wait[0].get_Process_ID(),
                            start = scheduler_history[sh_index - 1].end,
                            end = scheduler_history[sh_index - 1].end + wait[0].get_Burst_Time()
                        });
                        sh_index++;

                        //put next process in wait
                        wait.Add(ready[0]);
                        ready.RemoveAt(0);

                        //insert the waited process in ready
                        ready.Insert(0, wait[0]);
                        wait.RemoveAt(0);
                    }
                }
            }

            wait = wait.OrderBy(process => process.get_Burst_Time()).ToList();
            //check all processes in the waiting list
            for (int i = 0; i < wait.Count; i++)
            {
                //save the start & end time of the shortest remaining time process
                scheduler_history.Add(new sh_element()
                {
                    process_id = wait[i].get_Process_ID(),
                    start = scheduler_history[sh_index - 1].end,
                    end = wait[i].get_Burst_Time() + scheduler_history[sh_index - 1].end
                });

                sh_index++;
            }

            for (int i = 0; i < scheduler_history.Count; i++)
            {
                Console.WriteLine("Process Id: {0}", scheduler_history[i].process_id);
                Console.WriteLine("Start Time: {0}", scheduler_history[i].start);
                Console.WriteLine("End Time: {0}", scheduler_history[i].end);
                Console.WriteLine("\n\n");
            }


        }
    }
}

