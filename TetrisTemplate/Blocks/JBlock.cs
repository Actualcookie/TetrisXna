using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

    class JBlock : TetrisBlock
    {
       
       public JBlock(Texture2D b): base(b)
        {
     
           shape = new Color[4, 4]{
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.White, Color.White,  Color.White},
            {Color.Purple,  Color.Purple,   Color.Purple, Color.White},
            {Color.White, Color.White, Color.Purple, Color.White},
          };
      }
    }

