using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

/*
 * a class for representing the Tetris playing grid
 */
class TetrisGrid
{
    Color[,] colGrid = new Color[12, 20];
    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        this.Clear();
        for (int x = 0; x < 12; x++)
            for (int y = 0; y < 20; y++)
                colGrid[x, y] = Color.White;  
                              
    }

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

    /*
     * clears the grid
     */
    public void Clear()
    {
    }

    /*
     * draws the grid on the screen
     */

    public void Update(GameTime gameTime)
    {
        for(int y = 0; y < 20; y++)
        {
            bool del = true;
            for(int x = 0; x < 12; x++)
            {
                if (colGrid[x, y] == Color.White)
                    del = false;
            }
            if (del)
                ClearRow(y);
        }
    }
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int x = 0; x < 12; x++)
            for (int y = 0; y < 20; y++)
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

