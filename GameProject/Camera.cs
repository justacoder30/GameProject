using Microsoft.Xna.Framework;

namespace GameProject
{
    public class Camera
    {
        public Matrix Translation { get; set; }

        public void FolowPLayer(Player player)
        {
            Translation = new Matrix();
            var dx = Globals.WindowSize.X/2 - player._position.X;
            var dy = Globals.WindowSize.Y/2 - player._position.Y;
            Translation = Matrix.CreateTranslation(dx, dy, 0); 
        }
    }
}
