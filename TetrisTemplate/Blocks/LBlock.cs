using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

class LBlock : TetrisBlock
  {
      

      public LBlock(Texture2D b): base(b)
      {
           shape = new Color[4, 4]{
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.White, Color.Blue,  Color.White},
            {Color.Blue,  Color.Blue,   Color.Blue, Color.White},
            {Color.White, Color.White, Color.White, Color.White},
          };
           shape2 = new Color[4, 4]{
            {Color.White, Color.Blue, Color.White, Color.White},
            {Color.White, Color.Blue, Color.White,  Color.White},
            {Color.White,  Color.Blue,   Color.Blue, Color.White},
            {Color.White, Color.White, Color.White, Color.White},
          };
      }
}
