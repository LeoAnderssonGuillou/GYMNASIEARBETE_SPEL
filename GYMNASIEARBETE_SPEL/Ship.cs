using System;
using System.Numerics;
using System.Collections.Generic;
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

        float speedValue = 500;
        int width = 25;
        int height = 35;
        Vector2 movement = new Vector2(0, 0);


        public void MoveShip(float deltaTime)
        {
            float speed = speedValue * deltaTime;
            movement.X = 0;
            movement.Y = 0;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
            {
                movement.X--;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
            {
                movement.X++;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
            {
                movement.Y--;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
            {
                movement.Y++;
            }

            if (movement.X != 0 || movement.Y != 0)
            {
                movement = Vector2.Normalize(movement);
            }

            Pos = new Vector2(Pos.X + movement.X * speed, Pos.Y + movement.Y * speed);
            Pos = new Vector2(Math.Clamp(Pos.X, 0, 1300 - width), Math.Clamp(Pos.Y, 0, 900 - height));
        }

        public void DrawShip()
        {
            Raylib.DrawRectangle((int)Pos.X, (int)Pos.Y, width, height, Color.RED);
        }
    }
}