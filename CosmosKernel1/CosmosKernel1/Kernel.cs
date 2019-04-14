using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Sys = Cosmos.System;


namespace CosmosKernel1
{
    
    public class Kernel : Sys.Kernel
    {
        public MyConsole Con =new MyConsole();
        public Desktop NewGUI = new Desktop();
//        public Utilities util = new Utilities();

        //obj for console class
        bool AccessConsole = false; //To check whether Console Access is required
        protected override void BeforeRun()
        {
            Utilities.JackalOSLogo();
            Console.WriteLine("Welcome to the Updated JackalOS. v3.0.1");
            Console.Beep();
            Console.WriteLine("OS is loading....");
            Console.WriteLine("To load in Console Mode press c, Press any other key to continue to GUI");
            char Choice = Char.Parse(Console.ReadLine());
            if (Choice == 'c')
            {
                AccessConsole = true;
            }
        }
     
        
        
        protected override void  Run()
        {
            if (AccessConsole == false)
            {
                NewGUI.Run();
            }
            else
            {
                Con.RunConsole();
            }
        }
    }

    }
