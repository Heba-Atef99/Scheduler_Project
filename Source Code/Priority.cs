using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Scheduler_GUI
{
    public partial class Priority : Form
    {
        public static int index;
        public static float[,] scheduler3cells = new float[100, 3];
        public static float[,] scheduler4cells = new float[100, 4];
        public static string Arrival;
        public static string Burst;
        public static string ID;
        public static string priority;
        public static string Quantum;
        public int n = 0;
        public string type;
        public static int counter;
        public static float avg_wait;
        public float sum_wait = 0;
        public class sh_element
        {
            public int process_id;
            public float start;
            public float end;

            public void set_all(int id, float s, float e)
            {
                this.process_id = id;
                this.start = s;
                this.end = e;
            }
        }
        public class Process
        {

            private int Process_ID; // Process ID
            private float Arrival_Time; // Arrival Time
            private float Burst_Time; // Burst Time
            private float Waiting_Time;
            private int Priority;

            public Process(int Process_ID, float Arrival_Time, float Burst_Time, int Priority, float Waiting_Time)
            {
                this.Process_ID = Process_ID;
                this.Arrival_Time = Arrival_Time;
                this.Burst_Time = Burst_Time;
                this.Waiting_Time = Waiting_Time;
                this.Priority = Priority;
            }
            public void set_Process_ID(int Process_ID)
            {
                this.Process_ID = Process_ID;
            }
            public int get_Process_ID()
            {
                return this.Process_ID;
            }
            public void set_Burst_Time(float Burst_Time)
            {
                this.Burst_Time = Burst_Time;
            }
            public float get_Burst_Time()
            {
                return this.Burst_Time;
            }
            public void set_Arrival_Time(float Arrival_Time)
            {
                this.Arrival_Time = Arrival_Time;
            }
            public float get_Arrival_Time()
            {
                return this.Arrival_Time;
            }
            public void set_Priority(int Priority)
            {
                this.Priority = Priority;
            }
            public int get_Priority()
            {
                return this.Priority;
            }
            public void set_Waiting_Time(float Waiting_Time)
            {
                this.Waiting_Time = Waiting_Time;
            }
            public float get_Waiting_Time()
            {
                return this.Waiting_Time;
            }
        }
        static void Priority_non_Preemptive(Process[] mat_process, float[,] scheduler_history)
        {
            mat_process = mat_process.OrderBy(process => process.get_Arrival_Time()).ToArray();
            int number = 0;
            Process Current_process = new Process(0, 0, 0, 0, 0);
            Current_process = mat_process[0];
            float End_time = 0;
            int Count = 0;
            for (int j = Count; j < mat_process.Length; j++)
            {
                if (End_time > 0 && mat_process[j].get_Arrival_Time() > End_time)
                {
                    Current_process = mat_process[j];
                    number = j;
                    scheduler_history[Count, 0] = Current_process.get_Process_ID();
                    End_time = mat_process[j].get_Arrival_Time();
                    scheduler_history[Count, 1] = End_time;
                    mat_process[number].set_Waiting_Time(End_time - mat_process[number].get_Arrival_Time());
                    End_time = End_time + Current_process.get_Burst_Time();
                    scheduler_history[Count, 2] = End_time;
                    Swap(ref mat_process[number], ref mat_process[Count]);
                    Count++;


                }

                else
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

            }
            for (int i = 0; i < mat_process.Length; i++)
            {


                Console.WriteLine(" " + scheduler_history[i, 0] + "\t\t" + scheduler_history[i, 1] + "\t\t " + scheduler_history[i, 2]);

            }
            for (int i = 0; i < mat_process.Length; i++)
            {


                Console.WriteLine(mat_process[i].get_Waiting_Time());

            }

        }
        public static void Swap(ref Process num1, ref Process num2)
        {
            Process newnum = new Process(0, 0, 0, 0, 0);
            newnum = num1;
            num1 = num2;
            num2 = newnum;
        }
        float Priority_Preemptive(Process[] mat_process, List<sh_element> scheduler_history)
        {
            //save the array in a list to make operations on list easily
            List<Process> ready = mat_process.ToList();
            //sort the ready processes by the arrival time
            ready = ready.OrderBy(process => process.get_Arrival_Time()).ThenBy(process => process.get_Priority()).ToList();

            //waiting list for waiting processes
            List<Process> wait = new List<Process>();

            float next_arrival = ready[1].get_Arrival_Time(); //arrival of the next process
            float current_arrival = ready[0].get_Arrival_Time(); //arrival of the next process
            float current_burst_time_left = 0; //execution time left for the process
            float current_end = 0;
            int sh_index = 0; //index of the scheduler history array

            //execute the first process
            if (next_arrival == current_arrival)
            {
                if (ready[0].get_Priority() < ready[1].get_Priority())
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

            //executing each process in ready list starting from process 2 
            while (ready.Count != 1)
            {
                next_arrival = ready[1].get_Arrival_Time();
                current_arrival = ready[0].get_Arrival_Time();
                current_end = scheduler_history[sh_index - 1].end;

                if (next_arrival < current_end)
                {
                    //an intrrupt happens

                    //update the burst time
                    current_burst_time_left = current_end - next_arrival;
                    ready[0].set_Burst_Time(current_burst_time_left);

                    if (ready[1].get_Priority() < ready[0].get_Priority())
                    {
                        //inturrept current process &
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
                        //continue the current process
                        //put next process in wait & remove it from ready list
                        wait.Add(ready[1]);
                        ready.RemoveAt(1);
                    }
                }

                else if (next_arrival > current_end)
                {
                    //the current process reached its end
                    ready.RemoveAt(0);

                    //check the waiting list 
                    if (wait.Count > 0)
                    {
                        wait = wait.OrderBy(process => process.get_Priority()).ThenBy(process => process.get_Arrival_Time()).ToList();

                        //start waiting process as the next process has not arrived yet
                        scheduler_history.Add(new sh_element()
                        {
                            process_id = wait[0].get_Process_ID(),
                            start = scheduler_history[sh_index - 1].end,
                            end = scheduler_history[sh_index - 1].end + wait[0].get_Burst_Time()
                        });
                        sh_index++;
                        //insert that waiting process in ready & remove it from wait list
                        ready.Insert(0, wait[0]);
                        wait.RemoveAt(0);

                        //update burst time as it is used in waiting list for ordering it 
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
                    //next process starts right after the current process finishes

                    //end current process
                    scheduler_history[sh_index - 1].end = next_arrival;
                    ready.RemoveAt(0);

                    if (wait.Count > 0)
                    {
                        //compare the next process with the waiting process
                        wait = wait.OrderBy(process => process.get_Priority()).ThenBy(process => process.get_Arrival_Time()).ToList();
                        if (ready[0].get_Priority() > wait[0].get_Priority())
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

                            //skip the loop so that the code this condition wont get executed
                            continue;
                        }
                    }

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

            wait = wait.OrderBy(process => process.get_Priority()).ThenBy(process => process.get_Arrival_Time()).ToList();
            //execute all processes in the waiting list
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

            //calulate waiting time
            float total_wait = 0;

            for (int i = 0; i < mat_process.Count(); i++) // loops on processes
            {
                float process_wait = 0; // total wait time of one process
                int count = 0;// to check it's the first time of process in list
                int last_index = 0; // points at the last time this process was executed
                for (int j = 0; j < scheduler_history.Count; j++) // loops in scheduler_history
                {


                    //to get the first waiting time = first time process executed - arrival time

                    if (mat_process[i].get_Process_ID() == scheduler_history[j].process_id & count == 0)
                    {
                        process_wait += (scheduler_history[j].start) - (mat_process[i].get_Arrival_Time());
                        count = 1;
                        last_index = j;
                    }
                    // to get the rest of waiting time = start(current)-end(last)
                    else if (mat_process[i].get_Process_ID() == scheduler_history[j].process_id & count != 0)
                    {
                        process_wait += (scheduler_history[j].start) - (scheduler_history[(last_index)].end);
                        last_index = j;
                        count = 1;
                    }

                }
                total_wait += process_wait;
            }
            float avg_wait = (total_wait) / (mat_process.Count());

            return avg_wait;
        }
        public Priority()
        {
            InitializeComponent();
        }

        private void btnInsert_Click(object sender, EventArgs e)
        {
            if (n == index - 1)
            {
                string message = "You've entred more than the indicated number of processes";
                MessageBox.Show(message);
            }
            else
            {
                n = dgv4cells.Rows.Add();

                dgv4cells.Rows[n].Cells[0].Value = tbID.Text;
                dgv4cells.Rows[n].Cells[1].Value = tbArrival.Text;
                dgv4cells.Rows[n].Cells[2].Value = tbBurst.Text;
                dgv4cells.Rows[n].Cells[3].Value = tbPriority.Text;

                tbID.Clear();
                tbBurst.Clear();
                tbArrival.Clear();
                tbPriority.Clear();
            }
        }

        private void Priority_Load(object sender, EventArgs e)
        {
            type = main_form.type;
            index = Int32.Parse(main_form.no_of_processes);
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            if (type == "Priority Nonpreemtive")
            {
                int[,] table = new int[index, 4];
                // fill the 2D array tabel from the dataGridView
                for (int r = 0; r < dgv4cells.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgv4cells.Rows[r].Cells.Count; c++)
                    {
                        table[r, c] = Convert.ToInt32(dgv4cells.Rows[r].Cells[c].Value);
                    }
                }

                Process[] mat_process = new Process[index];
                float[,] scheduler_history = new float[index, 3];

                //fill the mat_process from the table matrix
                for (int i = 0; i < index; i++)
                {
                    mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], table[i, 3], 0);
                }
                Priority_non_Preemptive(mat_process, scheduler_history);
                counter = index;
                for (int i = 0; i < index; i++)
                {
                    sum_wait += mat_process[i].get_Waiting_Time();
                }
                avg_wait = sum_wait / index;

                for (int k = 0; k < index; k++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        scheduler3cells[k, j] = scheduler_history[k, j];
                    }
                }

                chart frm = new chart();
                frm.ShowDialog();
            }
            if (type == "Priority Preemtive")
            {
                int[,] table = new int[index, 4];
                // fill the 2D array tabel from the dataGridView
                for (int r = 0; r < dgv4cells.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgv4cells.Rows[r].Cells.Count; c++)
                    {
                        table[r, c] = Convert.ToInt32(dgv4cells.Rows[r].Cells[c].Value);
                    }
                }

                Process[] mat_process = new Process[index];
                List<sh_element> scheduler_history_list = new List<sh_element>();

                //fill the mat_process from the table matrix
                for (int i = 0; i < index; i++)
                {
                    mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], table[i, 3], 0);
                }
                avg_wait = Priority_Preemptive(mat_process, scheduler_history_list);

                counter = scheduler_history_list.Count;
                for (int k = 0; k < counter; k++)
                {
                    scheduler3cells[k, 0] = scheduler_history_list[k].process_id;
                    scheduler3cells[k, 1] = scheduler_history_list[k].start;
                    scheduler3cells[k, 2] = scheduler_history_list[k].end;

                    //scheduler3cells[k, j] = scheduler_history[k, j];
                }
                chart frm = new chart();
                frm.ShowDialog();
            }

        }
    }
}
   
