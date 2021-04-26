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
    
    public partial class chart : Form
    {
        public static int counter;
      public float[,] drawing = new float[100,3];

        public chart()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {   for (int i = 0; i < counter; i++)
            {
                if (i == 0)
                {
                    this.CreateGraphics().DrawRectangle(Pens.Black, 20, 100, drawing[i,2]-drawing[i,1], 50);
                }
                else
                {
                    this.CreateGraphics().DrawRectangle(Pens.Black, 20+drawing[i-1,2], 100, drawing[i, 2] - drawing[i, 1], 50);
                }
            }
            
        }

        private void chart_Load(object sender, EventArgs e)
        {
            //index= Int32.Parse(main_form.no_of_processes);
            counter = RR_form.counter;
            for (int k = 0; k < counter; k++)
            {
                for (int j = 0; j < 3; j++)
                {
                    drawing[k, j] = RR_form.scheduler3cells[k, j];
                   // drawing[k, j] = j;
                }
            }
            
        }
    }
}
