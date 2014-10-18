using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

/*
 * a class for representing the Tetris playing grid
 */
class TetrisGrid
{
   public Color[,] colGrid = new Color[12, 22];
   public int score, level;
    /*
     * sprite for representing a single grid block
     */
    Texture2D gridblock;

    /*
     * the position of the tetris grid
     */
    Vector2 position;

    /*
     * width in terms of grid elements
     */

    public TetrisGrid(Texture2D b)
    {
        //draws the grid
        level = score / 30;
        gridblock = b;
        position = Vector2.Zero;
        for (int x = 0; x < colGrid.GetLength(0); x++)
            for (int y = 0; y < 20; y++)
                colGrid[x, y] = Color.White;

    }
    //Width on the grid
/*  public bool Collision()
    {
       //checks if a Tetromino will intersect
        for (int x = 0; x < shape.GetLength(0); x++)
            for (int y = 0; y <shape.GetLength(1); y++)
            {
                if (shape[x, y] != Color.White)
                {
                    if (colGrid[((int)position.X + x * gridblock.Width) / gridblock.Width, ((int)position.Y + ((y + 1) * + gridblock.Height)) / gridblock.Height] != Color.White)
                    {
                        return true;
                    }
                }
            }
        return false;
    }
    public void ReturntoGrid()
    {
        //writes the shape grid to the main grid
        if (Collision())
        {
            for(int x= 0; x < 4; x++)
                for(int y= 0; y < 4; y++)
                 if(shape[x,y]!= Color.White )//moet nog een timer hebben net als het naar beneden bewegen
                {
                    colGrid[((int)position.X + x * gridblock.Width) / gridblock.Width, ((int)position.Y + ((y + 1) * +gridblock.Height)) / gridblock.Height] = shape;
                }

        }


    // Method checks if top row of the Grid contains a Tetromino
    public bool TopRow()
    {
        for (int g = 0; g < colGrid.GetLength(0); g++)
            if (colGrid[g, 0] != Color.White)
            {

            }
        return false;
    }
 */

    public int Width
    {
        get { return 12; }
    }

    /*
     * height in terms of grid elements
     */
    public int Height
    {
        get { return 20; }
    }
    //current score
    public int Score
    {
        get { return score; }
    }
    //currentlevel
    public int Level
    {
        get { return level; }
    }

   
    public bool Update(GameTime gameTime)
    {
        //Shows block on screen
      /*  if (Collision && movetime == 0)
        {
           currentblock = nextblock ;
           nextblock = blockcalled;
        }  */

        
        for (int y = 0; y < 20; y++)
        {
            bool del = true;
            for (int x = 0; x < 12; x++)
            {
                if (colGrid[x, y] == Color.White)
                    del = false;
            }
            if (del)
            {
                ClearRow(y);
                score += 10;
            }
        }
     
       return false;
    }
  
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        //Draws the Grid on the screen in the correct colors
        for (int x = 0; x < colGrid.GetLength(0); x++)
            for (int y = 0; y < colGrid.GetLength(1); y++)
                s.Draw(gridblock, new Vector2(position.X + x * gridblock.Width, position.Y + y * gridblock.Height), colGrid[x,y]);
    }

    public void ClearRow(int row)
    {
        for (int i = row; i >= 1; i--)
            for (int j = 0; j < 12; j++)
                colGrid[j, i] = colGrid[j, i - 1];
        //all rows are shifted down once starting from the row above the one you want to clear.
        for (int x = 0; x < 12; x++)
            colGrid[x, 0] = Color.White;
        //the top row is always empty after being shifted so this clears the top row.
    }
}

