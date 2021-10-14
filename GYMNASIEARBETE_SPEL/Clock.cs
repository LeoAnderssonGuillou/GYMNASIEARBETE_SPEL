using System;

namespace GYMNASIEARBETE_SPEL
{
    public class Clock
    {
        public float time = 0;

        public void TickUp(float delta)
        {
            time += delta;
        }

        public void TickDown(float delta)
        {
            time -= delta;
        }
    }
}