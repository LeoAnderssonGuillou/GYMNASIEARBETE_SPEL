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
        Vector2 movement;
        float trueSpeed;
        int radius = 8;
        Color color = Color.GREEN;

        public Shot(Vector2 pos_, float speed_, Vector2 movement_)
        {
            pos = pos_;
            trueSpeed = speed_;
            movement = movement_;
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
                shot.pos.X += shot.movement.X * shot.trueSpeed * delta;
                shot.pos.Y += shot.movement.Y * shot.trueSpeed * delta;
            }
        }

        public static void DeleteOffScreenShots(List<Shot> shots, Vector2 window)
        {
            for (int x = shots.Count - 1; x >= 0; x--)
            {
                Shot shot = shots[x];
                if (shot.pos.X > window.X + 100 || shot.pos.X < -100 || shot.pos.Y > window.Y + 100 || shot.pos.Y < -100)
                {
                    shots.RemoveAt(x);
                }
            }
        }
    }
}