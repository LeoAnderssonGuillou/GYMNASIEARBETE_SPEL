using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class AttackInfo
    {
        public Vector2 StartPos { get; set; }
        public float Speed { get; set; }
        public float Angle { get; set; }
        public int Radius { get; set; }
        public Color Color { get; set; }
        public int Amount { get; set; }     //Must be odd number
        public int Spacing { get; set; }
        public float AngleChange { get; set; }
        public Vector2 BF = new Vector2(0, 0);
        public float Delta { get; set; } = 0;
        public Vector2 ParentSpeed { get; set; }
        


        public static AttackInfo Default()
        {
            AttackInfo info = new AttackInfo()
            {
                StartPos = new Vector2(700, 150),
                Speed = 800,
                Angle = -90,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 9,
                Spacing = 12,
                AngleChange = 0,
            };

            return info;
        }

    }
}