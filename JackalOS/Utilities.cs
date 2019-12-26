using System;
using Sys = Cosmos.System;

namespace JackalOS
{
    /// <summary>
    /// Utilities Class contains all the misc utilities functions of the OS.
    /// Most of these functions are independent & can be called individually for specific use.
    /// If you create a function that is called in other various parts of the OS, that should be added here instead.
    /// </summary>
    public class Utilities
    {
        public Utilities()
        {
        }
        /// <summary>
        /// This function will cause the OS to wait for the specified amount of time(in seconds).
        /// </summary>
        /// <param name="seconds">seconds the OS should wait</param>
        public static void WaitSeconds(int seconds)
        {
            DateTime T = DateTime.Now;
            do
            {
                //Waiting
            } while (T.AddSeconds(seconds) > DateTime.Now);
        }
        /// <summary>
        /// This function will cause the OS to wait for the specified amount of time(in milliseconds).
        /// </summary>
        /// <param name="MilliSeconds">milliseconds the OS should wait</param>
        public static void WaitMilliSeconds(int MilliSeconds)
        {
            DateTime T = DateTime.Now;
            do
            {
                //Waiting
            } while (T.AddMilliseconds(MilliSeconds) > DateTime.Now);
        }
        /// <summary>
        /// This function is only for internal developmeant & testing.
        /// This is a calculator capable of performing addition, subtraction, division & multiplication.
        /// </summary>
        /// <param name="Num1">First Number on which operation is to be performed</param>
        /// <param name="Num2">Second Number (divisor or subtrahend)</param>
        /// <param name="opt">('a')-Addition | ('b')-Subtraction | ('c')-Multiplication | ('d')-Division</param>
        public void Calculate(float Num1, float Num2, char opt)
        {
            float ans;
            if (opt == 'a')
            {
                ans = Num1 + Num2;
            }
            else if (opt == 'b')
            {                                                       
                ans = Num1 - Num2;
            }
            else if (opt == 'c')
            {
                ans = Num1 * Num2;
            }
            else
            {
                ans = Num1 / Num2;
            }
            Console.WriteLine("Answer : " + ans);

        }
        /// <summary>
        /// This function is only for internal developmeant & testing.
        /// This is a game where the OS will try to guess the number you have in mind.
        /// </summary>
        public void Game()
        {
            int Count = 0;
            int HighLow;
            // int Guess;
            int start = 0;
            int end = 100;

            Console.WriteLine("Guess any number between 1 and 100(Both inclusive)");
            Console.WriteLine("You have 3 seconds to think ....");

            WaitSeconds(3);
            while (start <= end)
            {
                int mid = (start + end) / 2;
                Count++;
                Console.WriteLine("Is your number : " + mid);
                Console.WriteLine("Enter 0 if this is the correct answer. Enter -1 if your guessed number is lower or Enter 1 if your guessed number is higher");
                HighLow = Int32.Parse(Console.ReadLine());
                if (HighLow == 0)
                {
                    Console.WriteLine("It took me " + Count + " tries to guess your number.");
                    break;
                }
                else if (HighLow == -1)
                {
                    end = mid - 1;
                }
                else if (HighLow == 1)
                {
                    start = mid + 1;
                }
                else
                {
                    Console.WriteLine("I don't understand please enter -1,0 OR 1. ONLY.");
                }
            }

        }
        /// <summary>
        /// This function is only for internal developmeant & testing.
        /// This is a driver function for the calculator function.
        /// </summary>
        public void NumberEntry()
        {
            Console.WriteLine("WHAT OPERATION WOULD YOU LIKE TO PERFORM ?");
            Console.WriteLine("a. Add");
            Console.WriteLine("b. Subtract");
            Console.WriteLine("c. Multiply");
            Console.WriteLine("d. Divide");
            char opt = char.Parse(Console.ReadLine());                     //menu for calculator

            if ((int)opt >= 97 && (int)opt <= 100)
            {
                Console.WriteLine("Enter Value 1 : ");
                int num1 = Int32.Parse(Console.ReadLine()); //conversion from string value of int to 32bit int
                Console.WriteLine("Enter Value 2 : ");
                int num2 = Int32.Parse(Console.ReadLine());
                Calculate(num1, num2, opt);
            }
            else
            {
                Console.WriteLine("Invalid Command. Please Try Again");
            }



        }
        /// <summary>
        /// This function loads the Jackal OS logo on the console screen.
        /// </summary>
        public static void JackalOSLogo()
        {
            Console.WriteLine("       %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@..*#&@@.");
            Console.WriteLine("       %@@#%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&@@@@@@@       %,");
            Console.WriteLine("       %@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&&@@@@%/,       %@@&");
            Console.WriteLine("       %@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&@@#              %@@,     /(");
            Console.WriteLine("       %@@%%%%%%%%%%%%%%%%%%%%%%&@@@@@@@@@%%%%%%@@*          @@#     /&");
            Console.WriteLine("       %@@%%%%%%%%%%%%%%%%%@&*             ,#@@%%%%@&        @@     .&");
            Console.WriteLine("       %@@%%%%%%%%%%%%%&@,                      #@%%%&@.    &@      @");
            WaitMilliSeconds(10);
            Console.WriteLine("       %@@%%%%%%%%%%%%@,                          .@&%%@#  .@     .@");
            Console.WriteLine("       %@@%%%%%%%%%%@*                              ,@%#&@ @      @.");
            Console.WriteLine("       %@@%%%%%%%%&&          ,&@&%%%%%%@@%           &%%%@.     &@.");
            Console.WriteLine("       %@@%%%%%%%@,         @&%%%%#,..*(%%%%@%         %%%&@    %@@.");
            Console.WriteLine("       %@@%%%%%&@         #@%%%* (@@@@@@/ ,%%%@*        @%%&/  %@@@.");
            Console.WriteLine("       %@@%%%%&/         @@%%# #@@@@@@@@@@& #%%@.       (@%%@ /&%@@.");
            WaitMilliSeconds(10);
            Console.WriteLine("       %@@%%%&/         @@%%# &@@@@@@@@@@@@% %%%%       .@%%@/@%%@@.");
            Console.WriteLine("       %@@%%@(         @.@%%, @@@@@@@@@@@@@@.(%%@        @%%@@%%&@@.");
            Console.WriteLine("       %@@%@.         @( @%%/ @@@@@@@@@@@@@@ #%%&        @%%&%%%&@@.");
            Console.WriteLine("       %@@@*         &@  %&%%,.@@@@@@@@@@@@ .%%&,       *@%%%%%%&@@.");
            Console.WriteLine("       %@@.         %@,   &%%%/ /@@@@@@@@# #%%%#        @&%%%%%%&@@.");
            Console.WriteLine("       %@/         .@@     #&%%%%.      ,#%%%@(        ,&%%%%%%%&@@.");
            Console.WriteLine("       %%          @@@       (@%%%%%%%%%%%%@%         .@%%%%%%%%&@@.");
            Console.WriteLine("      /#          ,@@%           *#&@@@%*.           &&%%%%%%%%%&@@.");
            Console.WriteLine("     .@           @@@#                             #@#%%%%%%%%%%&@@.");
            WaitMilliSeconds(10);
            Console.WriteLine("     @           /@@@#                           #@%%%%%%%%%%%%%&@@.");
            Console.WriteLine("    @,           @@@@#                        /@%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine("   %.           .@@@@%                   .%@%%%%%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine("  ##            %@@@@@              ,&@&%%%%%%%%%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine(" .%             @@@@@@      ,(&@@%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine(" @             *@@@@@@@@&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine("/%#%&&@@@@@&&%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%%&@@.");
            Console.WriteLine("       %@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@@.");

            Console.WriteLine(@"      _            _         _    ____   _____ ");
            Console.WriteLine(@"     | |          | |       | |  / __ \ / ____|");
            Console.WriteLine(@"     | | __ _  ___| | ____ _| | | |  | | (___  ");
            Console.WriteLine(@" _   | |/ _` |/ __| |/ / _` | | | |  | |\___ \ ");
            Console.WriteLine(@"| |__| | (_| | (__|   < (_| | | | |__| |____) |");
            Console.WriteLine(@" \____/ \__,_|\___|_|\_\__,_|_|  \____/|_____/ ");


        }

        /*public void PlayMusic()
        {
             System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                           player.SoundLocation = "path of music";             //file storage system reqd
        }
        */
        /// <summary>
        /// (UNDER DEVELOPMENT) This function is currently in active development & should not be used.
        /// File System driver.
        /// </summary>
        public void FileSystem()
        {

            //READ FROM A FILE

            /*
             public string[] ReadLines(string FileAdr) //Returns the lines of text in string[].
{
     string[] FileRead;
     FileRead = File.ReadAllLines(FileAdr);
     return FileRead;
}

public string ReadText(string FileAddr) //Returns the file in a single string.
{
    string f_contents = "";
    f_contents = File.ReadAllText(FileAddr);
    return f_contents;
}

public byte[] ReadByte(string FileAdr) //Returns the read file in bytes.
{
     byte[] FileRead;
     FileRead = File.ReadAllBytes(FileAdr);
     return FileRead;
} */




            /*

            ACCESSING FROM A FILE

            public string[] GetFsFadr(string Adr) // Get Files From Address
    {
        string[] Files = new string[256];
        if (Directory.GetFiles(Adr).Length > 0)
            Files = Directory.GetFiles(Adr);
        else
            Files[0] = "No files found.";
        return Files;
     }
    public string[] GetDirFadr(string Adr) // Get Directories From Address
    {
        var Dirs = Directory.GetDirectories(Adr);
        return Dirs;
    }

     */
        }

    }
}
