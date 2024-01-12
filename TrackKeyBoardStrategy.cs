using SplashKitSDK;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal abstract class TrackKeyBoardStrategy
    {
        protected GameMethod _game;
        public TrackKeyBoardStrategy(GameMethod game)
        {
            _game = game;
        }

        public virtual void HandleKeyboard()
        {
           
        }
    }
}
