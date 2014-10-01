using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class TetrisGame : Game
{
    GraphicsDeviceManager graphics;
    SpriteBatch spriteBatch;
    InputHelper inputHelper;
    GameWorld gameWorld;
    Matrix spriteScale;
    protected static Point screen;

    static void Main(string[] args)
    {
        TetrisGame game = new TetrisGame();
        game.Run();
    }

    public TetrisGame()
    {        
        // initialize the graphics device
        graphics = new GraphicsDeviceManager(this);
        
        // set the directory where game assets are located
        this.Content.RootDirectory = "Content";
        
        // set the desired window size in a point
        screen = new Point(800, 600);
        /*
        graphics.PreferredBackBufferWidth = 800;
        graphics.PreferredBackBufferHeight = 600;
        */

        // create the input helper object
        inputHelper = new InputHelper();

        graphics.IsFullScreen = false;
    }

    public void SetFullScreen(bool fullscreen = true)
    {
        float scalex = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Width / (float)screen.X;
        float scaley = GraphicsAdapter.DefaultAdapter.CurrentDisplayMode.Height / (float)screen.Y;
        float finalscale = 1;

        if (!fullscreen)
        {
            if (scalex < 1f || scaley < 1f)
                finalscale = Math.Min(scalex, scaley);
        }
        else
        {
            finalscale = scalex;
            if (Math.Abs(1 - scaley) < Math.Abs(1 - scalex))
                finalscale = scaley;
        }
        graphics.PreferredBackBufferWidth = (int)(finalscale * screen.X);
        graphics.PreferredBackBufferHeight = (int)(finalscale * screen.Y);

        //Set the scale for mouse position
        inputHelper.Scale = new Vector2((float)GraphicsDevice.Viewport.Width / screen.X, (float)GraphicsDevice.Viewport.Height / screen.Y);

        //Set scale matrix for sprites
        spriteScale = Matrix.CreateScale(inputHelper.Scale.X, inputHelper.Scale.Y, 1);

        graphics.IsFullScreen = fullscreen;
        graphics.ApplyChanges();
    }

    protected override void LoadContent()
    {
        spriteBatch = new SpriteBatch(GraphicsDevice);

        // create and reset the game world
        gameWorld = new GameWorld(GraphicsDevice.Viewport.Width, GraphicsDevice.Viewport.Height, Content);
        gameWorld.Reset();
    }

    protected override void Update(GameTime gameTime)
    {
        inputHelper.Update(gameTime);
        
        //Set full screen button and exit button
        if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.Escape))
            this.Exit();
        if (inputHelper.KeyPressed(Microsoft.Xna.Framework.Input.Keys.F5))
            SetFullScreen(!graphics.IsFullScreen);

        gameWorld.HandleInput(gameTime, inputHelper);
        gameWorld.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.White);
        gameWorld.Draw(gameTime, spriteBatch, spriteScale);
    }
}

