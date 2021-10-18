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

        float maxHp = 1000;
        float hp = 1000;
        Vector2 hBar = new Vector2(500, 25);
        Rectangle healhtBar;

        Color orginalColor = new Color(255, 0, 0, 255);
        Color fadedlColor = new Color(255, 0, 0, 75);
        Color color = new Color(255, 0, 0, 255);
        Clock invincibleTimer = new Clock();
        Clock blinkCooldown = new Clock();
        bool isVisable = true;


        public Rectangle hitbox;
        Vector2 hitboxShift = new Vector2(0, 0);
        Vector2 movement = new Vector2(0, 0);

        public Ship(Vector2 window)
        {
            int boxWidht = 15;
            int boxHeight = 15;
            hitboxShift.X = (width - boxWidht) / 2;
            hitboxShift.Y = (height - boxHeight) / 2;
            hitbox = new Rectangle(pos.X + hitboxShift.X, pos.Y + hitboxShift.Y, boxWidht, boxHeight);

            healhtBar = new Rectangle(((int)window.X / 2) - ((int)hBar.X / 2), (int)(window.Y - hBar.Y * 2), (int)hBar.X, (int)hBar.Y);
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
            //Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, Color.YELLOW);
        }

        public void DamageShip()
        {
            if (invincibleTimer.time <= 0)
            {
                invincibleTimer.time = 1;
                hp -= 50;
            }
        }

        public void Blinking(float delta)
        {
            if (invincibleTimer.time > 0)
            {
                invincibleTimer.TickDown(delta);
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
            if (invincibleTimer.time < 0)
            {
                invincibleTimer.time = 0;
                color = orginalColor;
            }
        }

        public void DrawHealhtBar(Vector2 window)
        {
            Raylib.DrawRectangleRec(healhtBar, Color.RED);
            float greenWidth = (hp / maxHp) * healhtBar.width;
            Raylib.DrawRectangle((int)healhtBar.x, (int)healhtBar.y, (int)greenWidth, (int)healhtBar.height, Color.GREEN);
        }

    }
}