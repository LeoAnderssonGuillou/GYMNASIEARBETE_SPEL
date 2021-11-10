using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Enemy
    {
        public Vector2 pos = new Vector2();
        Vector2 originalPos = new Vector2();
        public Vector2 Speed = new Vector2();
        public Rectangle look;
        int movementIndex;
        float speedValue;
        float distanceTravelled;
        int maxDistance;

        float angle;
        float angleChange;
        float angleChanged;
        float maxAngleChange;


        public Enemy(int moveIndex, Vector2 startPos, float speed, int distance, float startAngle, float angleChange_, float totalAngleChange)
        {
            movementIndex = moveIndex;
            pos = startPos;
            originalPos = startPos;
            maxDistance = distance;
            speedValue = speed;
            angle = startAngle;
            angleChange = angleChange_;
            maxAngleChange = totalAngleChange;
        }


        public void Tick(float delta)
        {
            switch (movementIndex)
            {
                case 0:

                    break;
                case 1:
                    SimpleMovement(delta);
                    break;
            }

            look = new Rectangle(pos.X, pos.Y, 50, 50);
            Raylib.DrawRectangleRec(look, Color.YELLOW);
        }

        public void SimpleMovement(float delta)
        {
            Speed.X = MathF.Sin(angle * MathF.PI / 180) * speedValue * delta;
            Speed.Y = MathF.Cos(angle * MathF.PI / 180) * speedValue * delta;
            pos += Speed;
            distanceTravelled += Speed.Length();
            angle += angleChange * delta;
            angleChanged += angleChange * delta;

            if (distanceTravelled >= maxDistance)
            {
                Speed = new Vector2(0, 0);
                movementIndex = 0;
            }
            if (angleChanged >= maxAngleChange || angleChanged <= -maxAngleChange)
            {
                angleChange = 0;
            }
        }

        public void DamageEnemy()
        {
            
        }






        //Runs Tick for each enemy
        public static void TickAllEnemies(List<Enemy> enemies, float delta)
        {
            foreach (Enemy enemy in enemies)
            {
                enemy.Tick(delta);
            }
        }

    }
}