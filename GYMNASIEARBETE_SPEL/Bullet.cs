using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Bullet
    {
        Vector2 pos = new Vector2(0, 0);
        Vector2 speed = new Vector2(0, 0);
        float trueSpeed;
        float angle;
        float angleChange;
        int radius;
        Color color;

        public Bullet(Vector2 pos_, float speed_, float angle_, float angleChange_, int radius_, Color color_)
        {
            pos = pos_;
            trueSpeed = speed_;
            angle = angle_;
            angleChange = angleChange_;
            radius = radius_;
            color = color_;
        }

        public static void DrawBullets(List<Bullet> bullets)
        {
            foreach (Bullet bullet in bullets)
            {
                Raylib.DrawCircle((int)bullet.pos.X, (int)bullet.pos.Y, bullet.radius, bullet.color);
            }
        }

        public static void MoveBullets(List<Bullet> bullets, float delta)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.speed.X = MathF.Sin(bullet.angle * MathF.PI / 180) * bullet.trueSpeed * delta;
                bullet.speed.Y = MathF.Cos(bullet.angle * MathF.PI / 180) * bullet.trueSpeed * delta;
                bullet.pos = bullet.pos + bullet.speed;
                bullet.angle += bullet.angleChange * delta;
            }
        }

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