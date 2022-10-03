using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;

namespace MazeHouse
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Screen
        public Screen mCurrentScreen;
        public TitleScreen mTitleScreen;
        public RuleScreen mRuleScreen;
        public RoomStartScreen mRoomStartScreen;

        public GameplayScreen1 mGameplayScreen1;
        public GameplayScreen2 mGameplayScreen2;


        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 1080;
            graphics.PreferredBackBufferHeight = 720;
            graphics.ApplyChanges();
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            //Screen
            mTitleScreen = new TitleScreen(this, new EventHandler(GameplayScreenEvent));
            mRuleScreen = new RuleScreen(this, new EventHandler(GameplayScreenEvent));
            mRoomStartScreen = new RoomStartScreen(this, new EventHandler(GameplayScreenEvent));

            mGameplayScreen1 = new GameplayScreen1(this, new EventHandler(GameplayScreenEvent));
            mGameplayScreen2 = new GameplayScreen2(this, new EventHandler(GameplayScreenEvent));

            mCurrentScreen = mTitleScreen;

        }
        protected override void UnloadContent()
        {
            //TODO: Unload any non ContentManager content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            //Screen
            mCurrentScreen.Update(gameTime);

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();
            mCurrentScreen.Draw(spriteBatch);
            spriteBatch.End();
            base.Draw(gameTime);
        }

        public void GameplayScreenEvent(object obj, EventArgs e)
        {
            mCurrentScreen = (Screen)obj;
        }
    }
}
