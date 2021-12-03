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
        public bool IsMain { get; set; } = true;
        

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

        public static AttackInfo SpinTopSuper(bool main)
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 800,
                Angle = 0,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 21,
                Delay = 1.75f,
            };
            if (main == false)
            {
                info.IsMain = false;
                info.Angle += 180;
            }
            return info;
        }

        public static AttackInfo SpeedBoi()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 750,
                Angle = -10,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 11,
                Delay = 0.25f,
            };
            return info;
        }

        public static AttackInfo SpeedBoi2()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 800,
                Angle = -190,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 11,
                Delay = 0.25f,
            };
            return info;
        }

        public static AttackInfo SpinBothSides()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 700,
                Angle = 0,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 21,
                Delay = 0f,
            };
            return info;
        }

        public static AttackInfo SpinAcrossSuper(bool main)
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 800,
                Angle = 0,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 21,
                Delay = 0,
            };
            if (main == false)
            {
                info.IsMain = false;
                info.Angle += 180;
            }
            return info;
        }

        public static AttackInfo Arc()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 1100,
                Angle = 75,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = -10,
                Delay = 0f,
            };
            return info;
        }

        public static AttackInfo Arc2()
        {
            AttackInfo info = new AttackInfo()
            {
                Speed = 1100,
                Angle = 285,
                Radius = 14,
                Color = Color.WHITE,
                AngleChange = 10,
                Delay = 0f,
            };
            return info;
        }

    }
}