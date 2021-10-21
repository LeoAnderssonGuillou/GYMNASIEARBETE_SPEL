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

            List<SplinterRepeat> splinterRepeats = new List<SplinterRepeat>();
            List<CircleRepeat> circleRepeats = new List<CircleRepeat>();


            AttackLibrary attacks = new AttackLibrary() { bulletList = bullets };

            Vector2 start = new Vector2(650, 100);
            //attacks.BulletCircle(start, 200, 12, Color.WHITE, 11);
            //attacks.SplinterShot(start, 500, 0, 5, Color.WHITE, 15, 4);

            SplinterRepeat test = new SplinterRepeat(attacks.SplinterShot, 4, 0.2f, start, 500, 0, 10, Color.WHITE, 9, 6);
            splinterRepeats.Add(test);
            circleRepeats.Add(new CircleRepeat(attacks.BulletCircle, 4, 0.2f, start, 200, 12, 5, Color.WHITE, 11));


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);

                float delta = Raylib.GetFrameTime();






                SplinterRepeat.TickAllRepeats(splinterRepeats, delta);
                CircleRepeat.TickAllCircleRepeats(circleRepeats, delta);


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
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.GRAY);




                Raylib.EndDrawing();
            }
        }
    }
}
