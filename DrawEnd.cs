using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class DrawEnd:DrawStrategy
    {
        public DrawEnd(GameMethod game) : base(game)
        {

        }
        public override void Draw()
        {
            SplashKit.DrawText("You Lose!", Color.Black, 330, 50);
            SplashKit.DrawText("Press R to restart", Color.Red, 340, 100);
        }
    }
}
