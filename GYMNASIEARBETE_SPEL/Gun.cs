using System.Threading;
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
        int gunLength = 20;
        int shotSpeed = 600;


        public void Aim()
        {
            shouldShoot = false;
            aim.X = 0;
            aim.Y = 0;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                aim.X--;
                //shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                aim.X++;
                //shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                aim.Y--;
                //shouldShoot = true;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                aim.Y++;
                //shouldShoot = true;
            }

            if (aim.X != 0 || aim.Y != 0)
            {
                aim = Vector2.Normalize(aim);
                shouldShoot = true;
            }
        }

        public void Shoot(List<Shot> shots, Ship ship, float delta)
        {
            if (shouldShoot && shootCool.time <= 0)
            {
                Vector2 startPos = new Vector2(0, 0);
                startPos.X = ship.Pos.X + ship.width / 2 + aim.X * gunLength;
                startPos.Y = ship.Pos.Y + ship.height / 2 + aim.Y * gunLength;
                shots.Add(new Shot(startPos, shotSpeed, aim));
                shootCool.time = 0.1f;
            }
            shootCool.TickDown(delta);
        }
    }
}