using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Bullet
    {
        //Position of bullet
        Vector2 pos = new Vector2(0, 0);
        //Movement of bullet
        Vector2 speed = new Vector2(0, 0);
        //Absolute velocity of bullet
        float speedValue;
        //Direction of movement (0: down, 90: right, 180: up, 270: left)
        float angle;
        int radius;
        Color color;
        Vector2 parentSpeed = new Vector2(0, 0);

        public Bullet(Vector2 pos_, float speed_, float angle_, int radius_, Color color_, Vector2 bf, float delta, float angleChange, Vector2 parentSpeed_)
        {
            pos = pos_;
            speedValue = speed_;
            angle = angle_;
            radius = radius_;
            color = color_;
            parentSpeed = parentSpeed_;

            //BF = "between frames"
            //Divide delta by the amount of extra bullets that should spawn + 1 (BF.X)
            //Multiply this value by the extra bullets index (BF.Y)
            //Example: One extra bullet should spawn => BF.X = 2, BF.Y = 1
            //Example: The oldest of two extra bullets should spawn => BF.X = 3, BF.Y = 2
            if (bf.Y > 0)
            {
                //Also "rewind" angle
                angle -= (angleChange / bf.X) * bf.Y;
                MoveBullet((delta / bf.X) * bf.Y);
                angle += (angleChange / bf.X) * bf.Y;
                Console.WriteLine("ACTIVATED");
            }
        }

        //Move bullet using angle and speedValue
        public void MoveBullet(float delta)
        {
            speed.X = MathF.Sin(angle * MathF.PI / 180) * speedValue * delta;
            speed.Y = MathF.Cos(angle * MathF.PI / 180) * speedValue * delta;
            //pos = pos + speed + (parentSpeed * 0.9f);
            pos = pos + speed + parentSpeed;
        }

        //Draws all bullets
        public static void DrawBullets(List<Bullet> bullets, Texture2D texture)
        {
            foreach (Bullet bullet in bullets)
            {
                //Raylib.DrawCircle((int)bullet.pos.X, (int)bullet.pos.Y, bullet.radius, bullet.color);
                Raylib.DrawTexture(texture, (int)bullet.pos.X - 12, (int)bullet.pos.Y, Color.WHITE);
            }
        }

        //Moves all bullets
        public static void MoveBullets(List<Bullet> bullets, float delta)
        {
            foreach (Bullet bullet in bullets)
            {

                bullet.MoveBullet(delta);
            }
        }

        //Check collision with ship for all bullets
        //If collision is detected, remove bullet and try to damage ship
        public static void CheckCollisionWithShip(List<Bullet> bullets, Ship ship)
        {
            for (int x = bullets.Count - 1; x >= 0; x--)
            {
                Bullet bullet = bullets[x];
                if (Raylib.CheckCollisionCircleRec(bullet.pos, bullet.radius, ship.hitbox))
                {
                    ship.DamageShip();
                    bullets.RemoveAt(x);

                }
            }
        }

        //If any bullet is off-screen, remove it
        public static void DeleteOffScreenBullets(List<Bullet> bullets, Vector2 window)
        {
            for (int x = bullets.Count - 1; x >= 0; x--)
            {
                Bullet bullet = bullets[x];
                if (bullet.pos.X > window.X + 100 || bullet.pos.X < -100 || bullet.pos.Y > window.Y + 100 || bullet.pos.Y < -100)
                {
                    bullets.RemoveAt(x);
                }
            }
        }
    }
}