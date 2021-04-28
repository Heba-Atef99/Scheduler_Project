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
    public partial class RR_form : Form
    {
        public static int index;
        public static int counter;
        public static float[,] scheduler3cells = new float[100, 3];
        //public static float[,] scheduler4cells = new float[100, 4];
        public static string Arrival;
        public static string Burst;
        public static string ID;
        public static string Quantumvalue;
        //public static string Priority;
        public int Quantum;
        public static float avg_wait;
        public int n = 0;
        // public string type;
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
        class Process
        {
            //public int pid;
            //public int arrival_time;
            //public int burst_time;
            //public int remaining_time;
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
                //this.Remaining_Time = Remaining_Time;
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
            public void set_Waiting_Time(int Waiting_Time)
            {
                this.Waiting_Time = Waiting_Time;
            }
            public float get_Waiting_Time()
            {
                return this.Waiting_Time;
            }

            //public void set_Remaining_Time(int Remaining_Time)
            //{
            //    this.Remaining_Time = Remaining_Time;
            //}
            //public int get_Remaining_Time()
            //{
            //    return this.Remaining_Time;
            //}


        }
        static float Round_Robin(Process[] mat_process, List<sh_element> scheduler_history_list, int time_quantum)
        {
            int counter = 0, x; //x is the remaining no. of processes
            float total_time_taken = 0;
            int num_process = mat_process.Length;
            
           // Console.WriteLine("Enter Time Quantum");
           // time_quantum = Convert.ToInt32();
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
                    //j = 0;
                    int past_processes_ended = 1; // all past processes ended
                    for (int i = j; i >= 0; i--)
                    {
                        if (sorted_mat_process[j].get_Burst_Time() != 0)
                        {
                            past_processes_ended = 0;

                        }
                    }
                    if (past_processes_ended == 1)
                    {
                        total_time_taken = sorted_mat_process[j + 1].get_Arrival_Time();
                        j++;
                    }

                    else
                    {
                        j = 0;
                    }
                }
            }
            for (int i = 0; i < counter; i++)
            {
                Console.WriteLine("process id " + scheduler_history_list[i].process_id + " starts at "
                        + scheduler_history_list[i].start + " and ends at " + scheduler_history_list[i].end);
            }
            // Console.WriteLine("total time taken is " + total_time_taken);
            float total_wait = 0;

            for (int i = 0; i < mat_process.Count(); i++) // loops on processes
            {
                float process_wait = 0; // total wait time of one process
                int count = 0;// to check it's the first time of process in list
                int last_index = 0; // points at the last time this process was executed
                for (int n = 0; n < scheduler_history_list.Count; n++) // loops in scheduler_history
                {

                    //to get the first waiting time = first time process executed - arrival time

                    if (mat_process[i].get_Process_ID() == scheduler_history_list[n].process_id & count == 0)
                    {
                        process_wait += (scheduler_history_list[n].start) - (mat_process[i].get_Arrival_Time());
                        count = 1;
                        last_index = n;
                    }
                    // to get the rest of waiting time = start(current)-end(last)
                    else if (mat_process[i].get_Process_ID() == scheduler_history_list[n].process_id & count != 0)
                    {
                        process_wait += (scheduler_history_list[n].start) - (scheduler_history_list[(last_index)].end);
                        last_index = n;
                        count = 1;
                    }

                }
                total_wait += process_wait;
            }
            float avg_wait = (total_wait) / (mat_process.Count());
            return avg_wait;

        }

        public RR_form()
        {
            InitializeComponent();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if (n == index - 1)
            {
                string message = "You've entred more than the indicated number of processes";
                MessageBox.Show(message);
            }
            else
            {
                n = dgvQuantum.Rows.Add();

                dgvQuantum.Rows[n].Cells[0].Value = tbID.Text;
                dgvQuantum.Rows[n].Cells[1].Value = tbArrival.Text;
                dgvQuantum.Rows[n].Cells[2].Value = tbBurst.Text;

                tbID.Clear();
                tbBurst.Clear();
                tbArrival.Clear();
               // tbQuantum.Clear();
            }
        }

        private void tbID_TextChanged(object sender, EventArgs e)
        {

        }

        private void RR_form_Load(object sender, EventArgs e)
        {
            index = Int32.Parse(main_form.no_of_processes);
            //Quantum = Int32.Parse(tbQuantum.Text);
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            // Quantum = Int32.Parse(tbQuantum.Text);
            Quantumvalue = tbQuantum.Text;
            Quantum = Int32.Parse(Quantumvalue);
            int[,] table = new int[index, 3];
            // fill the 2D array tabel from the dataGridView
            for (int r = 0; r < dgvQuantum.Rows.Count - 1; r++)
            {
                for (int c = 0; c < dgvQuantum.Rows[r].Cells.Count; c++)
                {
                    table[r, c] = Convert.ToInt32(dgvQuantum.Rows[r].Cells[c].Value);
                }
            }

            Process[] mat_process = new Process[index];

            List<sh_element> scheduler_history_list = new List<sh_element>();
            //float[,] scheduler_history = new float[index, 3];

            //fill the mat_process from the table matrix
            for (int i = 0; i < index; i++)
            {
                mat_process[i] = new Process(0, 0, 0, 0, 0);
                mat_process[i] = new Process(table[i, 0], table[i, 1], table[i, 2], 0, 0);

            }
            avg_wait=Round_Robin(mat_process, scheduler_history_list,Quantum);
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
