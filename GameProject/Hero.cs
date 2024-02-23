using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class Hero : Game
    {
        private EntityManager _entityManager;

        public Hero()
        {
            Globals.Graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            Globals.WindowSize = new(1920, 1080);
            Globals.Graphics.PreferredBackBufferWidth = Globals.WindowSize.X;
            Globals.Graphics.PreferredBackBufferHeight = Globals.WindowSize.Y;
            Globals.Graphics.ApplyChanges();


            Globals.Content = Content;
            _entityManager = new EntityManager();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            Globals.SpriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here    

        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here

            Globals.Update(gameTime);
            _entityManager.Update();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here

            _entityManager.Draw();

            base.Draw(gameTime);
        }
    }
}
