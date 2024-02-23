using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class Player : Sprites
    {
        const float Speed = 800f;
        const float Jump = 1500f;
        const float Gravity = 4000f;
        private bool _onground;
        private const int OFFSET = 10;
        private Vector2 Velocity;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        private Rectangle CalculateBounds(Vector2 pos)
        {
            return new((int)pos.X + OFFSET, (int)pos.Y, _texture.Width - (2 * OFFSET), _texture.Height);
        }

        public void UpdateVelocity()
        {
            KeyboardState State = Keyboard.GetState();  
           
            Velocity.X = 0;

            if (State.IsKeyDown(Keys.A)) Velocity.X = -Speed;
            if (State.IsKeyDown(Keys.D)) Velocity.X = +Speed;

            if(State.IsKeyDown(Keys.Space) && _onground) Velocity.Y = -Jump;

            Velocity.Y += Gravity * Globals.Time;
        }

        public void UpdatePosition()
        {
            _onground = false;
            var newPos = _position + (Velocity * Globals.Time);
            Rectangle newRect = CalculateBounds(newPos);

            foreach (var collider in Map.GetNearestColliders(newRect))
            {
                if (newPos.X != _position.X)
                {
                    newRect = CalculateBounds(new(newPos.X, _position.Y));
                    if (newRect.Intersects(collider))
                    {
                        if (newPos.X > _position.X) newPos.X = collider.Left - _texture.Width + OFFSET;
                        else newPos.X = collider.Right - OFFSET;
                        continue;
                    }
                }

                newRect = CalculateBounds(new(_position.X, newPos.Y));
                if (newRect.Intersects(collider))
                {
                    if (Velocity.Y > 0)
                    {
                        newPos.Y = collider.Top - _texture.Height;
                        _onground = true;
                        Velocity.Y = 0;
                    }
                    else
                    {
                        newPos.Y = collider.Bottom;
                        Velocity.Y = 0;
                    }
                }
            }

            _position = newPos;
        }

        public void Update()
        {
            UpdateVelocity();
            UpdatePosition();
        }
    }
}
