using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

class TetrisBlock
    {
      
        protected const int size = 4;
        protected Color[,] conf;
        protected Texture2D block;
        protected Vector2 position;

        public TetrisBlock(Texture2D b)
        {
            block = b;
        }
        public bool Collision()
        {
            return (true);   
         /*moet zorgen voor de stilstand van het block
             * dus misschien iets als 
             * 
             * (if(Collision(true)) 
             * velocity = 0.0f;)
              */     }
        public void Rotation()
        {
       Color[,] nieuw = new Color[size, size];
        for (int i = 0; i <size; ++i)
            for (int j = 0; j < size; ++j)
            nieuw[size - j - 1, i] = conf[i, j];
        this.conf = nieuw;
    }
       public void BlockShape()
    {
           //maak een lijst van de bloks en welke dingen daarin worden in gekleurd
    }
  

    public virtual void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        for (int i = 0; i < 4; i++)
            for(int j = 0; j < 4; j++)
                if (conf[i, j] != Color.White)
                {
                    spriteBatch.Draw(block, new Vector2(position.X + i * block.Width, position.Y + j * block.Height), conf[i, j]);
                }
    }
        public virtual void Update(GameTime gameTime)
         { }
    }
