using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal class KeyBoardStartGame: TrackKeyBoardStrategy
    {
        public KeyBoardStartGame(GameMethod game):base(game)
        {

        }
        public override void HandleKeyboard()
        {
            if (SplashKit.KeyDown(KeyCode.SKey))
            {
                _game.KeyBoardStrategy = new KeyBoardInGame(_game);
                _game.DrawStrategy = new DrawInGame(_game);
                _game.InGame = true;
            }
        }
    }
}
