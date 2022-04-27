using database;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace UserInterface
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private Rectangle mainFrame;



        private Texture2D back;
        private SpriteFont text;
        private List<Character> result;

        public GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {

            var mapper = new AdventurerMapper();
            var provider = new SQLiteDatabaseProvider("Data Source=cyklingmanager.db;Version=3;new=true");


            var repo = new Reading(provider, mapper);
            repo.Open();

            repo.AddAdmin(2983);
            repo.AddAdmin(2344);
            repo.AddAdmin(12);

            repo.AddTornament("Tour De France" , "Frankrig", 50 , 2000000000, 29542764);
            repo.AddTornament("Danmark rundt", "Danmark", 30, 500000, 87364522);
            repo.AddTornament("Giro d’Italia", "Italien", 50, 1500000000, 56982365);

            result = repo.GetAllAdmin();

            repo.Close();

            // TODO: Add your initialization logic here

            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);


            text = Content.Load<SpriteFont>("test");

            // TODO: use this.Content to load your game content here
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();



            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);
            spriteBatch.Begin();


            spriteBatch.DrawString(text, "Price: " + result[0].Buget.ToString(), new Vector2(0, 20), Color.Red, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);





            spriteBatch.End();

            // TODO: Add your drawing code here

            base.Draw(gameTime);
        }
    }
}
