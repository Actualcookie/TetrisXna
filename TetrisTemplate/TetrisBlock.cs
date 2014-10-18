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
    protected Color[,] shape;
    float speed;


    public TetrisBlock(Texture2D b)
    {
        block = b;
        position = Vector2.Zero;
        speed = 10;
    }


    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        //moves Tetromino right
        if (inputHelper.KeyPressed(Keys.Right))
        {
            this.position.X += (block.Width/2);
        }
        //moves Tetromino Left
        if (inputHelper.KeyPressed(Keys.Left))
        {
            this.position.X -= (block.Width/2);
        }  
        //should move the Tetromino down
        if (inputHelper.IsKeyDown(Keys.Down)&&GroundCollision()==false)
        {

            this.position.Y += block.Width;
            this.position.Y += 0.5f * speed;


        }
        //rotates the Tetromino
        if (inputHelper.KeyPressed(Keys.Up)&&GroundCollision()==false)
        {
            this.Rotate();
        }
    }

   public  Color[,] Shape
      {
          get { return shape;}
      }    
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
    


    public virtual void Update(GameTime gameTime)
    {
        if (!Collision()||!GroundCollision())
        {
            speed = 10 + 10 * TetrisGame.GameWorld.Grid.Level;
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }
        GroundCollision();
        Collision();


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
    public Vector2 Position
    {
        get { return position; }
    }    

   public bool GroundCollision()
    {
       for (int x = 0; x < Shape.GetLength(0); x++)
      
           for (int y = 0; y < Shape.GetLength(1); y++)
          
                if (this.Shape[x,y] != Color.White)
                     {
                        if ((position.Y + ((y+1)  * block.Height) > 20*block.Height))
                         {
                             return true;
                            }
                }
            return false;
       }
 
    public bool Collision()
    {
        //checks if a Tetromino will intersect
        for (int x = 0; x < Shape.GetLength(0); x++)
            for (int y = 0; y < Shape.GetLength(1); y++)
            {
                 if (this.Shape[x, y] != Color.White)
                     if (TetrisGame.GameWorld.Grid.colGrid[((int)position.X + x * block.Width) / block.Width, ((int)position.Y + ((y + 1) * +block.Height)) / block.Height] != Color.White)
                  {
                        return true;
                  }
               }
        return false;
    }
}
