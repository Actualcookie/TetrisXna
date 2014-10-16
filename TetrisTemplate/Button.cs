using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;


class Button
{
    bool pressed; 

    public override void HandleInput(InputHelper inputHelper)
    {
        Rectangle rect = new Rectangle((int)GlobalPosition.X, (int)GlobalPosition.Y, sprite.Width, sprite.Height);
        pressed = inputHelper.MouseLeftButtonPressed() &&
            rect.Contains((int)inputHelper.MousePosition.X, (int)inputHelper.MousePosition.Y);
    }

    public bool Pressed
    {
        get { return pressed; }
    }
}

