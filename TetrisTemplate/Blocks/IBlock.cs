using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


    class IBlock : TetrisBlock
    {
        public void Iblockshape ()
        {
            shape = new Color [,]
                {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.White, Color.White, Color.White},
            {Color.Red,   Color.Red,   Color.Red,   Color.Red},
            {Color.White, Color.White, Color.White, Color.White},
          };
        }
    }

