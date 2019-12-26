using System;
using System.Collections.Generic;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using CMouse = Cosmos.System.MouseManager;
using Point = Cosmos.System.Graphics.Point;
using JackalOS.Drivers;

namespace JackalOS.Applications
{
    /// <summary>
    /// Notepad Application.
    /// </summary>
    public class Notepad
    {
        readonly int ScreenWidth = 800;
        readonly int ScreenHeight = 600;
        Pen MousePen = new Pen(Color.LightPink);
        static Color BackColor = Color.DarkCyan;
        Pen GUIHomePen = new Pen(BackColor);
        Point PrevMouse = new Point(50, 50);
        TextRenderer Text = new TextRenderer();
        ConsoleKeyInfo Key;
        List<Point> BackspaceBuffer = new List<Point>();
        public Notepad()
        {
        }
        /// <summary>
        /// This function initializes the Notepad App. Draws the Bar over the page.
        /// Not to be used outside Notepad Class.
        /// </summary>
        /// <param name="C">Canvas Object</param>
        private void Initialize(Canvas C)
        {
            //Draw the bar above
            C.DrawFilledRectangle(new Pen(Color.LightCyan), 0, 0, ScreenWidth - 1, 20);
            C.DrawFilledRectangle(new Pen(Color.Red), ScreenWidth - 21, 0, 20, 20);
            C.DrawLine(new Pen(Color.Black, 2), ScreenWidth - 21, 0, ScreenWidth - 1, 20);
            C.DrawLine(new Pen(Color.Black, 2), ScreenWidth - 1, 0, ScreenWidth - 21, 20);
        }
        /// <summary>
        /// Local function to remove the mouse specifically for the Notepad.
        /// </summary>
        /// <param name="C">Canvas Object</param>
        /// <param name="Remove">Point from which mouse is to be removed</param>
        private void RemoveMouse(Canvas C, Point Remove)
        {
            C.DrawFilledRectangle(GUIHomePen, Remove, 8, 8);
            if (Remove.Y <= 20)
            {
                Initialize(C);
            }
        }
        /// <summary>
        /// Launch the Notepad Application.
        /// </summary>
        /// <param name="C">Canvas Object</param>
        public void Launch(Canvas C)
        {
            C.Clear(BackColor);
            Initialize(C);
            bool AllowText = true;
            bool TextTrigger = true;
            Point InitialPoint = new Point(10, 30);
            Point CurrentCursor = new Point(10, 60);
            Point OldCursor = new Point(10, 60);
            do
            {
                while (AllowText)
                {
                    if (TextTrigger)
                    {
                        Text.StringTextHandler(C, "enter your text below, press ~ to stop, press ` for backspace.", InitialPoint);
                        TextTrigger = false;
                    }

                    Key = Console.ReadKey();
                    char CurrentChar = Key.KeyChar;

                    if (CurrentChar == '~')
                    {
                        AllowText = false;
                        break;
                    }
                    else if(CurrentChar == '`')
                    {
                        if (BackspaceBuffer.Count > 0)
                        {
                            C.DrawFilledRectangle(GUIHomePen, BackspaceBuffer[BackspaceBuffer.Count - 1], CurrentCursor.X - BackspaceBuffer[BackspaceBuffer.Count - 1].X, 20);
                            CurrentCursor = BackspaceBuffer[BackspaceBuffer.Count - 1];
                            BackspaceBuffer.RemoveAt(BackspaceBuffer.Count - 1);
                        }
                    }
                    else
                    {
                        BackspaceBuffer.Add(CurrentCursor);
                        OldCursor = CurrentCursor;
                        CurrentCursor = Text.CharTextHandler(C, CurrentChar, CurrentCursor);
                    }

                    if (CurrentCursor.X > 800)
                    {
                        CurrentCursor.X = 10;
                        CurrentCursor.Y += 30;
                    }

                }

                Point CurMouse = Mouse.MouseLimit((int)CMouse.X, (int)CMouse.Y);
                Mouse.DrawMouse(C, MousePen, CurMouse);

                if (Mouse.Click())
                {
                    //Check Click on Power Button
                    if ((CurMouse.X > ScreenWidth - 21) && (CurMouse.X < ScreenWidth))
                    {
                        if (CurMouse.Y < 21)
                        {
                            return;
                        }
                    }
                }
                if ((PrevMouse.X != CurMouse.X) || (PrevMouse.Y != CurMouse.Y))
                {
                    RemoveMouse(C, PrevMouse);
                    PrevMouse = CurMouse;
                }

            } while (true);

        }
    }
}
/*
 * Console.WriteLine("Enter your text below. Press y to continue.");
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
*/