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
        int radius;

        public Bullet(Vector2 pos_, Vector2 speed_, int radius_)
        {
            pos = pos_;
            speed = speed_;
            radius = radius_;
        }

        public static void DrawBullets(List<Bullet> bullets)
        {
            foreach (Bullet bullet in bullets)
            {
                Raylib.DrawCircle((int)bullet.pos.X, (int)bullet.pos.Y, bullet.radius, Color.BLACK);
            }
        }

        public static void MoveBullets(List<Bullet> bullets, float delta)
        {
            foreach (Bullet bullet in bullets)
            {
                bullet.pos.X += bullet.speed.X * delta;
                bullet.pos.Y += bullet.speed.Y * delta;
            }
        }
    }
}