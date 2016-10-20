using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PermutateSudokuV4
{
    class Program
    {

        static void Main(string[] args)
        {
            new PermutateOneThroughNine();
            //PermutateSolutions();
        }

        private static void PermutateSolutions()
        {
            AddEvents();
            CheckCPUSpeed();
            Console.ReadLine();
        }

        private static void CheckCPUSpeed()
        {
            Console.WriteLine("Checking CPU status before continuing...");
            PerformanceCounter PC = new PerformanceCounter("Processor", "% Processor Time", "_Total", true);
            float proc = PC.NextValue();
            Thread.Sleep(2000);
            proc = PC.NextValue();
            if (proc > 70) {
                MessageBox.Show("Your CPU is currently running at " + proc + "%. Opening another session may cause undesired results from your computer. \n The application session will now close.");
                On_Close(CtrlType.CTRL_BREAK_EVENT);
                Environment.Exit(0);
            }
            Console.WriteLine("Your CPU is good, current usage is " + proc + "%.");
        }


        [DllImport("Kernel32")]
        private static extern bool SetConsoleCtrlHandler(EventHandler handler, bool add);

        public delegate bool EventHandler(CtrlType sig);
        static EventHandler _handler;

        public enum CtrlType
        {
            CTRL_C_EVENT = 0,
            CTRL_BREAK_EVENT = 1,
            CTRL_CLOSE_EVENT = 2,
            CTRL_LOGOFF_EVENT = 5,
            CTRL_SHUTDOWN_EVENT = 6
        }

        public static void AddEvents()
        {
            _handler += new EventHandler(On_Close);
            SetConsoleCtrlHandler(_handler, true);
        }

        public static bool On_Close(CtrlType sig)
        {
            switch (sig) {
                case CtrlType.CTRL_C_EVENT:
                case CtrlType.CTRL_BREAK_EVENT:
                case CtrlType.CTRL_CLOSE_EVENT:
                case CtrlType.CTRL_LOGOFF_EVENT:
                case CtrlType.CTRL_SHUTDOWN_EVENT:
                default:
                    MessageBox.Show("you are in the default close event with signature = " + sig.ToString());
                    break;
            }
            return true;
        }
    }
}
