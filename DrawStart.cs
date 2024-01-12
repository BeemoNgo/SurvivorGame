using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SplashKitSDK;
namespace ShapeDrawer
{
    internal class DrawStart :DrawStrategy
    {
        public DrawStart(GameMethod game): base(game)
        {

        }
        public override void Draw()
        {
            SplashKit.DrawText("Welcome to Survior.io", Color.Black, 330,50);
            SplashKit.DrawText("Press S to start", Color.Red, 340, 100);
        }
    }
}
