using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class KeyBoardEndGame : TrackKeyBoardStrategy
    {
        public KeyBoardEndGame(GameMethod game): base(game)
        {

        }

        public override void HandleKeyboard()
        {
            
            if (SplashKit.KeyDown(KeyCode.RKey))
            {

                _game.KeyBoardStrategy = new KeyBoardInGame(_game);
                _game.DrawStrategy = new DrawInGame(_game);
                _game.InGame = true;
                _game.Reset();
            }
        }
    }
}
