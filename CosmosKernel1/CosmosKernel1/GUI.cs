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
    readonly Pen MousePen = new Pen(Color.Black);
    readonly Pen GUIHomePen = new Pen(Color.White);
    Point PrevousMouse;
    public GUI()
	{
        
    }
    public void Initialize() //To Initialize the Canvas and Mouse
    {
        Console.WriteLine("GUI is booting up.");
        C = FullScreenCanvas.GetFullScreenCanvas(new Mode(ScreenWidth, ScreenHeight, ColorDepth.ColorDepth32));
        C.Clear(Color.White);
        CMouse.ScreenWidth = (uint)ScreenWidth;
        CMouse.ScreenHeight = (uint)ScreenHeight;
        CMouse.X = (uint)(ScreenWidth / 2); //Initializing Mouse at the center of the screen
        CMouse.Y = (uint)(ScreenHeight / 2);
        PrevousMouse.X = (ScreenWidth / 2);
        PrevousMouse.Y = (ScreenHeight / 2);
        Console.WriteLine("GUI booted up successfully.");
    }
    public void DrawMouse(Pen pen, Point cur)
    {
        //Mouse Traingle Points are Below
        C.DrawPoint(pen, cur.X, cur.Y);
        C.DrawPoint(pen, new Point(cur.X + 1, cur.Y));
        C.DrawPoint(pen, new Point(cur.X + 2, cur.Y));
        C.DrawPoint(pen, new Point(cur.X + 3, cur.Y));
        C.DrawPoint(pen, new Point(cur.X + 4, cur.Y));
        C.DrawPoint(pen, new Point(cur.X + 5, cur.Y));

        C.DrawPoint(pen, new Point(cur.X, cur.Y + 1));
        C.DrawPoint(pen, new Point(cur.X + 1, cur.Y + 1));
        C.DrawPoint(pen, new Point(cur.X + 2, cur.Y + 1));
        C.DrawPoint(pen, new Point(cur.X + 3, cur.Y + 1));
        C.DrawPoint(pen, new Point(cur.X + 4, cur.Y + 1));

        C.DrawPoint(pen, new Point(cur.X, cur.Y + 2));
        C.DrawPoint(pen, new Point(cur.X + 1, cur.Y + 2));
        C.DrawPoint(pen, new Point(cur.X + 2, cur.Y + 2));
        C.DrawPoint(pen, new Point(cur.X + 3, cur.Y + 2));

        C.DrawPoint(pen, new Point(cur.X, cur.Y + 3));
        C.DrawPoint(pen, new Point(cur.X + 1, cur.Y + 3));
        C.DrawPoint(pen, new Point(cur.X + 2, cur.Y + 3));

        C.DrawPoint(pen, new Point(cur.X, cur.Y + 4));
        C.DrawPoint(pen, new Point(cur.X + 1, cur.Y + 4));

        C.DrawPoint(pen, new Point(cur.X, cur.Y + 5));
        // Mouse Triangle Over
        
        //Mouse Tail points are below
        C.DrawPoint(pen, new Point(cur.X + 3, cur.Y + 3));
        C.DrawPoint(pen, new Point(cur.X + 4, cur.Y + 4));
        C.DrawPoint(pen, new Point(cur.X + 5, cur.Y + 5));
        C.DrawPoint(pen, new Point(cur.X + 6, cur.Y + 6));
        C.DrawPoint(pen, new Point(cur.X + 7, cur.Y + 7));
    }
    public void RunGUI()
    {
        while (true)
        {
            // To keep the Mouse within the screen bounds
            if (CMouse.X < 0)
            {
                CMouse.X = 0;
            }
            if (CMouse.X > (ScreenWidth - 8))
            {
                CMouse.X = (uint)(ScreenWidth - 8);
            }
            if (CMouse.Y < 0)
            {
                CMouse.Y = 0;
            }
            if (CMouse.Y > (ScreenHeight - 8))
            {
                CMouse.Y = (uint)(ScreenHeight - 8);
            }
            Point cur = new Point((int)CMouse.X, (int)CMouse.Y); //Point where Mouse is currently pointing
            
            //Refreshing the screen 
            int UpdateWidth = 20;
            int UpdateHeight = 20;

            if( (PrevousMouse.X != cur.X) || (PrevousMouse.Y != cur.Y))
            {
                int x = Math.Min(Math.Max(PrevousMouse.X - (UpdateWidth / 2), 0), (ScreenWidth - UpdateWidth));
                int y = Math.Min(Math.Max(PrevousMouse.Y - (UpdateHeight / 2), 0), (ScreenHeight - UpdateHeight));
                Point ClearRectangle = new Point(x, y);
                C.DrawFilledRectangle(GUIHomePen, ClearRectangle, UpdateWidth, UpdateHeight);
                PrevousMouse = cur;
            }

            //Draw the Mouse
            DrawMouse(MousePen, cur);
        }
    }
}

