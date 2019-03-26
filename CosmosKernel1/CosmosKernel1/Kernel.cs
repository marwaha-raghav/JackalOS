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
        public MyConsole Con =new MyConsole();
        //obj for console class
        //bool GUImode = false; //To be set to true once GUI is ready
        protected override void BeforeRun()
        {  
            Console.WriteLine("Welcome to the Updated JackalOS. v3.0.1");
            Console.Beep();
           
        }
     
        
        
        protected override void Run()
        {
           
            Con.RunConsole();
           
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
