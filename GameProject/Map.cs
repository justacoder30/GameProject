
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;
using System;

namespace GameProject
{
    public class Map
    {
        public static float MapWidth;
        public static float MapHeight;
        public static int TILES_SIZE = 128;
        Texture2D texture;

        public static int[,] _tiles =
        {
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,1,1,0,1,1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,1,1,0,0,0,0,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,1,1,1,0,0,0,0,0,0,0,1,1,0,1,1,1,1,0,0,0,0,0,0,0,0,0,0,0,0,1 },
            { 1,0,0,0,0,0,0,0,0,0,0,0,0,0,0,1,1,0,0,0,0,0,0,1,1,1,0,0,1,1,1,1,0,0,1 },
            { 1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1,1 },
        };

        private static Rectangle[,] Colliders { get; } = new Rectangle[_tiles.GetLength(0), _tiles.GetLength(1)];


        public Map()
        {
            MapWidth = _tiles.GetLength(1) * TILES_SIZE;
            MapHeight = _tiles.GetLength(0) * TILES_SIZE;
            texture = Globals.Content.Load<Texture2D>("tile1");

            for(int i=0; i < _tiles.GetLength(0); i++)
            {
                for(int j=0; j < _tiles.GetLength(1); j++)
                {
                    if (_tiles[i, j] != 0) 
                        Colliders[i, j] = new Rectangle(j * TILES_SIZE, i * TILES_SIZE, TILES_SIZE, TILES_SIZE);
                }
            }
        }

        public static List<Rectangle> GetNearestColliders(Rectangle bounds)
        {
            int leftTile = (int)Math.Floor((float)bounds.Left / TILES_SIZE);
            int rightTile = (int)Math.Ceiling((float)bounds.Right / TILES_SIZE) - 1;
            int topTile = (int)Math.Floor((float)bounds.Top / TILES_SIZE);
            int bottomTile = (int)Math.Ceiling((float)bounds.Bottom / TILES_SIZE) - 1;

            leftTile = MathHelper.Clamp(leftTile, 0, _tiles.GetLength(1));
            rightTile = MathHelper.Clamp(rightTile, 0, _tiles.GetLength(1));
            topTile = MathHelper.Clamp(topTile, 0, _tiles.GetLength(0));
            bottomTile = MathHelper.Clamp(bottomTile, 0, _tiles.GetLength(0));

            List<Rectangle> result = new();

            for (int x = topTile; x <= bottomTile; x++)
            {
                for (int y = leftTile; y <= rightTile; y++)
                {
                    if (_tiles[x, y] != 0) result.Add(Colliders[x, y]);
                }
            }

            return result;
        }

        public void Draw()
        {
            for(int x = 0; x < _tiles.GetLength(0); x++)
            {
                for (int y = 0; y < _tiles.GetLength(1); y++)
                {
                    if (_tiles[x, y] == 1) Globals.SpriteBatch.Draw(texture, new Vector2(y * TILES_SIZE, x * TILES_SIZE), Color.White); 
                }
            }
        }
    }
}
