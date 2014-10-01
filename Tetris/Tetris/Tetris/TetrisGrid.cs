using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

/*
 * a class for representing the Tetris playing grid
 */
class TetrisGrid
{
    public TetrisGrid(Texture2D b)
    {
        gridblock = b;
        position = Vector2.Zero;
        this.Clear();
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
    public void Draw(GameTime gameTime, SpriteBatch s)
    {
        for (int x = 0; x < 12; x++)
            for (int y = 0; y < 20; y++)
                s.Draw(gridblock, new Vector2(position.X + x * gridblock.Width, position.Y + y * gridblock.Height), Color.White);
    }
}

