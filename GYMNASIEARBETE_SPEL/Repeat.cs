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
            if (time > 0)
            {
                //Do the following after each interval
                if (cooldown <= 0)
                {
                    info.Angle += info.AngleChange;
                    action(info);
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