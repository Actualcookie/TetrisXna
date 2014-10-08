using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework;


 class IBlock : TetrisBlock
    {
        public IBlock() : base(Texture2D b)
        {
            conf = new Color[4, 4] { { Color.White, Color.White, Color.White, Color.White }, 
                                     { Color.White, Color.White, Color.White, Color.White }, 
                                     { Color.Red, Color.Red, Color.Red, Color.Red }, 
                                     { Color.White, Color.White, Color.White, Color.White } };
        }
    }

