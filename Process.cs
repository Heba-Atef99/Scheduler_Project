using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Process
    {

        private int Process_ID; // Process ID
        private int Burst_Time; // Burst Time
        private int Arrival_Time; // Arrival Time




        public Process(int Process_ID, int Burst_Time, int Arrival_Time)
        {
            this.Process_ID = Process_ID;
            this.Burst_Time = Burst_Time;
            this.Arrival_Time = Arrival_Time;
        }
        public void set_Process_ID(int Process_ID)
        {
            this.Process_ID = Process_ID;
        }
        public int get_Process_ID()
        {
            return this.Process_ID;
        }
        public void set_Burst_Time(int Burst_Time)
        {
            this.Burst_Time = Burst_Time;
        }
        public int get_Burst_Time()
        {
            return this.Burst_Time;
        }
        public void set_Arrival_Time(int Arrival_Time)
        {
            this.Arrival_Time = Arrival_Time;
        }
        public int get_Arrival_Time()
        {
            return this.Arrival_Time;
        }

    }
}
