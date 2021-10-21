using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Ship
    {
        //Position
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

        //Speed and size
        public float SpeedValue { get; set; } = 500;
        public int width = 25;
        public int height = 32;
        //Vector2 currentSpeed;
        public Vector2 movement = new Vector2(0, 0);

        //HP
        float maxHp = 1000;
        float hp = 1000;
        Vector2 hBar = new Vector2(500, 25);
        Rectangle healhtBar;

        //Color and invincibility
        Color orginalColor = new Color(255, 0, 0, 255);
        Color fadedlColor = new Color(255, 0, 0, 75);
        Color color = new Color(255, 0, 0, 255);
        Clock invincibleTimer = new Clock();
        Clock blinkCooldown = new Clock();
        bool isVisable = true;

        //Hitbox and miscellaneous
        public Rectangle hitbox;
        Vector2 hitboxShift = new Vector2(0, 0);
        public Gun gun;

        //Calcualte location of hitbox and healthbar depending of window and ship size
        public Ship(Vector2 window, Gun gun_)
        {
            int boxWidht = 15;
            int boxHeight = 15;
            hitboxShift.X = (width - boxWidht) / 2;
            hitboxShift.Y = (height - boxHeight) / 2;
            hitbox = new Rectangle(pos.X + hitboxShift.X, pos.Y + hitboxShift.Y, boxWidht, boxHeight);

            healhtBar = new Rectangle(((int)window.X / 2) - ((int)hBar.X / 2), (int)(window.Y - hBar.Y * 2), (int)hBar.X, (int)hBar.Y);
            gun = gun_;
        }


        //Move ship based on input
        public void MoveShip(float deltaTime)
        {
            float speed = SpeedValue * deltaTime;
            movement.X = 0;
            movement.Y = 0;
            //Set movement vector to one of 8 states, determining direction
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

            //Normalize vector to ensure equal speed in all directions
            if (movement.X != 0 || movement.Y != 0)
            {
                movement = Vector2.Normalize(movement);
            }

            //Change ship location
            Pos = new Vector2(Pos.X + movement.X * speed, Pos.Y + movement.Y * speed);
            //Clamp location within window
            Pos = new Vector2(Math.Clamp(Pos.X, 0, 1300 - width), Math.Clamp(Pos.Y, 0, 900 - height));
            //Change hitbox location
            hitbox.x = Pos.X + hitboxShift.X;
            hitbox.y = Pos.Y + hitboxShift.Y;
        }

        //Draw ship
        public void DrawShip(float delta)
        {
            Blinking(delta);
            Raylib.DrawRectangle((int)Pos.X, (int)Pos.Y, width, height, color);
            //Raylib.DrawRectangle((int)hitbox.x, (int)hitbox.y, (int)hitbox.width, (int)hitbox.height, Color.YELLOW);
        }

        //Runs when ship collides with bullet
        public void DamageShip()
        {
            if (invincibleTimer.time <= 0)
            {
                invincibleTimer.time = 1;
                hp -= 50;
            }
        }

        //Handles invicibility, runs in DrawShip
        public void Blinking(float delta)
        {
            //When invicibleTimer is > 0 ship is invincible
            if (invincibleTimer.time > 0)
            {
                invincibleTimer.TickDown(delta);
                //Another timer handles the actual blinking
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
            //When invicibleTimer reaches 0, ship is no longer invincible
            if (invincibleTimer.time <= 0)
            {
                invincibleTimer.time = 0;
                color = orginalColor;
            }
        }

        //Draw health bar based on window size and HP
        public void DrawHealhtBar(Vector2 window)
        {
            Raylib.DrawRectangleRec(healhtBar, Color.RED);
            float greenWidth = (hp / maxHp) * healhtBar.width;
            Raylib.DrawRectangle((int)healhtBar.x, (int)healhtBar.y, (int)greenWidth, (int)healhtBar.height, Color.GREEN);
        }

    }
}