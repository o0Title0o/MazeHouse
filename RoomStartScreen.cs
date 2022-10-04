using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace MazeHouse
{
    public class RoomStartScreen : Screen
    {
        Texture2D gameplayTexture;
        Game1 game;

        //Animation of player
        int direction;
        int frame;
        int totalFrames;
        int framePerSec;
        float timePerFrame;
        float totalElapsed;
        float elapsed;

        //player
        Texture2D player;
        Vector2 playerPosition;

        //Door
        public Texture2D doorTest;
        public Vector2 doorTestPosition;

        //Random Room
        Random r = new Random();
        int RandomRoomStart;

        public RoomStartScreen(Game1 game, EventHandler theScreenEvent)
            : base(theScreenEvent)
        {
            //Load the background texture for the screen

            //Picture
            gameplayTexture = game.Content.Load<Texture2D>("Room");
            player = game.Content.Load<Texture2D>("Player");
            doorTest = game.Content.Load<Texture2D>("DoorTest");

            //Animation of player
            direction = 0;
            frame = 0;
            totalFrames = 4;
            framePerSec = 12;
            timePerFrame = (float)1 / framePerSec;
            totalElapsed = 0;

            //Position
            playerPosition = new Vector2(480,120);
            doorTestPosition = new Vector2(480, 480);
           
            this.game = game;
        }

        public override void Update(GameTime theTime)
        {
            //Keyboard
            elapsed = (float)theTime.ElapsedGameTime.TotalSeconds;
            if (Keyboard.GetState().IsKeyDown(Keys.Down) || Keyboard.GetState().IsKeyDown(Keys.S))
            {
                direction = 0;
                playerPosition.Y = playerPosition.Y + playerSpeed;
                UpdateFrame(elapsed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Left) || Keyboard.GetState().IsKeyDown(Keys.A))
            {
                direction = 1;
                playerPosition.X = playerPosition.X - playerSpeed;
                UpdateFrame(elapsed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Right) || Keyboard.GetState().IsKeyDown(Keys.D))
            {
                direction = 2;
                playerPosition.X = playerPosition.X + playerSpeed;
                UpdateFrame(elapsed);
            }
            if (Keyboard.GetState().IsKeyDown(Keys.Up) || Keyboard.GetState().IsKeyDown(Keys.W))
            {
                direction = 3;
                playerPosition.Y = playerPosition.Y - playerSpeed;
                UpdateFrame(elapsed);
            }

            //Hit Left
            if (playerPosition.X < 0)
            {
                playerPosition.X = 0;
            }
            //Hit Right
            if (playerPosition.X > 1080 - (playerSize * 5))
            {
                playerPosition.X = 1080 - (playerSize * 5);
            }
            //Hit Up
            if (playerPosition.Y < 60)
            {
                playerPosition.Y = 60;
            }
            //Hit Down
            if (playerPosition.Y > 720 - (playerSize * 5))
            {
                playerPosition.Y = 720 - (playerSize * 5);
            }

            //Hitbox
            Rectangle playerRectangle = new Rectangle((int)playerPosition.X, (int)playerPosition.Y, playerSize * 5, playerSize * 5);
            Rectangle DoorTestRectangle = new Rectangle((int)doorTestPosition.X, (int)doorTestPosition.Y, 120, 240);

            //Door
            if (playerRectangle.Intersects(DoorTestRectangle) == true)
            {
                //Spawn Reset
                playerPosition = new Vector2(480, 120);

                //Random Room
                RandomRoomStart = r.Next(4);
                if(RandomRoomStart == 0)
                {
                    ScreenEvent.Invoke(game.mGameplayScreen1, new EventArgs());
                    return;
                }
                if (RandomRoomStart == 1)
                {
                    ScreenEvent.Invoke(game.mGameplayScreen1, new EventArgs());
                    return;
                }
                if (RandomRoomStart == 2)
                {
                    ScreenEvent.Invoke(game.mGameplayScreen2, new EventArgs());
                    return;
                }
                if (RandomRoomStart == 3)
                {
                    ScreenEvent.Invoke(game.mGameplayScreen2, new EventArgs());
                    return;
                }
            }

            base.Update(theTime);
        }
        public override void Draw(SpriteBatch theBatch)
        {
            theBatch.Draw(gameplayTexture, Vector2.Zero, Color.White);
            theBatch.Draw(player, playerPosition, new Rectangle(playerSize * 5 * frame, playerSize * 5 * direction, playerSize * 5, playerSize * 5), Color.White);
            theBatch.Draw(doorTest, doorTestPosition, new Rectangle(0, 0, 120, 240), Color.White);
            base.Draw(theBatch);
        }
        public void UpdateFrame(float elapsed)
        {
            totalElapsed += elapsed;
            if (totalElapsed > timePerFrame)
            {
                frame = (frame + 1) % totalFrames;
                totalElapsed -= timePerFrame;
            }
        }
    }
}