using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using CMouse = Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;
using CosmosKernel1.Drivers;
using CosmosKernel1.Applications;

namespace CosmosKernel1
{
    public class Desktop
    {
        Canvas C;
        readonly int ScreenWidth = 800;
        readonly int ScreenHeight = 600;
        readonly Pen MousePen = new Pen(Color.Black);
        readonly Pen GUIHomePen = new Pen(Color.Gold);
        Point PrevMouse = new Point();
        public TextRenderer Text = new TextRenderer();

        //Icon sizes & Positions
        Point WelcomeStart = new Point(10, 10);
        Point DrawStart = new Point(10, 50);
        Point DrawEnd = new Point();
        Point TextBoxStart = new Point(10, 90);
        Point TextBoxEnd = new Point();
        Point ShutdownStart = new Point(10, 130);
        Point ShutdownEnd = new Point();
        int YSize = 20;

        public Desktop()
        {

        }
        private void Initialize() //To Initialize the Canvas and Mouse
        {
            Console.WriteLine("GUI is booting up.");
            C = FullScreenCanvas.GetFullScreenCanvas(new Mode(ScreenWidth, ScreenHeight, ColorDepth.ColorDepth32));
            C.Clear(Color.Gold);
            Render();
            CMouse.ScreenWidth = (uint)ScreenWidth;
            CMouse.ScreenHeight = (uint)ScreenHeight;
            CMouse.X = (uint)(ScreenWidth / 2); //Initializing Mouse at the center of the screen
            CMouse.Y = (uint)(ScreenHeight / 2);
            PrevMouse.X = (int)CMouse.X;
            PrevMouse.Y = (int)CMouse.Y;
            Console.WriteLine("GUI booted up successfully."); //Only for debugging technically you shouldn't see this output.
            
        }

        private void Render()
        {
            Text.StringTextHandler(C, "welcome to jackal os v0.0", WelcomeStart);
            DrawEnd = Text.StringTextHandler(C, "1. draw", DrawStart);
            TextBoxEnd = Text.StringTextHandler(C, "2. notepad", TextBoxStart);
            ShutdownEnd = Text.StringTextHandler(C, "3. shutdown", ShutdownStart);
        }

        private void CheckAndRenderIcons(Point Removed)
        {
            //Icon sizes & Positions
            /* Point ShutdownStart = new Point(750, 20);
             int ShutdownSize = 30;
             Point DrawStart = new Point(750, 60);
             int DrawSize = 30;
             Point TextBoxStart = new Point(750, 100);
             int TextBoxSize = 30;*/

            //Check
            if ((Removed.X > ShutdownStart.X - 8) && (Removed.X < ShutdownStart.X + ShutdownEnd.X + 8))
            {
                if ((Removed.Y > ShutdownStart.Y - 8) && (Removed.Y < ShutdownStart.Y + YSize + 8))
                {
                    Render();
                }
            }
            if ((Removed.X > DrawStart.X - 8) && (Removed.X < DrawStart.X + DrawEnd.X + 8))
            {
                if ((Removed.Y > DrawStart.Y - 8) && (Removed.Y < DrawStart.Y + YSize + 8))
                {
                    Render();
                }
            }
            if ((Removed.X > TextBoxStart.X - 8) && (Removed.X < TextBoxStart.X + TextBoxEnd.X + 8))
            {
                if ((Removed.Y > TextBoxStart.Y - 8) && (Removed.Y < TextBoxStart.Y + YSize + 8))
                {
                    Render();
                }
            }
        }

        private void RemoveMouse(Point Remove)
        {
            C.DrawFilledRectangle(GUIHomePen, Remove, 8, 8);
            CheckAndRenderIcons(Remove);
        }

        private void MouseClicked(Point CurMouse)
        {
            //Icon sizes & Positions
            /*Point ShutdownStart = new Point(750, 20);
            int ShutdownSize = 30;
            Point DrawStart = new Point(750, 60);
            int DrawSize = 30;*/

            if ((CurMouse.X > ShutdownStart.X) && (CurMouse.X < ShutdownStart.X + ShutdownEnd.X))
            {
                if ((CurMouse.Y > ShutdownStart.Y) && (CurMouse.Y < ShutdownStart.Y + YSize))
                {
                    Sys.Power.Shutdown();
                }
            }
            if ((CurMouse.X > DrawStart.X) && (CurMouse.X < DrawStart.X + DrawEnd.X))
            {
                if ((CurMouse.Y > DrawStart.Y) && (CurMouse.Y < DrawStart.Y + YSize))
                {

                    DrawApp Draw = new DrawApp();
                    Draw.Draw(C);
                    Initialize();
                }
            }
            if ((CurMouse.X > TextBoxStart.X) && (CurMouse.X < TextBoxStart.X + TextBoxEnd.X))
            {
                if ((CurMouse.Y > TextBoxStart.Y) && (CurMouse.Y < TextBoxStart.Y + YSize))
                {
                    Notepad Note = new Notepad();
                    Note.Launch(C);
                    Initialize();
                }
            }
        }

        public void Run()
        {

            Initialize();
            while (true)
            {
                Point CurMouse = Mouse.MouseLimit((int)CMouse.X, (int)CMouse.Y);
                Mouse.DrawMouse(C, MousePen, CurMouse);

                //To Remove the Mouse
                if ((PrevMouse.X != CurMouse.X) || (PrevMouse.Y != CurMouse.Y))
                {
                    RemoveMouse(PrevMouse);
                    PrevMouse = CurMouse;
                }

                if (Mouse.Click())
                {
                    MouseClicked(CurMouse);
                }
                


            }
        }
    }

}
