using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Gun
    {
        Vector2 aim;
        bool shouldShoot;
        Clock shootCool = new Clock();


        public void Aim()
        {
            shouldShoot = false;
            aim.X = 0;
            aim.Y = 0;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                aim.X--;
                shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                aim.X++;
                shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                aim.Y--;
                shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                aim.Y++;
                shouldShoot = true;
            }

            if (aim.X != 0 || aim.Y != 0)
            {
                aim = Vector2.Normalize(aim);
            }
        }

        public void Shoot(List<Shot> shots, Ship ship, float delta)
        {
            if (shouldShoot && shootCool.time <= 0)
            {
                shots.Add(new Shot(ship.Pos, 600, aim));
                shootCool.time = 0.1f;
            }
            shootCool.TickDown(delta);
        }
    }
}