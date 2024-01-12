using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ShapeDrawer
{
    internal class KeyBoardInGame:TrackKeyBoardStrategy
    {
        public KeyBoardInGame(GameMethod game) : base(game)
        {

        }
        public override void HandleKeyboard()
        {
            if (SplashKit.KeyDown(KeyCode.UpKey))
            {
                _game.Catnip.MoveUp();
            }
            if (SplashKit.KeyDown(KeyCode.DownKey))
            {
                _game.Catnip.MoveDown();
            }
            if (SplashKit.KeyDown(KeyCode.LeftKey))
            {
                _game.Catnip.MoveLeft();
            }
            if (SplashKit.KeyDown(KeyCode.RightKey))
            {
                _game.Catnip.MoveRight();
            }
        }
    }
}
