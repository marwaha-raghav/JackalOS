using System;
using Sys = Cosmos.System;

public class MyConsole
{
   public Utilities Obj=new Utilities();       //object of utilities class used to access public member functions
    public MyConsole()
	{             
        //Initialize();                        //constructor
	}
    private void Shutdown()
    {
        Sys.Power.Shutdown();                  //SHUTdOWN FUNCTION
    }
    public void RunConsole()
    {
        int Choice;
        do
        {
            Console.WriteLine("ENTER YOUR CHOICE");
            Console.WriteLine("Enter 1 to launch basic calculator");
            Console.WriteLine("Enter 2 for playing Game");
            Console.WriteLine("Enter 3 to launch the GUI");
            Console.WriteLine("Enter 0 for shutdown");
            Choice = int.Parse(Console.ReadLine());
            //menu driven run program
            switch (Choice)
            {
                case 1:
                    Obj.NumberEntry();
                    break;
                case 2:
                    Obj.Game();
                    break;
                    /* case 3:
                         Console.WriteLine("Booting DisplayDriver.");
                         try
                         {
                             var display = new DisplayDriver();
                             Console.WriteLine("ATTEMPTING");
                             display.init(); //init display
                             display.clear();
                             display.setPixel((int)40, 50, 60);   
                         }
                         catch (Exception)
                         {
                             Console.WriteLine("Booting GUI failed. Continue in DOS mode.");

                         }
                         break;*/ //To launch GUI
            }

        } while (Choice != 0);
          Shutdown();
    }

}
