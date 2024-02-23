using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class EntityManager
    {
        Player _player;
        Map _map1;
        Renderer _render;
        Camera _camera;

        public EntityManager()
        {
            _render = new Renderer();
            _player = new(Globals.Content.Load<Texture2D>("hero"), new(Globals.WindowSize.X/2, Globals.WindowSize.Y/2));
            _map1 = new Map();
            _camera = new Camera();
            _render.SetResolution(1920, 1080);
        }

        public void Update()
        {
            InputManager.Update();
            _player.Update();
            _camera.FolowPLayer(_player);
        }

        public void Draw()
        {
            //_render.Activate();

            Globals.SpriteBatch.Begin(transformMatrix: _camera.Translation);
            _map1.Draw();
            _player.Draw();
            Globals.SpriteBatch.End();

            //_render.Draw();
        }
    }
}
