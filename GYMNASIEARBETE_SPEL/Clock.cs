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


// float time = 0;
// int cycles = 0;

// time += delta;

// if (time > 0.1)
// {
//     for (int i = 0; i < 5; i++)
//     {
//         bullets.Add(new Bullet(new Vector2(650, 200), 550, 72 * i + (cycles * delta * 1000), 10, Color.WHITE));
//     }
//     cycles++;
//     time = 0;
// }

// if (time > 0.25)
// {
//     for (int i = 0; i < 25; i++)
//     {
//         bullets.Add(new Bullet(new Vector2(650, 450), 350, 37 * i + cycles * delta * 37, 59, 15, Color.BLACK));
//         cycles++;
//         time = 0;
//     }
// }