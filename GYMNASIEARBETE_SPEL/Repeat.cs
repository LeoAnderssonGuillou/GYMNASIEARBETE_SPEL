using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Repeat
    {
        float time = 0;
        float cooldown = 0;
        float interval;
        public bool IsActive { get; set; } = false;
        public delegate void Spawn(AttackInfo info);
        Spawn action;

        AttackInfo info;

        public Repeat(Spawn action_, float seconds, float interval_, AttackInfo info_)
        {
            action = action_;
            time = seconds;
            interval = interval_;
            info = info_;
            IsActive = true;
        }

        //Runs every frame
        public void Tick(float delta)
        {
            info.Delta = delta;
            if (time > 0)
            {
                //Do the following after each interval
                if (cooldown <= 0)
                {
                    //Includes system for when the interval is smaller than delta time
                    //Each interval cooldown has the interval value added and delta time subrtracted
                    //If one or more interval values fit into the negative value of cooldown after delta time has been subtracted, repeat action that amount of times
                    //Bullets also spawn as if they had already moved a bit using info.BF
                    float overflow = cooldown / -interval;
                    for (int i = (int)overflow; i >= 0; i--)
                    {
                        info.BF.X = (int)overflow + 1;
                        info.BF.Y = i;
                        info.Angle += info.AngleChange;
                        action(info);
                        cooldown += interval;
                    }
                    info.BF = new Vector2(0, 0);
                }
                cooldown -= delta;
            }
            else
            {
                IsActive = false;
            }
            time -= delta;
        }

        //Runs Tick for each Repeat
        public static void TickAllRepeats(List<Repeat> repeats, float delta)
        {
            foreach (Repeat repeat in repeats)
            {
                repeat.Tick(delta);
            }

            //Removes inactive repeats from the list
            for (int x = repeats.Count - 1; x >= 0; x--)
            {
                Repeat repeat = repeats[x];
                if (!repeat.IsActive)
                {
                    repeats.RemoveAt(x);
                }
            }
        }

    }
}