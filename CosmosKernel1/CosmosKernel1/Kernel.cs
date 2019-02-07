using System;
using System.Collections.Generic;
using System.Text;
using Sys = Cosmos.System;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        protected override void BeforeRun()
        {
            Console.WriteLine("Welcome to Raghav's OS.");
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
            int Mind = 37;
            int Guess;


            Console.Write("Guess the number i have in mind");

            Guess = Int32.Parse(Console.ReadLine());



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
            
            Console.WriteLine("NO. OF GUESSES " + Count);
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
                    case 2:Game();                                             
                        break;
                }

            
                
                
            } while (Choice!=0);

            Console.WriteLine("you chose to Exit BYE");
        }
    }
}
