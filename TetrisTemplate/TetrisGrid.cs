using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;

/*
 * a class for representing the Tetris playing grid
 */
class TetrisGrid
{
   public Color[,] colGrid = new Color[14, 22];
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
    public TetrisBlock currentblock, nextblock;

    public TetrisGrid(Texture2D b)
    {
        //draws the grid
        
        gridblock = b;
        position = Vector2.Zero;
        for (int x = 1; x < 13; x++)
            for (int y = 0; y < 20; y++)
                colGrid[x, y] = Color.White;
       //initialzation for the blocks at the start of the game
        currentblock = RandomBlock();
        nextblock = RandomBlock();
        

    }


    public void ReturntoGrid()
    {
        //writes the shape grid to the main grid
        if (currentblock.Collision())
        {
            for (int x = 0; x < 4; x++)
                for (int y = 0; y < 4; y++)
                   if (currentblock.Shape[x, y] != Color.White)
                    {
                        colGrid[((int)currentblock.Position.X + x * gridblock.Width) / gridblock.Width, ((int)currentblock.Position.Y + (y * +gridblock.Height)) / gridblock.Height] = currentblock.Shape[x,y];
                    }
          }
        }


    // Method checks if top row of the Grid contains a Tetromino
    public bool TopRow()
    {
        for (int g = 1; g < 13; g++)
            if (colGrid[g, 0] != Color.White)
            {
                return true;
            }
        return false;
    }  
 
    

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

   
    public void Update(GameTime gameTime)
    {
        //Shows block on screen
       if (currentblock.Speed == 0)
        {
           currentblock = nextblock ;
           nextblock = RandomBlock();
        } 

        currentblock.Update(gameTime);
        ReturntoGrid();
       //This instruction checks all row to see if they contain a block with Color White if they do the row is cleared and the other rows shifted down one
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
                level = score / 30;
            }
        }
        TopRow();
    }
  
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        
        //Draws the Grid on the screen in the correct colors
        for (int x = 0; x < colGrid.GetLength(0); x++)
            for (int y = 0; y < colGrid.GetLength(1); y++)
                s.Draw(gridblock, new Vector2(position.X + x * gridblock.Width, position.Y + y * gridblock.Height), colGrid[x,y]);
        //draws the block that comes after the currentblock on the side of the screen
        for (int x = 0; x < nextblock.Shape.GetLength(0); x++)
            for (int y = 0; y < nextblock.Shape.GetLength(1); y++)
                s.Draw(gridblock, new Vector2(position.X + (x + 14) * gridblock.Width, position.Y + (y + 1) * gridblock.Height), nextblock.Shape[x, y]);

        currentblock.Draw(gameTime, s);
    }

    public void ClearRow(int row)
    {
        for (int i = row; i >= 1; i--)
            for (int j = 1; j < 13; j++)
                colGrid[j, i] = colGrid[j, i - 1];
        //all rows are shifted down once starting from the row above the one you want to clear.
        for (int x = 1; x < 13; x++)
            colGrid[x, 0] = Color.White;
        //the top row is always empty after being shifted so this clears the top row.
    }

    public TetrisBlock RandomBlock()
    {
        //decides wat the next block is going to be an returns that as a b value
        int num = GameWorld.Random.Next(7);
        TetrisBlock b;
        switch (num){
            case 0: 
                b = new IBlock(gridblock);
                return b;
            case 1: 
                b = new JBlock(gridblock);
                return b;
            case 2: 
                b = new LBlock(gridblock);
                return b;
            case 3: 
                b = new OBlock(gridblock);
                return b;
            case 4: 
                b = new SBlock(gridblock);
                return b;
            case 5: 
                b = new TBlock(gridblock);
                return b;
            case 6: 
                b = new ZBlock(gridblock);
                return b;
            default:
                return null;
        }
        
    }
}

