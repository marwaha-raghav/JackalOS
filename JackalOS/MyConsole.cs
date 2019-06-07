using System;
using Sys = Cosmos.System;

namespace CosmosKernel1
{

    public class MyConsole
    {
        public Utilities Obj = new Utilities(); //object of utilities class used to access public member functions
        public Desktop NewGUI = new Desktop();

        public MyConsole()
        {
            //Initialize();                        //constructor
        }
        /// <summary>
        /// This function is only for internal developmeant & testing.
        /// Shutdown the OS.
        /// </summary>
        private void Shutdown()
        {
            Sys.Power.Shutdown();                  //SHUTDOWN FUNCTION
        }
        /// <summary>
        /// This function is only for internal developmeant & testing.
        /// This will load the console application.
        /// If the GUI has been already launched this will do nothing.
        /// </summary>
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
                        NewGUI.Run();
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
}