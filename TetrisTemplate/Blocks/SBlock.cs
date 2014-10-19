using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class SBlock : TetrisBlock
{

    public SBlock(Texture2D b) : base(b)
    {
        shape = new Color[4, 4]
        
           {
            {Color.White, Color.White, Color.White, Color.White},
            {Color.White, Color.Green, Color.Green, Color.White},
            {Color.Green,  Color.Green, Color.White,Color.White},
            {Color.White, Color.White, Color.White, Color.White},
          };
    }
}

