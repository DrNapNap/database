using database;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace UserInterface
{
    public class GameWorld : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;

        private SpriteFont text;
        private Character result;


 
        private List<GameObject> gameObjects = new List<GameObject>();

        private List<GameObject> newGameObjects = new List<GameObject>();

        private static GameWorld instance;

        public static GameWorld Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new GameWorld();
                }
                return instance;
            }
        }

        public static float DeltaTime { get; private set; }

        private GameWorld()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            var mapper = new AdventurerMapper();
            var provider = new SQLiteDatabaseProvider("Data Source=cyklingmanager.db;Version=3;new=true");

            var repo = new Reading(provider, mapper);
            repo.Open();
            repo.AddAdmin(10000000);
            result = repo.GetAllAdmin(10000000);
            repo.AddTeam(29542764, "Four lions");
            repo.AddTeam(87364522, "DK Vikings");
            repo.AddTeam(56982365, "Arsenal");
            repo.AddTornament("Tour De France", "Frankrig", 50, 2000000000);
            repo.Close();

            Director director = new Director(new PlayerBuilder());

            gameObjects.Add(director.Construct());


            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Awake();
            }




            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            text = Content.Load<SpriteFont>("test");

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Start();
            }
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            DeltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Update(gameTime);
            }
            base.Update(gameTime);
        
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            spriteBatch.Begin();
            spriteBatch.DrawString(text, "Buget: " + result.Buget.ToString(), new Vector2(0, 20), Color.Red, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);

            spriteBatch.DrawString(text, "tryk space for at AddTornament: ", new Vector2(0, 50), Color.Red, 0f, Vector2.Zero, 1.5f, SpriteEffects.None, 1f);

            

            for (int i = 0; i < gameObjects.Count; i++)
            {
                gameObjects[i].Draw(spriteBatch);
            }



            spriteBatch.End();

            base.Draw(gameTime);
        }

        public void Instantiate(GameObject go)
        {
            newGameObjects.Add(go);
        }


        public Component FindObjectOfType<T>() where T : Component
        {
            foreach (GameObject gameObject in gameObjects)
            {
                Component c = gameObject.GetComponent<T>();

                if (c != null)
                {
                    return c;
                }
            }

            return null;


        }


    }
}
