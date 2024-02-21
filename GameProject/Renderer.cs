using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameProject
{
    public class Renderer
    {
        private RenderTarget2D _target;
        private Rectangle Rectangle;

        public Renderer()
        {
            _target = new RenderTarget2D(Globals.Graphics.GraphicsDevice, Globals.WindowSize.X, Globals.WindowSize.Y);
            Rectangle = new Rectangle(0, 0, Globals.WindowSize.X, Globals.WindowSize.Y);
        }

        public void Activate()
        {
            Globals.Graphics.GraphicsDevice.SetRenderTarget(_target);
        }

        public void Draw()
        {
            Globals.Graphics.GraphicsDevice.SetRenderTarget(null);
            Globals.SpriteBatch.Begin(samplerState: SamplerState.PointClamp);
            Globals.SpriteBatch.Draw(_target, Rectangle, Color.White);
            Globals.SpriteBatch.End();
        }
    }
}
