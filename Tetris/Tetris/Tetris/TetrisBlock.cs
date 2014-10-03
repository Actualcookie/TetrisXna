using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace Tetris
{
    class TetrisBlock 
    {
       

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
        // 
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
