using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


    class IBlock : TetrisBlock
    {
        
       public IBlock (Texture2D b): base(b)
        
       {
               shape = new Color[4, 4]
        
           {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.White, Color.White, Color.White},
            {Color.Red,   Color.Red,   Color.Red,   Color.Red},
            {Color.White, Color.White, Color.White, Color.White},
          };

        }
    }
    

