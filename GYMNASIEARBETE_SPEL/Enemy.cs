using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Enemy
    {
        Vector2 pos = new Vector2();
        Vector2 originalPos = new Vector2();
        Vector2 speed = new Vector2();
        Rectangle look;
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
            speed.X = MathF.Sin(angle * MathF.PI / 180) * speedValue * delta;
            speed.Y = MathF.Cos(angle * MathF.PI / 180) * speedValue * delta;
            pos += speed;
            distanceTravelled += speed.Length();
            angle += angleChange * delta;
            angleChanged += angleChange * delta;

            if (distanceTravelled >= maxDistance)
            {
                movementIndex = 0;
            }
            if (angleChanged >= maxAngleChange || angleChanged <= -maxAngleChange)
            {
                angleChange = 0;
            }
        }

    }
}