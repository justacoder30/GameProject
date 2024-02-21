

using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class EntityManager
    {
        Player _player;

        public EntityManager()
        {
            _player = new(Globals.Content.Load<Texture2D>("player"), new(0, 0));
        }

        public void Update()
        {
            _player.Update();
        }

        public void Draw()
        {
            Globals.SpriteBatch.Begin();
            _player.Draw();
            Globals.SpriteBatch.End();
        }
    }
}
