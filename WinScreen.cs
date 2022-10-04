using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MazeHouse
{
    public class WinScreen : Screen
    {
        Texture2D menuTexture;
        Game1 game;
        public WinScreen(Game1 game, EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            //Load the background texture for the screen
            menuTexture = game.Content.Load<Texture2D>("Win");
            this.game = game;
        }
        public override void Update(GameTime theTime)
        {
            if (Keyboard.GetState().IsKeyDown(Keys.R) == true)
            {
                ScreenEvent.Invoke(game.mRoomStartScreen, new EventArgs());
                return;
            }
            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(menuTexture, Vector2.Zero, Color.White); base.Draw(theBatch);
        }
    }
}
