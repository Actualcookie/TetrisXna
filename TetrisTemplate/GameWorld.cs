using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Input;
using System;

/*
 * A class for representing the game world.
 */
class GameWorld
{
    TetrisBlock tetrisBlock;
     /*
     * enum for different game states (playing or game over)
     */
    enum GameState
    {
      StartScreen, Playing, GameOver
    }

    /*
     * screen width and height
     */
    int screenWidth, screenHeight;

    /*
     * random number generator
     */
    Random random;

    //position of button on screen
  protected  Vector2 butPos;
    /*
     * main game font
     */
    SpriteFont font;

    bool pressed; 

    /*
     * sprite for representing a single tetris block element
     */
    Texture2D block, introscreen;
    public Texture2D button;
    /*
     * the current game state
     */
    GameState gameState;

    /*
     * the main playing grid
     */
    TetrisGrid grid;

    public GameWorld(int width, int height, ContentManager Content)
    {
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.StartScreen;
        introscreen = Content.Load<Texture2D>("spr_BackGround"); 
        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
        tetrisBlock = new TBlock(block);
        button = Content.Load<Texture2D>("spr_Button");
        butPos = new Vector2(screenWidth-button.Width,screenHeight-button.Height );
    }

    public void Reset()
    {
       
    }

    public void HandleInput(GameTime gameTime, InputHelper inputHelper)
    {
        //chances the gamestates to other gamestate
        if (gameState==GameState.StartScreen)
          {
             int x=(int) 280;
             int y=(int) 80;
             Rectangle button = new Rectangle((int)butPos.X, (int)butPos.Y, x , y );
             pressed = inputHelper.MouseLeftButtonPressed() &&
               button.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y);
       }

        if (gameState == GameState.StartScreen && inputHelper.KeyPressed(Keys.Space) ||pressed)
            gameState = GameState.Playing;
        if(gameState==GameState.Playing)
          tetrisBlock.HandleInput(gameTime, inputHelper);
        if (gameState == GameState.GameOver && inputHelper.KeyPressed(Keys.Space))
        {
            gameState = GameState.StartScreen;
        }
    }
       
    
    public bool Pressed
    {
        get { return pressed; }
    }


    public void Update(GameTime gameTime)
    {
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState== GameState.StartScreen)
        {
            spriteBatch.Draw(introscreen, Vector2.Zero, Color.White);
            spriteBatch.Draw(button, butPos,Color.Red);
        }

        else if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);
            tetrisBlock.Draw(gameTime, spriteBatch);
        }
        spriteBatch.End();    
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }

    public Random Random
    {
        get { return random; }
    }

    public TetrisGrid Grid
    {
        get { return grid; }
    }
}
