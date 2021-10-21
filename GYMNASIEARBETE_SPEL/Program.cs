using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    class Program
    {
        static void Main(string[] args)
        {
            Vector2 winSize = new Vector2(1300, 900);
            Raylib.InitWindow((int)winSize.X, (int)winSize.Y, "Gymnasiearbete");
            Raylib.SetTargetFPS(60);

            Ship ship = new Ship(winSize, new Gun());
            List<Bullet> bullets = new List<Bullet>();
            List<Shot> shots = new List<Shot>();
            AttackLibrary attacks = new AttackLibrary() { bulletList = bullets };

            Vector2 start = new Vector2(650, 100);
            //attacks.BulletCircle(start, 200, 12, Color.WHITE, 11);
            //attacks.SplinterShot(start, 500, 0, 5, Color.WHITE, 15, 4);

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                float delta = Raylib.GetFrameTime();







                Bullet.MoveBullets(bullets, delta);
                Bullet.DrawBullets(bullets);
                Bullet.CheckCollisionWithShip(bullets, ship);
                Bullet.DeleteOffScreenBullets(bullets, winSize);

                Shot.MoveShots(shots, delta);
                Shot.DrawShots(shots);
                Shot.DeleteOffScreenShots(shots, winSize);

                ship.MoveShip(delta);
                ship.DrawShip(delta);
                ship.DrawHealhtBar(winSize);

                ship.gun.Aim();
                ship.gun.Shoot(shots, ship, delta);


                int fps = Raylib.GetFPS();
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.BLACK);




                Raylib.EndDrawing();
            }
        }
    }
}
