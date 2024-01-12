using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class DrawInGame: DrawStrategy
    {
        public DrawInGame(GameMethod game):base(game)
        {

        }
        public override void Draw()
        {
            SplashKit.DrawText(String.Format("Health: {0}",_game.Catnip.Health), Color.Black, 20, 10);
            _game.DrawEnemy();
            _game.DrawProjectile();
            _game.Catnip.Draw();
        }
    }
}
