using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using System.Linq;
using System.Text;

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
        //roteren van het figuur binnen de array. Moet dus ook links en Rechts om.
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
