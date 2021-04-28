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
    public partial class SJF_FCFS : Form
    {
        public static int index;
        public static float[,] scheduler3cells = new float[100, 3];
        public static float[,] scheduler4cells = new float[100, 4];
        public static string Arrival;
        public static string Burst;
        public static string ID;
        public static string Priority;
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



        static void SJF_non_Preemptive(Process[] mat_process, float[,] scheduler_history)
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
                        if (mat_process[i].get_Arrival_Time() <= End_time && mat_process[i].get_Burst_Time() < Current_process.get_Burst_Time())
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

        }
        static float SJF_Preemptive(Process[] mat_process, List<sh_element> scheduler_history)
        {
            //save the array in a list to make operations on list easily
            List<Process> ready = mat_process.ToList();
            //sort the ready processes by the arrival time
            ready = ready.OrderBy(process => process.get_Arrival_Time()).ThenBy(process => process.get_Burst_Time()).ToList();

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
                if (ready[0].get_Burst_Time() < ready[1].get_Burst_Time())
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

                    if (ready[1].get_Burst_Time() < current_burst_time_left)
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
                        wait = wait.OrderBy(process => process.get_Burst_Time()).ThenBy(process => process.get_Arrival_Time()).ToList();

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
                        wait = wait.OrderBy(process => process.get_Burst_Time()).ThenBy(process => process.get_Arrival_Time()).ToList();
                        if (ready[0].get_Burst_Time() > wait[0].get_Burst_Time())
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

            wait = wait.OrderBy(process => process.get_Burst_Time()).ThenBy(process => process.get_Arrival_Time()).ToList();
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

            //calculate the waiting time for each process
            List<sh_element> get_waiting_time = scheduler_history.OrderBy(process => process.process_id).ThenBy(process => process.start).ToList();
            int id = get_waiting_time[0].process_id;
            float waiting_time = 0;
            int is_last_repeated = 0;//to check if the last element in list is repeated or not
            float first_start = get_waiting_time[0].start;
            int j = 1;
            float avg_waiting = 0;

            while (get_waiting_time.Count > 1)
            {
                j = 1;
                is_last_repeated = 0;
                //calculate the waiting time for un-repeated process
                //waiting time = start of current process - arrival time for that process
                waiting_time = get_waiting_time[0].start - Array.Find(mat_process, p => p.get_Process_ID() == id).get_Arrival_Time();

                while (get_waiting_time[j].process_id == id)
                {
                    //calculate the waiting time for repeated process
                    //waiting time = (start of next same process - end of last same process) + prev value
                    waiting_time += (get_waiting_time[j].start - get_waiting_time[j - 1].end);
                    j++;
                    is_last_repeated = 1;

                    if (j >= get_waiting_time.Count) break;
                }
                //save it in the process
                Array.Find(mat_process, p => p.get_Process_ID() == id).set_Waiting_Time(waiting_time);

                //remove all elements with same id
                get_waiting_time.RemoveRange(0, j);
                //update id
                if (get_waiting_time.Count > 0) id = get_waiting_time[0].process_id;
                avg_waiting += waiting_time;
            }

            //for the last element in the list
            if (is_last_repeated != 1 && get_waiting_time.Count > 0)
            {
                //calculate the waiting time of the last element if it is not repeated
                waiting_time = get_waiting_time[0].start - Array.Find(mat_process, p => p.get_Process_ID() == id).get_Arrival_Time();

                //save that waiting time
                Array.Find(mat_process, p => p.get_Process_ID() == id).set_Waiting_Time(waiting_time);
                avg_waiting += waiting_time;
            }

            avg_waiting /= mat_process.Length;
            return avg_waiting;
        }
    
    public static void Swap(ref Process num1, ref Process num2)
        {
            Process newnum = new Process(0, 0, 0, 0, 0);
            newnum = num1;
            num1 = num2;
            num2 = newnum;
        }

        static void First_come_first_served(Process[]mat_process, float[,] scheduler_history)
        {
            mat_process = mat_process.OrderBy(process=> process.get_Arrival_Time()).ToArray();
           float End_time =  0;

            for (int i = 0; i <
            mat_process.Length; i++)
            {
            if (mat_process[i].get_Arrival_Time() <= End_time)

                {
                    
                    scheduler_history[i,0] = mat_process[i].get_Process_ID();

                    scheduler_history[i, 1] = End_time;

                    mat_process[i].set_Waiting_Time(End_time - mat_process[i].get_Arrival_Time());

                    End_time = End_time + mat_process[i].get_Burst_Time();

                     scheduler_history[i, 2] = End_time;

                 }


                else


                {


                    scheduler_history[i, 0] = mat_process[i].get_Process_ID();



                    End_time = mat_process[i].get_Arrival_Time();


                    scheduler_history[i, 1] = End_time;

                    mat_process[i].set_Waiting_Time(End_time - mat_process[i].get_Arrival_Time());

                    End_time = End_time + mat_process[i].get_Burst_Time();


                    scheduler_history[i, 2] = End_time;



                }


            }





        }

        public SJF_FCFS()
        {
            
            InitializeComponent();
            
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void SJF_FCFS_Load(object sender, EventArgs e)
        {
            type = main_form.type;
            index = Int32.Parse(main_form.no_of_processes);
        }

        private void button1_Click(object sender, EventArgs e)
        {
           // if (type == "FCFS" || type == "SJF Nonpreemtive" || type == "SJF Preemtive")
            //{
                
                if (n == index - 1)
                {
                    string message = "You've entred more than the indicated number of processes";
                    MessageBox.Show(message);
                }
                else
                {
                    n = dgv3cells.Rows.Add();

                    dgv3cells.Rows[n].Cells[0].Value = tbID.Text;
                    dgv3cells.Rows[n].Cells[1].Value = tbArrival.Text;
                    dgv3cells.Rows[n].Cells[2].Value = tbBurst.Text;

                    tbID.Clear();
                    tbBurst.Clear();
                    tbArrival.Clear();
                }
            //}
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (type == "SJF Nonpreemtive")
            {
                int[,] table = new int[index, 3];
                // fill the 2D array tabel from the dataGridView
                for (int r = 0; r < dgv3cells.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgv3cells.Rows[r].Cells.Count; c++)
                    {
                        table[r, c] = Convert.ToInt32(dgv3cells.Rows[r].Cells[c].Value);
                    }
                }

                Process[] mat_process = new Process[index];
                float[,] scheduler_history = new float[index, 3];

                //fill the mat_process from the table matrix
                for (int i = 0; i < index; i++)
                {
                    mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], 0, 0);
                }
                SJF_non_Preemptive(mat_process, scheduler_history);
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
            if(type == "SJF Preemtive")
            {

                int[,] table = new int[index, 3];
                // fill the 2D array tabel from the dataGridView
                for (int r = 0; r < dgv3cells.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgv3cells.Rows[r].Cells.Count; c++)
                    {
                        table[r, c] = Convert.ToInt32(dgv3cells.Rows[r].Cells[c].Value);
                    }
                }

                Process[] mat_process = new Process[index];
                // float[,] scheduler_history = new float[index, 3];
                List<sh_element> scheduler_history_list = new List<sh_element>();

                //fill the mat_process from the table matrix
                for (int i = 0; i < index; i++)
                {
                    //mat_process[i] = new Process(0, 0, 0, 0, 0);
                    mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], 0, 0);
                }
              avg_wait=  SJF_Preemptive(mat_process, scheduler_history_list);
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
            if(type=="FCFS")
            {
                counter = index;
                int[,] table = new int[index, 3];
                // fill the 2D array tabel from the dataGridView
                for (int r = 0; r < dgv3cells.Rows.Count - 1; r++)
                {
                    for (int c = 0; c < dgv3cells.Rows[r].Cells.Count; c++)
                    {
                        table[r, c] = Convert.ToInt32(dgv3cells.Rows[r].Cells[c].Value);
                    }
                }

                Process[] mat_process = new Process[index];
                float[,] scheduler_history = new float[index, 3];

                //fill the mat_process from the table matrix
                for (int i = 0; i < index; i++)
                {
                    mat_process[i] = new Process(0, 0, 0, 0, 0);
                    mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], 0, 0);
                }
                First_come_first_served(mat_process, scheduler_history);
                for (int i = 0; i < index; i++)
                {
                    sum_wait += mat_process[i].get_Waiting_Time();
                }
                avg_wait = sum_wait / index;
                scheduler3cells = scheduler_history;
                chart frm = new chart();
                frm.ShowDialog();
            }
        }

        private void SJF_FCFS_Load_1(object sender, EventArgs e)
        {

            type = main_form.type;
            index = Int32.Parse(main_form.no_of_processes);
        }
    }
}
