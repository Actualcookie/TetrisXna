using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Media;
using Microsoft.Xna.Framework.Input;
using System;

/*
 * A class for representing the game world.
 */
class GameWorld
{
     /*
     * enum for different game states (playing or game over)
     */
   protected enum GameState
    {
      StartScreen, Playing, GameOver
    }
  public Song introsong, playingsong;
    /*
     * screen width and height
     */
    int screenWidth, screenHeight;

    /*
     * random number generator
     */
    static Random random;

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
        introsong = Content.Load<Song>("IntroSong");
        playingsong = Content.Load<Song>("TetrisPlaying");
        MediaPlayer.Play(introsong);
        MediaPlayer.IsRepeating = true;
        screenWidth = width;
        screenHeight = height;
        random = new Random();
        gameState = GameState.StartScreen;
        introscreen = Content.Load<Texture2D>("spr_BackGround"); 
        block = Content.Load<Texture2D>("block");
        font = Content.Load<SpriteFont>("SpelFont");
        grid = new TetrisGrid(block);
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

          grid.currentblock.HandleInput(gameTime, inputHelper);
        if (gameState == GameState.Playing && inputHelper.KeyPressed(Keys.Space))
           
            gameState = GameState.StartScreen;

          grid.currentblock.HandleInput(gameTime, inputHelper);

          
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
        grid.Update(gameTime);
    }

    public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        spriteBatch.Begin();
        if (gameState == GameState.StartScreen)
        {
            spriteBatch.Draw(introscreen, Vector2.Zero, Color.White);
            spriteBatch.Draw(button, butPos, Color.Red);
        }

        else if (gameState == GameState.Playing)
        {
            grid.Draw(gameTime, spriteBatch);

            grid.currentblock.Draw(gameTime, spriteBatch);
            spriteBatch.DrawString(font, "Score:" + grid.Score, new Vector2(screenWidth + block.Width, screenHeight) / 2, Color.Black);
            spriteBatch.DrawString(font, "Level:" + grid.Level, new Vector2(screenWidth + block.Width, screenHeight+block.Width) / 2, Color.Black);
        }
        else if (gameState == GameState.GameOver)
            spriteBatch.DrawString(font, "Game Over: /n Press <space> to try again", new Vector2(screenWidth, screenHeight) / 2,Color.Black);
        spriteBatch.End();    
    }

    /*
     * utility method for drawing text on the screen
     */
    public void DrawText(string text, Vector2 positie, SpriteBatch spriteBatch)
    {
        spriteBatch.DrawString(font, text, positie, Color.Blue);
    }

    public static Random Random
    {
        get { return random; }
    }

    public TetrisGrid Grid
    {
        get { return grid; }
    }
}
