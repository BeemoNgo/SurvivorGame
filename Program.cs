using System;
using SplashKitSDK;

namespace ShapeDrawer
{
    public class Program
    {
        public static void Main()
        {
            Window window = new Window("Shape Drawer", 800, 700);
            GameMethod game = new GameMethod();
            do
            {
                SplashKit.ProcessEvents();
                SplashKit.ClearScreen();
                
                game.Draw();
                game.Update();
                SplashKit.RefreshScreen();
            } while (!window.CloseRequested);
        }
    }
}
