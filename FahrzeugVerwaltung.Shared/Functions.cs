using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace FahrzeugVerwaltung.Shared
{
    public class Functions
    {

        public Functions()
        {

        }

        public string StringInput()
        {
            string input = "";
            bool failed = false;
        

                try
                {
                    input = Console.ReadLine();
                }
                catch (System.FormatException e)
                {
                    failed = true;
                    Console.WriteLine(e.Message);
                    FailMessage("Bitte Geben Sie einen String ein");
                    Console.WriteLine("Bitte Geben Sie einen String ein");
                StringInput();
              
                }
            if (failed)
            {
                FunnyMessage("Is That So Hard??");
                SuccessMessage("Vielen Dank für diese wunderbare string..");
            }
            return input;
        }

        public int IntInput()
        {
            int input = 0;
            bool failed = false;

            try
                {
                    input = int.Parse(Console.ReadLine());
                }
                catch (System.FormatException e)
                {
                    failed = true;
                    Console.WriteLine(e.Message);
                    FailMessage("Bitte Geben Sie einen String ein");
                    Console.WriteLine("Bitte Geben Sie einen Integer ein");
                    IntInput();
                }
            if (failed)
            {
                FunnyMessage("Is That So Hard??");
                SuccessMessage("Vielen Dank für diese wunderbare Integer..");
            }
                return input;
        }

        public void SuccessMessage(string Message )
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Message);
            Console.ResetColor();

        }

        public void FailMessage(string Message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(Message);
            Console.ResetColor();

        }

        public void FunnyMessage(string Message)
        {
            Console.BackgroundColor = ConsoleColor.DarkBlue;
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("????????????????????");
            Console.WriteLine(Message);
            Console.WriteLine("????????????????????");
            Console.ResetColor();

        }


        public void ThreadMethode(Func<Vehicle> func)
        {
            var task1 = Task.Run(() => Animation());
            var task2 = Task.Run(() => func);

            Task.WaitAll(new[] { task1, task2 });
        }


        public void Animation()
        {
            for(int i=0; i < 5; i++)
            {
                Console.Write(".");
                Thread.Sleep(1000);
            }

            Console.WriteLine(" ");

        }

     

    }
}
