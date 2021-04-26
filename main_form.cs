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
    public partial class main_form : Form
    {
        public static string no_of_processes;
        public static string type;
        public main_form()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if(CbSehedulerType.SelectedItem=="FCFS"|| CbSehedulerType.SelectedItem == "SJF Nonpreemtive"|| CbSehedulerType.SelectedItem == "SJF Preemtive")
            {
                no_of_processes = NoProcesses.Text;
                type = CbSehedulerType.Text;
                SJF_FCFS form = new SJF_FCFS();
                //information_input.
                form.ShowDialog();

            }
            
            
            if (CbSehedulerType.SelectedItem == "Pariority Nonpreemtive"|| CbSehedulerType.SelectedItem == "Pariority Preemtive")
            {
               
                no_of_processes = NoProcesses.Text;
                type = CbSehedulerType.Text;
                //SJF_FCFS form = new SJF_FCFS();

                //form.ShowDialog();


            }

            if (CbSehedulerType.SelectedItem == "Round Robin")
            {
                no_of_processes = NoProcesses.Text;
                //type = CbSehedulerType.Text;
                RR_form form = new RR_form();

                form.ShowDialog();


            }
        }
    }
}
