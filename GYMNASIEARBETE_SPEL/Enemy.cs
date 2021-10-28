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
        Vector2 distanceTravelled = new Vector2();
        Vector2 speed = new Vector2();
        Rectangle look;
        int movementIndex;
        float speedValue;
        float angle;
        float angleChange;
        int maxDistance;

        public Enemy(int moveIndex, Vector2 startPos, float speed, float direction, float direcChange, int distance)
        {
            movementIndex = moveIndex;
            pos = startPos;
            originalPos = startPos;
            speedValue = speed;
            angle = direction;
            angleChange = direcChange;
            maxDistance = distance;
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
            distanceTravelled += speed;

            if (distanceTravelled.Length() >= maxDistance)
            {
                movementIndex = 0;
            }
        }

    }
}