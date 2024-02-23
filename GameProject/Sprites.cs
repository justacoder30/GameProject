using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Sprites
    {
        public Texture2D _texture;
        public Vector2 _position;

        public Sprites(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, Color.White);
        }
    }
}
