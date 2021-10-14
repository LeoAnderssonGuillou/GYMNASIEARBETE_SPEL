using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Ship
    {
        Vector2 pos = new Vector2(650, 600);
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
        int height = 32;

        Color orginalColor = new Color(255, 0, 0, 255);
        Color fadedlColor = new Color(255, 0, 0, 0);
        Color color = new Color(255, 0, 0, 255);
        Clock isBlinking = new Clock();
        Clock blinkCooldown = new Clock();
        bool isVisable = true;


        public Rectangle hitbox;
        Vector2 hitboxShift = new Vector2(0, 0);
        Vector2 movement = new Vector2(0, 0);

        public Ship()
        {
            int boxWidht = 15;
            int boxHeight = 15;
            hitboxShift.X = (width - boxWidht) / 2;
            hitboxShift.Y = (height - boxHeight) / 2;
            hitbox = new Rectangle(pos.X + hitboxShift.X, pos.Y + hitboxShift.Y, boxWidht, boxHeight);
        }


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
            hitbox.x = Pos.X + hitboxShift.X;
            hitbox.y = Pos.Y + hitboxShift.Y;
        }

        public void DrawShip(float delta)
        {
            Blinking(delta);
            Raylib.DrawRectangle((int)Pos.X, (int)Pos.Y, width, height, color);
            Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, Color.YELLOW);
        }

        public void DamageShip()
        {
            isBlinking.time = 1;
        }

        public void Blinking(float delta)
        {
            if (isBlinking.time > 0)
            {
                isBlinking.TickDown(delta);
                if (blinkCooldown.time <= 0)
                {
                    isVisable = !isVisable;
                    if (isVisable)
                    {
                        color = orginalColor;
                    }
                    else
                    {
                        color = fadedlColor;
                    }
                    blinkCooldown.time = 0.1f;
                }
                blinkCooldown.TickDown(delta);
            }
            if (isBlinking.time < 0)
            {
                isBlinking.time = 0;
                color = orginalColor;
            }
        }

    }
}