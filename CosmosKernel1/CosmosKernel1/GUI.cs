using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using CMouse = Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;

public class GUI
{
    Canvas C;
    readonly int ScreenWidth = 800;
    readonly int ScreenHeight = 600;
    public GUI()
	{
        
    }
    public void Initialize() //To Initialize the Canvas and Mouse
    {
        C = FullScreenCanvas.GetFullScreenCanvas(new Mode(ScreenWidth, ScreenHeight, ColorDepth.ColorDepth32));
        CMouse.ScreenWidth = (uint)ScreenWidth;
        CMouse.ScreenHeight = (uint)ScreenHeight;
        CMouse.X = 400; //Initializing Mouse at the center of the screen
        CMouse.Y = 300;
    }
    public void RunGUI()
    {
        while (true)
        {
            C.Clear(Color.White);
            Pen pen = new Pen(Color.Black);
            // To keep the Mouse within the screen bounds
            if (CMouse.X < 0)
            {
                CMouse.X = 0;
            }
            if (CMouse.X > (ScreenWidth - 12))
            {
                CMouse.X = (uint)(ScreenWidth - 12);
            }
            if (CMouse.Y < 0)
            {
                CMouse.Y = 0;
            }
            if (CMouse.Y > (ScreenHeight - 20))
            {
                CMouse.Y = (uint)(ScreenHeight - 20);
            }

            Point cur = new Point((int)CMouse.X, (int)CMouse.Y); //Point where Mouse is currently pointing

            //To Draw the Mouse Symbol at the Point cur
            C.DrawLine(pen, cur, new Point(cur.X, cur.Y + 14));
            C.DrawLine(pen, new Point(cur.X + 1, cur.Y + 1), new Point(cur.X + 10, cur.Y + 10));
            C.DrawLine(pen, new Point(cur.X + 6, cur.Y + 10), new Point(cur.X + 10, cur.Y + 10));
            C.DrawLine(pen, new Point(cur.X + 1, cur.Y + 13), new Point(cur.X + 3, cur.Y + 11));
            C.DrawLine(pen, new Point(cur.X + 4, cur.Y + 12), new Point(cur.X + 6, cur.Y + 17));
            C.DrawPoint(pen, new Point(cur.X + 6, cur.Y + 11));
            C.DrawLine(pen, new Point(cur.X + 7, cur.Y + 12), new Point(cur.X + 9, cur.Y + 17));
            C.DrawLine(pen, new Point(cur.X + 7, cur.Y + 18), new Point(cur.X + 8, cur.Y + 18));
        }
    }
}


//Possible Display Driver

//To launch GUI
//--------------------------------------------------------------------------------------------------------
/*Console.WriteLine("Booting DisplayDriver.");
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
                     break;*/

//--------------------------------------------------------------------------------------------------------


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
