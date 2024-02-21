using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameProject
{
    public class Player : Sprites
    {
        const float Speed = 800f;
        private Vector2 Velocity;

        public Player(Texture2D texture, Vector2 position) : base(texture, position)
        {
        }

        public void UpdateVelocity()
        {
            KeyboardState State = Keyboard.GetState();  
           
            Velocity = Vector2.Zero;

            if (State.IsKeyDown(Keys.W)) Velocity.Y--;
            if (State.IsKeyDown(Keys.S)) Velocity.Y++;
            if (State.IsKeyDown(Keys.A)) Velocity.X--;
            if (State.IsKeyDown(Keys.D)) Velocity.X++;

            if(Velocity!=Vector2.Zero) Velocity.Normalize();
        }

        public void Update()
        {
            UpdateVelocity();
            _position += Velocity * Speed * Globals.Time;
        }
    }
}
