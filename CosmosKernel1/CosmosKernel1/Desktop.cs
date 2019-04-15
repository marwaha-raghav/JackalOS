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
        DrawApp draw = new DrawApp();
        public TextRenderer Text = new TextRenderer();
        public ConsoleKeyInfo key;
        public char CurrentChar;
        public Point TextPoint = new Point();
        public Point CurrentPoint;
        public Point PreviousPoint;
        bool TextIconClickTest = true;

        //Icon sizes & Positions
        Point ShutdownStart = new Point(750, 20);
        int ShutdownSize = 30;
        Point DrawStart = new Point(750, 60);
        int DrawSize = 30;
        Point TextBoxStart = new Point(750, 100);
        int TextBoxSize = 30;


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
            Console.WriteLine("GUI booted up successfully.");

        }

        private void Render()
        {
            //Icon sizes & Positions
            /*Point ShutdownStart = new Point(750, 20);
            int ShutdownSize = 30;
            Point DrawStart = new Point(750, 60);
            int DrawSize = 30;
            Point TextBoxStart = new Point(750, 100);
            int TextBoxSize = 30;*/
            //Shutdown Icon
            C.DrawFilledRectangle(new Pen(Color.Red), ShutdownStart, ShutdownSize, ShutdownSize);
            C.DrawCircle(new Pen(Color.Black), ShutdownStart.X + (ShutdownSize / 2), ShutdownStart.Y + (ShutdownSize / 2), ShutdownSize / 2);
            C.DrawCircle(new Pen(Color.Black), ShutdownStart.X + (ShutdownSize / 2), ShutdownStart.Y + (ShutdownSize / 2), (ShutdownSize / 2) - 1);
            C.DrawCircle(new Pen(Color.Black), ShutdownStart.X + (ShutdownSize / 2), ShutdownStart.Y + (ShutdownSize / 2), (ShutdownSize / 2) - 2);
            C.DrawFilledRectangle(new Pen(Color.Black), ShutdownStart.X + 5, ShutdownStart.Y + (ShutdownSize / 2) - 1, 20, 3);

            //Draw App Icon
            C.DrawFilledRectangle(new Pen(Color.Violet), DrawStart, DrawSize, DrawSize);
            int[] Px = new int[546]
            {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,
                0,0,0,1,1,1,1,1,0,0,0,0,0,0,1,1,1,1,1,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,1,1,1,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,1,1,1,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,1,1,0,0,0,
                0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,
                0,0,0,1,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,
                1,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,


            };
            int ii, jj;
            for (ii = 0; ii < 26; ii++)
            {
                for (jj = 0; jj < (Px.Length) / 26; jj++)
                {
                    if (Px[((Px.Length) / 26) * ii + jj] == 1)
                    {
                        C.DrawPoint(new Pen(Color.Black), DrawStart.X + 4 + jj, DrawStart.Y + 2 + ii);
                    }
                }
            }

            //TextBox Icon
            C.DrawFilledRectangle(new Pen(Color.DarkGreen), TextBoxStart, TextBoxSize, TextBoxSize);
            int[] Tx = new int[546]
            {
                1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,
                1,1,1,1,1,1,0,0,0,0,0,0,0,0,0,1,1,1,1,1,1,
                1,1,1,1,0,0,0,0,0,1,1,1,0,0,0,0,0,1,1,1,1,
                1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,1,1,1,
                1,1,1,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,1,1,1,
                1,1,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,
                1,1,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,
                1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,
                1,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,1,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,0,0,0,0,1,1,1,0,0,0,0,0,0,0,0,0,
                0,0,0,0,0,1,1,1,1,1,1,1,1,1,1,1,0,0,0,0,0,




            };

            for (ii = 0; ii < 26; ii++)
            {
                for (jj = 0; jj < (Tx.Length) / 26; jj++)
                {
                    if (Tx[((Tx.Length) / 26) * ii + jj] == 1)
                    {
                        C.DrawPoint(new Pen(Color.Black), TextBoxStart.X + 4 + jj, TextBoxStart.Y + 2 + ii);
                    }
                }
            }
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
            if ((Removed.X > ShutdownStart.X - 8) && (Removed.X < ShutdownStart.X + ShutdownSize + 8))
            {
                if ((Removed.Y > ShutdownStart.Y - 8) && (Removed.Y < ShutdownStart.Y + ShutdownSize + 8))
                {
                    Render();
                }
            }
            if ((Removed.X > DrawStart.X - 8) && (Removed.X < DrawStart.X + DrawSize + 8))
            {
                if ((Removed.Y > DrawStart.Y - 8) && (Removed.Y < DrawStart.Y + DrawSize + 8))
                {
                    Render();
                }
            }
            if ((Removed.X > TextBoxStart.X - 8) && (Removed.X < TextBoxStart.X + TextBoxSize + 8))
            {
                if ((Removed.Y > TextBoxStart.Y - 8) && (Removed.Y < TextBoxStart.Y + TextBoxSize + 8))
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

            if ((CurMouse.X > ShutdownStart.X) && (CurMouse.X < ShutdownStart.X + ShutdownSize))
            {
                if ((CurMouse.Y > ShutdownStart.Y) && (CurMouse.Y < ShutdownStart.Y + ShutdownSize))
                {
                    Sys.Power.Shutdown();
                }
            }
            if ((CurMouse.X > DrawStart.X) && (CurMouse.X < DrawStart.X + DrawSize))
            {
                if ((CurMouse.Y > DrawStart.Y) && (CurMouse.Y < DrawStart.Y + DrawSize))
                {
                    draw.Draw(C);
                    Initialize();
                }
            }
            if ((CurMouse.X > TextBoxStart.X) && (CurMouse.X < TextBoxStart.X + TextBoxSize))
            {
                if ((CurMouse.Y > TextBoxStart.Y) && (CurMouse.Y < TextBoxStart.Y + TextBoxSize))
                {

                    Console.WriteLine("Enter your text below. Press y to continue.");
                    Console.WriteLine("Press 1 to end the text");

                    TextPoint.X = 16;
                    TextPoint.Y = 16;

                    //To print the heading
                    Text.StringTextHandler(C, "enter your text below. press any key to continue. press ~ to end the text. press ` for backspace. ", TextPoint);
                    key = Console.ReadKey();
                    CurrentChar = key.KeyChar;
                    //To start text from the last written character position
                    if (TextIconClickTest == true)
                    {
                        CurrentPoint.X = 16;
                        CurrentPoint.Y = 66;
                        TextIconClickTest = false;
                    }
                    
                    //To print individual characters
                    while (CurrentChar != '~')
                    {


                        if (CurrentChar == '`')
                        {

                            C.DrawFilledRectangle(new Pen(Color.Gold), CurrentPoint.X - 8, CurrentPoint.Y, 15, 22);
                            CurrentPoint.X = CurrentPoint.X - 8;
                            if (CurrentPoint.X < 16) // To go in previous line while backspacing.
                            {


                                if (CurrentPoint.Y - 23 >= 66)
                                {
                                    CurrentPoint.X = 734;
                                    CurrentPoint.Y = CurrentPoint.Y - 23;
                                }
                                else
                                {
                                    CurrentPoint.X = 16;
                                    CurrentPoint.Y = 66;
                                }
                            }

                            goto here;
                        }
                        
                        CurrentPoint = Text.CharTextHandler(C, CurrentChar, CurrentPoint);  
                    here:
                        key = Console.ReadKey();
                        CurrentChar = key.KeyChar;

                    }
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
