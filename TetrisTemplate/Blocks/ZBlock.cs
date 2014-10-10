using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    class ZBlock : TetrisBlock
    {
        public ZBlock (Texture2D b): base(b)
        
       {
               shape = new Color[4, 4]
        
           {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.Yellow, Color.Yellow, Color.White, Color.White},
            {Color.White,   Color.Yellow,   Color.Yellow,   Color.White},
            {Color.White, Color.White, Color.White, Color.White},
          };

        }
    }
