using System;
using Sys = Cosmos.System;
using Cosmos.System.Graphics;
using System.Drawing;
using Point = Cosmos.System.Graphics.Point;

public class Icons
{
    private Point ShutdownStart = new Point(750, 20);
    private int ShutdownSize = 30;
	public Icons()
	{
	}
    public void Render(Canvas canvas)
    {
        //Shutdown Icon
        canvas.DrawFilledRectangle(new Pen(Color.Red), ShutdownStart, ShutdownSize, ShutdownSize);
        canvas.DrawCircle(new Pen(Color.White), new Point(765, 35), ShutdownSize / 2);
        canvas.DrawFilledRectangle(new Pen(Color.White), new Point(765, 25), 1, 20);
    }

    public void ReRender(int x, int y, Canvas canvas)
    {
        if ((x >= 738) && (x <= 792))
        {
            if ((y >= 8) && (y <= 62))
            {
                Render(canvas);
            }
        }
    }
    public void Click(int x, int y)
    {
        if ((x >= 750) && (x <= 780))
        {
            if ((y >= 20) && (y <= 50))
            {
                Sys.Power.Shutdown();
            }
        }
    }
}
