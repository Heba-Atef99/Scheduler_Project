using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
    public class Process
    {

        private int Process_ID; // Process ID
        private int Arrival_Time; // Arrival Time
        private int Burst_Time; // Burst Time
        private int Waiting_Time;
        private int Priority;



        public Process(int Process_ID, int Arrival_Time, int Burst_Time, int Priority, int Waiting_Time)
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
        public int get_Waiting_Time()
        {
            return this.Waiting_Time;
        }

    }
}
