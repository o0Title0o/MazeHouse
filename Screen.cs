using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


namespace MazeHouse
{
    public class Screen
    {
        protected EventHandler ScreenEvent;

        public Screen(EventHandler theScreenEvent)
        {
            ScreenEvent = theScreenEvent;
        }
        public virtual void Update(GameTime theTime)
        {
            
        }
        public virtual void Draw(SpriteBatch theBatch)
        {

        }
    }
}
