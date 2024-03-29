﻿using Microsoft.Xna.Framework;

namespace GameProject
{
    public class Camera
    {
        public Matrix Translation { get; set; }

        public void FolowPLayer(Player player)
        {
            var dx = Globals.WindowSize.X/2 - player._position.X;
            dx = MathHelper.Clamp(dx, Globals.WindowSize.X - Map.MapWidth, 0);
            var dy = Globals.WindowSize.Y/2 - player._position.Y;
            dy = MathHelper.Clamp(dy, Globals.WindowSize.Y - Map.MapHeight, 0);
            Translation = Matrix.CreateTranslation(dx, dy, 0f); 
        }
    }
}
