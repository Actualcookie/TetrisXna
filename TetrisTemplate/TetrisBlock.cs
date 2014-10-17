using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

class TetrisBlock
{
    protected Vector2 position;
    Texture2D block;
    //Point relPos;
    float movetime;
    protected Color[,] shape;
    public Vector2 SetPosition;
    protected bool moveright, moveleft;

    public TetrisBlock(Texture2D b)
    {
        block = b;
        SetPosition = new Vector2(4, -1);
        position = Vector2.Zero;
        moveleft = false;
        moveright = false;
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        if (inputHelper.KeyPressed(Keys.Right))
        {
            this.position.X += block.Width;
        }
        if (inputHelper.KeyPressed(Keys.Left))
        {
            this.position.X -= block.Width;
        }
        if (movetime==10|| movetime==4)
        {
            this.position.Y += block.Height;
        }

        if (inputHelper.KeyPressed(Keys.Up))
        {
            this.Rotate();
        }
    }


   /* public bool CheckBorderLeft()
    {
        for (int x = 0; x < shape.GetLength(0); x++)
            for (int y = 0; y < shape.GetLength(1); y++)
                if (this.shape[x, y] == Color.White)
                {

                    if (position.X == block.Width * 12 + block.Width * x)
                        moveleft = true;

                }
        return moveleft = false;
    }

    public bool CheckBorderRight()
    {
        for (int x = 0; x < shape.GetLength(0); x++)
            for (int y = 0; y < shape.GetLength(1); y++)
                if (this.shape[x, y] == Color.White)
                {
                    if (position.X == (12 - 1) * block.Width)
                        moveright= true;
                }
        return moveright = false;
    }*/
   /* public TetrisGrid RandomBlok()
    {

    }*/

    protected void Rotate()
    {
        Color[,] shape2 = new Color[4, 4];
        for (int i = 3; i >= 0; --i)
            for (int j = 0; j < 4; j++)
                shape2[j, 3 - i] = shape[i, j];
        //Store a clockwisely rotated version of shape in shape2

        for (int i = 0; i < 4; i++)
            for (int j = 0; j < 4; j++)
                shape[i, j] = shape2[i, j];
        //Copy the rotated version back to the original
    }
    
   /* protected bool Collision()
    {
        if( )
        {

        }
    }*/

    public virtual void Update(GameTime gameTime)
    {  
        movetime = gameTime.ElapsedGameTime.Milliseconds;
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
