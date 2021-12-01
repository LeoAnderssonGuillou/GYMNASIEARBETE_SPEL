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
        public float Delay { get; set; } = 0;
        


        public static AttackInfo Default()
        {
            AttackInfo info = new AttackInfo()
            {
                StartPos = new Vector2(700, 150),
                Speed = 500,
                Angle = 0,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 9,
                Spacing = 12,
                AngleChange = 0,
            };
            return info;
        }

        public static AttackInfo Left()
        {
            AttackInfo info = new AttackInfo()
            {
                StartPos = new Vector2(700, 150),
                Speed = 500,
                Angle = -90,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 9,
                Spacing = 12,
                AngleChange = 0,
            };
            return info;
        }

        public static AttackInfo Up()
        {
            AttackInfo info = new AttackInfo()
            {
                StartPos = new Vector2(700, 150),
                Speed = 500,
                Angle = -180,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 9,
                Spacing = 12,
                AngleChange = 0,
            };
            return info;
        }

        public static AttackInfo Right()
        {
            AttackInfo info = new AttackInfo()
            {
                StartPos = new Vector2(700, 150),
                Speed = 500,
                Angle = 90,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 9,
                Spacing = 12,
                AngleChange = 0,
            };
            return info;
        }

        public static AttackInfo RightTopSplint()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 600,
                Angle = -45,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 5,
                Spacing = 16,
                Delay = 2f,
            };
            return info;
        }

        public static AttackInfo LeftTopSplint()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 600,
                Angle = 45,
                Radius = 14,
                Color = Color.WHITE,
                Amount = 5,
                Spacing = 16,
                Delay = 2f,
            };
            return info;
        }

        public static AttackInfo SpinTop()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 500,
                Angle = 0,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 20,
                Delay = 2.5f,
            };
            return info;
        }

        public static AttackInfo DiagonalSplintRight()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 800,
                Angle = -60,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = -25,
                Amount = 5,
                Spacing = 16,
            };
            return info;
        }

        public static AttackInfo DiagonalSplintLeft()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 800,
                Angle = 60,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 25,
                Amount = 5,
                Spacing = 16,
            };
            return info;
        }

        public static AttackInfo SpinFromLeft()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 500,
                Angle = -90,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 6,
                Delay = 3f,
            };
            return info;
        }
        public static AttackInfo SpinFromRight()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 500,
                Angle = 90,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 6,
                Delay = 3f,
            };
            return info;
        }

    }
}