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
            Vector2 winSize = new Vector2(1400, 950);
            Raylib.InitWindow((int)winSize.X, (int)winSize.Y, "Gymnasiearbete");
            Raylib.SetTargetFPS(60);

            Ship ship = new Ship(winSize, new Gun());
            List<Bullet> bullets = new List<Bullet>();
            List<Shot> shots = new List<Shot>();
            List<Repeat> repeats = new List<Repeat>();

            AttackLibrary attacks = new AttackLibrary() { bulletList = bullets };
            Vector2 start = new Vector2(650, 100);

            //Test attacks
            //attacks.BulletCircle(start, 200, 12, Color.WHITE, 11);
            //attacks.SplinterShot(start, 500, 0, 5, Color.WHITE, 15, 4);

            //Test spiral repeat attack
            AttackInfo testInfo = AttackInfo.Default();
            AttackInfo testInfo2 = AttackInfo.Default();
            testInfo2.Color = Color.RED;
            testInfo2.Angle += 180;
            //repeats.Add(new Repeat(attacks.SingleBullet, 20, 0.005f, testInfo));
            //repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.04f, testInfo));
            //repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.005f, testInfo2));
            repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.05f, testInfo2));
            repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.05f, testInfo));




            //Enemy testEnemy = new Enemy(0, start, 250, 45, 5, 400);


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                float delta = Raylib.GetFrameTime();


                //testEnemy.Tick(delta);

                Repeat.TickAllRepeats(repeats, delta);

                Bullet.DrawBullets(bullets);
                Bullet.MoveBullets(bullets, delta);

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
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.GRAY);



                Raylib.EndDrawing();
            }
        }
    }
}
