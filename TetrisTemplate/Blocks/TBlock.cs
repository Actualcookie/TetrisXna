using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;


class TBlock : TetrisBlock
{

    public TBlock(Texture2D b)
        : base(b)
    {
        shape = new Color[4, 4]
        
           {
            {Color.White,   Color.White,   Color.White,   Color.White},
            {Color.White,   Color.Chocolate,Color.White,   Color.White},
            {Color.Chocolate,Color.Chocolate,Color.Chocolate,Color.White},
            {Color.White,   Color.White,   Color.White,   Color.White},
          };
        shape2 = new Color[4, 4]
        
           {
            {Color.White,   Color.Chocolate,   Color.White,   Color.White},
            {Color.White,   Color.Chocolate,   Color.Chocolate,   Color.White},
            {Color.White,   Color.Chocolate,   Color.White ,  Color.White},
            {Color.White,   Color.White,       Color.White,   Color.White},
          };

    }
}
