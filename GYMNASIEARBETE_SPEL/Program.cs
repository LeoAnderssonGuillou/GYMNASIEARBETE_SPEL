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
            Raylib.InitWindow(1300, 900, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            Ship ship = new Ship();
            List<Bullet> bullets = new List<Bullet>();
            bullets.Add(new Bullet(new Vector2(0, 0), new Vector2(300, 300), 20));
            bullets.Add(new Bullet(new Vector2(0, 0), new Vector2(300, 150), 20));
            bullets.Add(new Bullet(new Vector2(0, 0), new Vector2(300, 450), 20));


            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                float delta = Raylib.GetFrameTime();

                int fps = Raylib.GetFPS();
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.BLACK);


                ship.MoveShip(delta);
                ship.DrawShip();

                Bullet.MoveBullets(bullets, delta);
                Bullet.DrawBullets(bullets);




                Raylib.EndDrawing();
            }
        }
    }
}
