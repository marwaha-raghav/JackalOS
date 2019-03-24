using System;
using System.Collections.Generic;
using System.Text;
using System.Timers;
using Sys = Cosmos.System;
using Cosmos.HAL;

namespace CosmosKernel1
{
    public class Kernel : Sys.Kernel
    {
        //bool GUImode = false; //To be set to true once GUI is ready
        protected override void BeforeRun()
        {  
            Console.WriteLine("Welcome to Raghav's Updated OS. v3.0");
            Console.Beep();
        }
        public void Calculate(float Num1 ,float Num2, char opt)
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
        private void NumberEntry()
        {
            Console.WriteLine("WHAT OPERATION WOULD YOU LIKE TO PERFORM ?");
            Console.WriteLine("a. Add");
            Console.WriteLine("b. Subtract");
            Console.WriteLine("c. Multiply");
            Console.WriteLine("d. Divide");
            char opt = char.Parse(Console.ReadLine());
            
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
        private void Shutdown()
        {
            Sys.Power.Shutdown();
        }
        protected override void Run()
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
                        NumberEntry();
                        break;
                    case 2:
                        Game();
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
    
    //Possible Display Driver

    /*
    public class DisplayDriver
    {
    *
        protected VGAScreen screen;
        private int width, height;

        public DisplayDriver()
        {
            screen = new VGAScreen();
        }

        public void init()
        {
            screen.SetGraphicsMode(VGAScreen.ScreenSize.Size320x200, VGAScreen.ColorDepth.BitDepth8);
            width = screen.PixelWidth;
            height = screen.PixelHeight;
            clear(0);
        }

        public virtual void setPixel(int x, int y, int c)
        {
            if (screen.GetPixel320x200x8((uint)x, (uint)y) != (uint)c)
                setPixelRaw(x, y, c);
        }

        public virtual byte getPixel(int x, int y)
        {
            return (byte)screen.GetPixel320x200x8((uint)x, (uint)y);
        }

        public virtual void clear()
        {
            clear(0);
        }
        public void DrawFilledRectangle(uint x0, uint y0, int Width, int Height, int color)
        {
            for (uint i = 0; i < Width; i++)
            {
                for (uint h = 0; h < Height; h++)
                {
                    setPixel((int)(x0 + i), (int)(y0 + h), color);
                }
            }
        }
        public virtual void clear(int c)
        {
            //screen.Clear(c);
            DrawFilledRectangle(0, 0, width, height, c);
        }

        public virtual void step() { }

        public int getWidth()
        {
            return width;
        }

        public int getHeight()
        {
            return height;
        }

        public void setPixelRaw(int x, int y, int c)
        {

            screen.SetPixel320x200x8((uint)x, (uint)y, (uint)c);

        }

    }
    */
}
