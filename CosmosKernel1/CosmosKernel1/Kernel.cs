using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Welcome to Raghav's Updated OS. v2.0");
            Console.Beep();
        }
        public void Sum(float Num1 ,float Num2)
        {
            float Sum = 0;
            Sum = Num1 + Num2;                                  //func to calcuate sum
            Console.WriteLine("Sum:" + Sum);

        }
        public void Game()
        {
            int Count = 0;
            int HighLow;
            // int Guess;
            int start = 0;
            int end = 100;

            Console.WriteLine("Guess any number between 1 and 100(Both inclusive)");
            Console.WriteLine("You have 3 seconds to think ....");

            DateTime T = DateTime.Now;

            do
            {
                //Waiting
            } while (T.AddSeconds(3) > DateTime.Now);


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

            //Guess = Int32.Parse(Console.ReadLine());


            /*
            if (Mind == Guess)
                {
                    Console.WriteLine("Success u found the number on my mind");
                    Count++;
                
                
                }
            while ( Mind!=Guess)
            {
                
                if (Guess > Mind)
                 {
                    Console.WriteLine("too high guess a lower value");
                    Count++;
                 }
                else if(Guess<Mind)
                {
                    Console.WriteLine("too low guess a higher value");
                    Count++;
                }
                else
                {
                    
                    
                        Console.WriteLine("Success u found the number on my mind");
                        Count++;


                    
                }
                Console.WriteLine("TRY AGAIN");
                Guess = Int32.Parse(Console.ReadLine());
            }
            
            Console.WriteLine("NO. OF GUESSES " + Count);*/
        }
        private void NumberEntry()
        {
            Console.WriteLine("Enter Value 1 :");
            int num1 = Int32.Parse(Console.ReadLine()); //conversion from string value of int to 32bit int
            Console.WriteLine("EnterValue2 : ");
            int num2 = Int32.Parse(Console.ReadLine());
            Sum(num1, num2);                             //function call for sum function
        }
        protected override void Run()
        {

            int Choice;

            do
            {
                Console.WriteLine("ENTER UR CHOICE");
                Console.WriteLine("ENTER 1 FOR SUMMING OPERATION");
                Console.WriteLine("Enter 2 for playing Game");
                Console.WriteLine("Enter 0 for EXIT");
                Choice = int.Parse(Console.ReadLine());
                //menu driven run program
                switch (Choice)
                {
                    case 1:
                        NumberEntry();
                        break;
                    case 2: Game();
                        break;
                }




            } while (Choice != 0);
            Console.Clear();
            Console.WriteLine("you chose to Exit BYE! It is now safe to Power Off the system");
            Sys.Power.Shutdown();
        }
    }
}
