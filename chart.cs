using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Scheduler_GUI
{
    
    public partial class chart : Form
    {
        public static int counter;
        public static int index;
        public static float avgwait;
        public static string type;
        
        public float[,] drawing = new float[100,3];

        public chart()
        {
            InitializeComponent();
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            switch (type)
            {
                case "FCFS":
                    index = Int32.Parse(main_form.no_of_processes);
                    counter = index;
                    for (int k = 0; k < counter; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            drawing[k, j] = SJF_FCFS.scheduler3cells[k, j];
                        }
                    }
                    break;
                case "SJF Nonpreemtive":
                    index = Int32.Parse(main_form.no_of_processes);
                    counter = index;
                    for (int k = 0; k < counter; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            drawing[k, j] = SJF_FCFS.scheduler3cells[k, j];
                        }
                    }
                    break;
                case "SJF Preemtive":
                    index = Int32.Parse(main_form.no_of_processes);
                    counter = SJF_FCFS.counter;
                    for (int k = 0; k < counter; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            drawing[k, j] = SJF_FCFS.scheduler3cells[k, j];
                        }
                    }
                    break;
                case "Round Robin":

                    index = Int32.Parse(main_form.no_of_processes);
                    counter = RR_form.counter;
                    avgwait = RR_form.avg_wait;
                    lblWaiting.Text = avgwait.ToString();
                    for (int k = 0; k < counter; k++)
                    {
                        for (int j = 0; j < 3; j++)
                        {
                            drawing[k, j] = RR_form.scheduler3cells[k, j];
                        }
                    }
                    break;
                case "Priority Nonpreemtive":
                    break;
                case "Priority Preemtive":
                    break;

            }

            double sum = 0;
            System.Windows.Forms.DataVisualization.Charting.Series[] series = new System.Windows.Forms.DataVisualization.Charting.Series[counter];
            chart1.ChartAreas["ChartArea1"].AxisX.MajorGrid.Enabled = false;
            chart1.ChartAreas["ChartArea1"].AxisY.MajorGrid.Enabled = false;

            chart1.ChartAreas["ChartArea1"].AxisY.Interval =1 ;
            for (int i = 0; i < counter; i++)
            {
                //int flag = 1;
                series[i] = new System.Windows.Forms.DataVisualization.Charting.Series();
                series[i].ChartArea = "ChartArea1";
                series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.RangeBar;
                series[i].Legend = "Legend1";
                series[i].Font = new System.Drawing.Font("Times", 10f);
                series[i].Name = drawing[i, 0].ToString();

                //if (i > 0)
                //{
                //    if (drawing[i, 1] != drawing[i - 1, 2] && i != 0)
                //    {
                //        chart1.Series.Add(series[i]);
                //        chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { sum, sum + (drawing[i, 2] - drawing[i, 1]) } });
                //        chart1.Series[series[i].Name].Label = "IDEAL";
                //        flag = 0;
                //    }
                //}
                //else if (flag == 0)
                //{
                    if (chart1.Series.IsUniqueName(series[i].Name))
                    {
                        chart1.Series.Add(series[i]);
                    //chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { sum, sum + (drawing[i, 2] - drawing[i, 1]) } });
                     chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { drawing[i,1], drawing[i, 2]  } });
                    chart1.Series[series[i].Name].Label = drawing[i, 0].ToString();
                    }
                    else
                    {
                     chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { drawing[i, 1], drawing[i, 2] } });
                    //chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { sum, sum + (drawing[i, 2] - drawing[i, 1]) } });
                }
                    sum += (drawing[i, 2] - drawing[i, 1]);
               
                //chart1.ChartAreas[0].AxisY.CustomLabels.Add(sum - ((drawing[i, 2] - drawing[i, 1]) / 2), sum + (drawing[i, 2] - drawing[i, 1]) - ((drawing[i, 2] - drawing[i, 1]) / 2), Convert.ToString(sum));

                /* if (i == counter - 1)
                  {
                      chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { drawing[i,2], drawing[i, 2] } });
                 // chart1.Series[series[i].Name].Points.Add(new DataPoint() { AxisLabel = "Process", XValue = 1, YValues = new double[] { sum, sum } });
              }*/
                //flag = 1;
                //}

            }

        }

        private void chart_Load(object sender, EventArgs e)
        {
           type = main_form.type;            
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
