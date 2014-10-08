using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework.Graphics;
using System.Text;
using Microsoft.Xna.Framework;

namespace Tetris
{
    class IBlock : TetrisBlock
    {
        Color red;
        Texture2D blokSprite;
        const int size = 4;
        bool[,] conf;

        public void Iblock()
        {
            this.red = Color.Red;
            this.conf = new bool[size, size];
            for (int i = 0; i < size; ++i)
                for (int j = 0; j < size; ++j)
                    this.conf[i, j] = false;
            conf[0, 1] = true; conf[1, 1] = true;
            conf[2, 1] = true; conf[3, 1] = true;
        }
    }
}
