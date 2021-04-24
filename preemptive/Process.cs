using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApp1
{
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
}
