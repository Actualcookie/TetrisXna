using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisBlock
{
    public Vector2 position;
    Texture2D block;

    Color[,] shape;

    public TetrisBlock(Texture2D b)
    {
        block = b;
        shape = new Color[4, 4]
        {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.White, Color.White, Color.White},
            {Color.Red,   Color.Red,   Color.Red,   Color.Red},
            {Color.White, Color.White, Color.White, Color.White},
        };
        position = Vector2.Zero;
    }

    public virtual void Update(GameTime gameTime)
    {

    }

    public virtual void Draw(GameTime gameTime, SpriteBatch s)
    {
        for(int x = 0; x < 4; x++)
            for(int y = 0; y < 4; y++)
                if (shape[x, y] != Color.White)
                {
                    s.Draw(block, new Vector2(position.X + x * block.Width, position.Y + y * block.Height), shape[x, y]);
                }
    }


}
