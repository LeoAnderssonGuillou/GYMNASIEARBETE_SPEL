using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Shot
    {
        //Movement vector represents both direction and speed
        Vector2 movement;
        Vector2 pos = new Vector2(0, 0);
        int radius = 8;
        Color color = Color.GREEN;
        Texture2D texture;

        public Shot(Vector2 pos_, Vector2 movement_, Texture2D texture_)
        {
            pos = pos_;
            movement = movement_;
            texture = texture_;
        }

        //Draw all shots
        public static void DrawShots(List<Shot> shots)
        {
            foreach (Shot shot in shots)
            {
                //Raylib.DrawCircle((int)shot.pos.X, (int)shot.pos.Y, shot.radius, shot.color);
                //Draw shot texture
                double angle = Math.Atan2(shot.movement.Y, shot.movement.X);
                angle = (angle * 180 / Math.PI) + 90;
                Raylib.DrawTexturePro(
                    shot.texture,
                    new Rectangle(0, 0, 16, 28),
                    new Rectangle(shot.pos.X, shot.pos.Y, 16, 28),
                    new Vector2(8, 28),
                    (float)angle,
                    Color.WHITE
                    );
                
            }
        }

        //Move all shots
        public static void MoveShots(List<Shot> shots, float delta)
        {
            foreach (Shot shot in shots)
            {
                shot.pos.X += shot.movement.X * delta;
                shot.pos.Y += shot.movement.Y * delta;
            }
        }

        public static void CheckCollisionWithEnemy(List<Shot> shots, List<Enemy> enemies)
        {
            for (int x = shots.Count - 1; x >= 0; x--)
            {
                Shot shot = shots[x];
                foreach (Enemy enemy in enemies)
                {
                    if (Raylib.CheckCollisionCircleRec(shot.pos, shot.radius, enemy.look))
                    {
                        enemy.DamageEnemy();
                        shots.RemoveAt(x);
                    }
                }
            }
        }

        //Delete off-screen shots
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