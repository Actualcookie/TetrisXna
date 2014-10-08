using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class TetrisBlock: GameWorld
    {
      
        const int size = 4;
        bool[,] conf;
       
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
       bool[,] nieuw = new bool[size, size];
    for (int i = 0; i <size; ++i)
        for (int j = 0; j < size; ++j)
            nieuw[size - j - 1, i] = conf[i, j];
    this.conf = nieuw;
    }
       public void BlockShape()
    {
           //maak een lijst van de bloks en welke dingen daarin worden in gekleurd
    }
  

        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
       { }
        public virtual void Update(GameTime gameTime)
         { }
    }
}
