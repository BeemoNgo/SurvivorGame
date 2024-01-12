using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeDrawer
{
    internal abstract class DrawStrategy
    {
        protected GameMethod _game;
        public DrawStrategy(GameMethod game)
        {
            _game = game;
        }
        public virtual void Draw()
        {

        }

    }
}
