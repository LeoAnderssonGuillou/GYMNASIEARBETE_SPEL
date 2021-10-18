using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Shot
    {
        Vector2 pos = new Vector2(0, 0);
        Vector2 speed = new Vector2(0, 0);
        float trueSpeed;
        float angle;
        int radius = 5;
        Color color = Color.GREEN;

        public Shot(Vector2 pos_, float speed_, float angle_)
        {
            pos = pos_;
            trueSpeed = speed_;
            angle = angle_;
        }

        public static void DrawShots(List<Shot> shots)
        {
            foreach (Shot shot in shots)
            {
                Raylib.DrawCircle((int)shot.pos.X, (int)shot.pos.Y, shot.radius, shot.color);
            }
        }

        public static void MoveShots(List<Shot> shots, float delta)
        {
            foreach (Shot shot in shots)
            {
                shot.speed.X = MathF.Sin(shot.angle * MathF.PI / 180) * shot.trueSpeed * delta;
                shot.speed.Y = MathF.Cos(shot.angle * MathF.PI / 180) * shot.trueSpeed * delta;
                shot.pos = shot.pos + shot.speed;

            }
        }
    }
}