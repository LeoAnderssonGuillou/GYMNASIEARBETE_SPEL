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
            Raylib.InitWindow((int)winSize.X, (int)winSize.Y, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            Ship ship = new Ship();
            List<Bullet> bullets = new List<Bullet>();

            float time = 0;
            int cycles = 0;

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                float delta = Raylib.GetFrameTime();

                int fps = Raylib.GetFPS();
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.BLACK);

                time += delta;

                if (time > 0.1)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        bullets.Add(new Bullet(new Vector2(650, 200), 550, 72 * i + cycles * delta * 1000, 0, 10, Color.BLACK));
                    }
                    cycles++;
                    time = 0;
                }

                // if (time > 0.25)
                // {
                //     for (int i = 0; i < 25; i++)
                //     {
                //         bullets.Add(new Bullet(new Vector2(650, 450), 350, 37 * i + cycles * delta * 37, 59, 15, Color.BLACK));
                //         cycles++;
                //         time = 0;
                //     }
                // }

                ship.MoveShip(delta);
                ship.DrawShip();

                Bullet.MoveBullets(bullets, delta);
                Bullet.DrawBullets(bullets);
                Bullet.DeleteOffScreenBullets(bullets, winSize);




                Raylib.EndDrawing();
            }
        }
    }
}
