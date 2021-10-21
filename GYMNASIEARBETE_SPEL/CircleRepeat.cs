using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class CircleRepeat
    {
        float time = 0;
        float cooldown = 0;
        float interval;
        public bool IsActive { get; set; } = false;
        public delegate void Spawn(Vector2 startPos, float speed, float angle, int radius, Color color, int amount);
        Spawn action;

        Vector2 startPos;
        float speed;
        float angle;
        int radius;
        Color color;
        int amount;

        public CircleRepeat(Spawn action_, float seconds, float interval_, Vector2 startPos_, float speed_, float angle_, int radius_, Color color_, int amount_)
        {
            action = action_;
            time = seconds;
            interval = interval_;
            IsActive = true;

            startPos = startPos_;
            speed = speed_;
            angle = angle_;
            radius = radius_;
            color = color_;
            amount = amount_;
        }

        public void Tick(float delta)
        {
            if (time > 0)
            {
                if (cooldown <= 0)
                {
                    action(startPos, speed, angle, radius, color, amount);
                    cooldown = interval;
                }
                cooldown -= delta;
            }
            else
            {
                IsActive = false;
            }
            time -= delta;
        }

        public static void TickAllCircleRepeats(List<CircleRepeat> repeats, float delta)
        {
            foreach (CircleRepeat repeat in repeats)
            {
                repeat.Tick(delta);
            }

            for (int x = repeats.Count - 1; x >= 0; x--)
            {

                if (!repeats[x].IsActive)
                {
                    repeats.RemoveAt(x);
                }
            }
        }

    }
}