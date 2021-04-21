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
            Console.WriteLine("Enter number of Process: ");
            int num_procees = Convert.ToInt32(Console.ReadLine());
            
            Process[] mat_process = new Process[num_procees] ;
           
            for (int i = 0; i < mat_process.Length; i++)
            {
                mat_process[i] = new Process(0,0,0);

            }

            
            
            for (int i = 0; i < num_procees; i++)
            {

                Console.WriteLine("...Process ", i + 1, "...\n");
                Console.WriteLine("Enter Process Id: ");
                mat_process[i].set_Process_ID(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Enter Arrival Time: ");
                mat_process[i].set_Arrival_Time(Convert.ToInt32(Console.ReadLine()));
                Console.WriteLine("Enter Burst Time: ");
                mat_process[i].set_Burst_Time(Convert.ToInt32(Console.ReadLine()));

            }
            Console.ReadLine();
        }
    }
}

