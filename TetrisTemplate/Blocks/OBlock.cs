﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class OBlock : TetrisBlock
{

    public OBlock(Texture2D b)
        : base(b)
    {
        shape = new Color[4, 4]
        
           {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.Goldenrod,Color.Goldenrod, Color.White},
            {Color.White, Color.Goldenrod,Color.Goldenrod,Color.White},
            {Color.White, Color.White, Color.White, Color.White},
          };

        shape2 = shape;

    }
}

