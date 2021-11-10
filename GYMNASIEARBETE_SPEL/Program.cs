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
            Console.WriteLine("test");
            Vector2 winSize = new Vector2(1920, 1200);
            Raylib.InitWindow((int)winSize.X, (int)winSize.Y, "Gymnasiearbete");
            Raylib.SetTargetFPS(60);

            Texture2D shipTex = Raylib.LoadTexture("shiptest.png");

            Ship ship = new Ship(winSize, new Gun(), shipTex);
            List<Bullet> bullets = new List<Bullet>();
            List<Shot> shots = new List<Shot>();
            List<Repeat> repeats = new List<Repeat>();
            List<Enemy> enemies = new List<Enemy>();

            AttackLibrary attacks = new AttackLibrary() { bulletList = bullets };
            Vector2 start = new Vector2(800, 0);

            //Test attacks
            //attacks.BulletCircle(start, 200, 12, Color.WHITE, 11);
            //attacks.SplinterShot(start, 500, 0, 5, Color.WHITE, 15, 4);

            //Test spiral repeat attack
            AttackInfo testInfo = AttackInfo.Default();
            AttackInfo testInfo2 = AttackInfo.Default();
            testInfo2.Color = Color.RED;
            testInfo2.Angle += 180;
            //repeats.Add(new Repeat(attacks.SingleBullet, 20, 0.01f, testInfo));
            //repeats.Add(new Repeat(attacks.SplinterShot, 80, 0.03f, testInfo));
            //repeats.Add(new Repeat(attacks.SingleBullet, 80, 0.005f, testInfo2));
            //repeats.Add(new Repeat(attacks.SplinterShot, 40, 0.03f, testInfo2));
            //repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.05f, testInfo));




            //enemies.Add(new Enemy(1, start, 500, 10000, 90, -100, 10000));
            repeats.Add(new Repeat(attacks.SingleBullet, 25, 0.1f, testInfo, new Enemy(1, start, 600, 500, 90, -50, 10000, 100), enemies));



            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                float delta = Raylib.GetFrameTime();


                Shot.MoveShots(shots, delta);
                Shot.DrawShots(shots);
                Shot.CheckCollisionWithEnemy(shots, enemies);
                Shot.DeleteOffScreenShots(shots, winSize);

                Enemy.TickAllEnemies(enemies, delta);
                Repeat.TickAllRepeats(repeats, delta);

                Bullet.DrawBullets(bullets);
                Bullet.MoveBullets(bullets, delta);

                Bullet.CheckCollisionWithShip(bullets, ship);
                Bullet.DeleteOffScreenBullets(bullets, winSize);

                ship.MoveShip(delta, winSize);
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
