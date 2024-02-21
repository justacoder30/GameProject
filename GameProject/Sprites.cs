using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Sprites
    {
        public Texture2D _texture;
        public Vector2 _position;
        public Vector2 _origin;

        public Sprites(Texture2D texture, Vector2 position)
        {
            _texture = texture;
            _position = position;
            _origin = new Vector2(_texture.Width/2, _texture.Height/2);
        }

        public void Draw()
        {
            Globals.SpriteBatch.Draw(_texture, _position, null, Color.White, 0f, _origin, 1f, SpriteEffects.None, 0f);
        }
    }
}
