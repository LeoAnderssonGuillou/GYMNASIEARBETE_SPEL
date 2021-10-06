using System.Collections.ObjectModel;
using System;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(1300, 900, "Slutprojekt");
            Raylib.SetTargetFPS(60);

            float circleX = 300;
            int circleSpeed = 720;
            Ship ship = new Ship();

            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.WHITE);

                float delta = Raylib.GetFrameTime();

                int fps = Raylib.GetFPS();
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.BLACK);

                Raylib.DrawCircle((int)circleX, 500, 25, Color.BLACK);
                circleX += circleSpeed * delta;
                if (circleX > 1100 || circleX < 200)
                {
                    circleSpeed = -circleSpeed;
                }

                ship.MoveShip();
                ship.DrawShip();



                Raylib.EndDrawing();
            }
        }
    }
}
