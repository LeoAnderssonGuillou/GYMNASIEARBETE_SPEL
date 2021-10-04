using System;
using System.Numerics;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Ship
    {
        Vector2 pos = new Vector2(0, 0);
        public Vector2 Pos
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        public int Speed { get; set; }

        public void MoveShip()
        {
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {

            }
        }

        public void DrawShip()
        {
            Raylib.DrawRectangle((int)Pos.X, (int)Pos.Y, 15, 25, Color.RED);
        }
    }
}