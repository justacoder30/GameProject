

using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class EntityManager
    {
        Player _player;
        Map _map1;
        Renderer _render;

        public EntityManager()
        {
            _player = new(Globals.Content.Load<Texture2D>("hero"), new(Globals.WindowSize.X/2, Globals.WindowSize.Y/2));
            _map1 = new Map();
            _render = new Renderer();
        }

        public void Update()
        {
            _player.Update();
        }

        public void Draw()
        {
            _render.Activate();

            Globals.SpriteBatch.Begin();
            _map1.Draw();
            _player.Draw();
            Globals.SpriteBatch.End();

            _render.Draw();
        }
    }
}
