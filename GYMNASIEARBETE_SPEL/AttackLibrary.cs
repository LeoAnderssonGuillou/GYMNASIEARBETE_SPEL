using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class AttackLibrary
    {
        public List<Bullet> bulletList;

        //Fires a single bullet
        public void SingleBullet(Vector2 startPos, float speed, float angle, int radius, Color color)
        {
            bulletList.Add(new Bullet(startPos, speed, angle, radius, color));

        }

        //Creates a circle of bullets moving away from the starting position in all directions
        public void BulletCircle(Vector2 startPos, float speed, int radius, Color color, int amount)
        {
            for (int i = 0; i < amount; i++)
            {
                bulletList.Add(new Bullet(startPos, speed, i * 360 / amount, radius, color));
            }
        }

        //Fires a shotgun-like shot of bullets. Amount must be an odd number
        public void SplinterShot(Vector2 startPos, float speed, float angle, int radius, Color color, int amount, int spacing)
        {
            bulletList.Add(new Bullet(startPos, speed, angle, radius, color));
            for (int i = 1; i < ((amount - 1) / 2) + 1; i++)
            {
                bulletList.Add(new Bullet(startPos, speed, angle + i * spacing, radius, color));
            }
            for (int i = 1; i < ((amount - 1) / 2) + 1; i++)
            {
                bulletList.Add(new Bullet(startPos, speed, angle - i * spacing, radius, color));
            }
        }

    }
}