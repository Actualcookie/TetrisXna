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
    protected Color[,] shape, shape2;
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
        if (inputHelper.KeyPressed(Keys.Right, false))
        {
            this.position.X += block.Width / 2;
            if(Collision())
                this.position.X -= block.Width / 2;
        }
        //moves Tetromino Left
        if (inputHelper.KeyPressed(Keys.Left, false))
        {
            this.position.X -= block.Width / 2;
            if(Collision())
                this.position.X += block.Width / 2;
        }  
        //should move the Tetromino down
        if (inputHelper.IsKeyDown(Keys.Down))
        {
            if (!GroundCollision() || Collision())
                this.position.Y += 0.5f * speed;


        }
        //rotates the Tetromino
        if (inputHelper.KeyPressed(Keys.Up))
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
       //need working code
    }
    


    public virtual void Update(GameTime gameTime)
    {
        if (Collision() || GroundCollision())
        {
            speed = 0;
        }
        else 
        {
            speed = 10 + 10 * TetrisGame.GameWorld.Grid.Level;
            position.Y += speed * (float)gameTime.ElapsedGameTime.TotalSeconds;
        }

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
                     if (TetrisGame.GameWorld.Grid.colGrid[((int)position.X + x * block.Width) / block.Width, ((int)position.Y + ((y + 1) * + block.Height)) / block.Height] != Color.White)
                  {
                        return true;
                  }
               }
        return false;
    }

    public float Speed
    {
        get { return speed; }
    }
}
