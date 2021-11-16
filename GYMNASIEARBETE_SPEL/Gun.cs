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
        int gunLength = 32;
        int shotSpeed = 1800;


        public void Aim()
        {
            shouldShoot = false;
            aim.X = 0;
            aim.Y = 0;
            //WSAD input for shooting
            //Aim can end up in 8 different states, resulting in shooting in 8 respective directions
            if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
            {
                aim.X--;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
            {
                aim.X++;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
            {
                aim.Y--;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
            {
                aim.Y++;
            }

            //Only shoots when aim isn't (0,0)
            //Aim is (0,0) when WSAD isn't touched or if for example both A and D are pressed
            if (aim.X != 0 || aim.Y != 0)
            {
                aim = Vector2.Normalize(aim);
                shouldShoot = true;
            }
        }

        public void Shoot(List<Shot> shots, Ship ship, float delta, Texture2D texture)
        {
            if (shouldShoot && shootCool.time <= 0)
            {
                //Determine starting position of shot
                Vector2 startPos = new Vector2(0, 0);
                startPos.X = ship.Pos.X + ship.width / 2 + aim.X * gunLength;
                startPos.Y = ship.Pos.Y + ship.height / 2 + aim.Y * gunLength;

                //Create new shot
                shots.Add(new Shot(startPos, aim * shotSpeed, texture));
                //Alternative shot speed: affected by ship speed
                //shots.Add(new Shot(startPos, aim * shotSpeed + ship.movement * ship.SpeedValue));
                shootCool.time = 0.1f;
            }
            shootCool.TickDown(delta);
        }
    }
}