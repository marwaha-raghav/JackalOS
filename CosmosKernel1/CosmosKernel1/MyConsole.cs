using System;
using Sys = Cosmos.System;

public class MyConsole
{
    public Utilities Obj=new Utilities(); //object of utilities class used to access public member functions
    public GUI NewGUI = new GUI();

    public MyConsole()
	{             
        //Initialize();                        //constructor
	}
    private void Shutdown()
    {
        Sys.Power.Shutdown();                  //SHUTDOWN FUNCTION
    }
    public void RunConsole()
    {
        string Choice;
        do
        {
            Console.WriteLine("ENTER COMMANDS");
            Console.WriteLine("Current Build Supports Calculator, Game, GUI");           
            //Choice = int.Parse(Console.ReadLine());
            Choice = Console.ReadLine();
            //menu driven run program
            switch (Choice)
            {
                case "/calc":
                    Obj.NumberEntry();
                    break;
                case "/game":
                    Obj.Game();
                    break;
                case "/gui":
                    NewGUI.Initialize();
                    NewGUI.RunGUI();
                    break;
                    /*case "/music": 
                     PlayMusic();         //needs further code
                       break;

                     */
            }

        } while (Choice != "/exit");
          Shutdown();
    }

}
