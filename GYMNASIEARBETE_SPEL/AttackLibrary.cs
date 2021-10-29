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
        public void SingleBullet(AttackInfo info)
        {
            bulletList.Add(new Bullet(info.StartPos, info.Speed, info.Angle, info.Radius, info.Color, info.BF, info.Delta));

        }

        //Creates a circle of bullets moving away from the starting position in all directions
        public void BulletCircle(AttackInfo info)
        {
            for (int i = 0; i < info.Amount; i++)
            {
                bulletList.Add(new Bullet(info.StartPos, info.Speed, info.Angle + i * 360 / info.Amount, info.Radius, info.Color, info.BF, info.Delta));
            }
        }

        //Fires a shotgun-like shot of bullets. Amount must be an odd number
        public void SplinterShot(AttackInfo info)
        {
            bulletList.Add(new Bullet(info.StartPos, info.Speed, info.Angle, info.Radius, info.Color, info.BF, info.Delta));
            for (int i = 1; i < ((info.Amount - 1) / 2) + 1; i++)
            {
                bulletList.Add(new Bullet(info.StartPos, info.Speed, info.Angle + i * info.Spacing, info.Radius, info.Color, info.BF, info.Delta));
            }
            for (int i = 1; i < ((info.Amount - 1) / 2) + 1; i++)
            {
                bulletList.Add(new Bullet(info.StartPos, info.Speed, info.Angle - i * info.Spacing, info.Radius, info.Color, info.BF, info.Delta));
            }
        }

    }
}