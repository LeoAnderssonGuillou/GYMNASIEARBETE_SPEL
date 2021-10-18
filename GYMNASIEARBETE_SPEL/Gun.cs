using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Gun
    {
        Vector2 aim;
        bool willShoot;


        public void Aim()
        {
            willShoot = false;
            aim.X = 0;
            aim.Y = 0;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                aim.X--;
                willShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                aim.X++;
                willShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                aim.Y--;
                willShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                aim.Y++;
                willShoot = true;
            }

            if (aim.X != 0 || aim.Y != 0)
            {
                aim = Vector2.Normalize(aim);
            }
        }

        public void Shoot()
        {
            if (willShoot)
            {

            }
        }
    }
}