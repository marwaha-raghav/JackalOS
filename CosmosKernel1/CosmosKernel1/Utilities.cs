using System;
using Sys = Cosmos.System;
public class Utilities
{
    public Utilities()
    {
    }

    public void Calculate(float Num1, float Num2, char opt)
    {
        float ans;
        if (opt == 'a')
        {
            ans = Num1 + Num2;
        }
        else if (opt == 'b')
        {                                                            //Calculator to be changed
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

    }
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
    /*public void PlayMusic()
    {
         System.Media.SoundPlayer player = new System.Media.SoundPlayer();
                       player.SoundLocation = "path of music";             //file storage system reqd
    }
    */


}
