using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Game
    {
        Vector2 winSize;
        public int gameState = 1;
        public int gameplayState = 1;
        public float timer = 0;
        public delegate void SatSpawn(); 


        public List<Bullet> bullets = new List<Bullet>();
        public List<Shot> shots = new List<Shot>();
        public List<Repeat> repeats = new List<Repeat>();
        public List<Enemy> enemies = new List<Enemy>();
        public AttackLibrary attacks;
        public AttackInfo testInfo = AttackInfo.Default();
        public Vector2 start = new Vector2(960, 0);

        public Game(Vector2 windowSize)
        {
            winSize = windowSize;
            attacks = new AttackLibrary() { bulletList = bullets };
        }

        public void CenteredText(string text, int fullWidth, int fontSize, int yPos, int xStart)
        {
            Raylib.DrawText(text, xStart + (fullWidth - Raylib.MeasureText(text, fontSize)) / 2, yPos, fontSize, Color.WHITE);
        }

        public void MenuScreen()
        {
            CenteredText("SPACE SHOOTER", (int)winSize.X, 100, 140, 0);
            CenteredText("PRESS ENTER", (int)winSize.X, 60, 600, 0);
            CenteredText("[PRESS 1-5 FOR TESTING MODES]", (int)winSize.X, 28, 700, 0);
        }

        public int MenuInput()
        {
            int state = 1;
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ONE))
            {
                Raylib.SetTargetFPS(30);
                state = 2;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_TWO))
            {
                Raylib.SetTargetFPS(60);
                state = 2;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_THREE))
            {
                Raylib.SetTargetFPS(100);
                state = 2;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_FOUR))
            {
                Raylib.SetTargetFPS(144);
                state = 2;
            }
            if (Raylib.IsKeyDown(KeyboardKey.KEY_FIVE))
            {
                Raylib.SetTargetFPS(60);
                state = 2;
            }
            if (Raylib.IsKeyReleased(KeyboardKey.KEY_ENTER))
            {
                state = 2;
            }
            return state;
        }

        public void Tick(float delta)
        {
            timer += delta;
        }

        public void TutorialScreen1()
        {
            CenteredText("SHOOT WITH WSAD", (int)winSize.X / 2, 60, 200, 0);
            CenteredText("MOVE WITH ARROWKEYS", (int)winSize.X / 2, 60, 200, (int)winSize.X / 2);
            CenteredText("[PRESS ENTER]", (int)winSize.X, 30, 1100, 0);
            if (Raylib.IsKeyReleased(KeyboardKey.KEY_ENTER))
            {
                gameplayState = 2;
                repeats.Add(new Repeat(attacks.SingleBullet, 25, 0.5f, testInfo, new Enemy(1, start, 100, 250, 0, 0, 10000, 1), enemies));
            }
        }

        public void TutorialScreen2(Ship ship)
        {
            CenteredText("AVOID BULLETS", (int)winSize.X / 2, 60, 200, 0);
            CenteredText("SHOOT SATELLITES", (int)winSize.X / 2, 60, 200, (int)winSize.X / 2);
            if (bullets.Count < 1)
            {
                gameplayState = 3;
                ship.hp = ship.maxHp;
                timer = 0;
            }
        }

        public void SatRight()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.5f, AttackInfo.Default(), new Enemy(1, new Vector2(-200, 100), 200, 10000, 90, 0, 10000, 100), enemies));
        }

        public void SatDown()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.5f, AttackInfo.Left(), new Enemy(1, new Vector2((int)winSize.X - 100, -200), 200, 10000, 0, 0, 10000, 100), enemies));
        }

        public void SatLeft()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.5f, AttackInfo.Up(), new Enemy(1, new Vector2((int)winSize.X + 200, (int)winSize.Y - 100), 200, 10000, -90, 0, 10000, 100), enemies));
        }

        public void SatUp()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.5f, AttackInfo.Right(), new Enemy(1, new Vector2(100, (int)winSize.Y + 200), 200, 10000, -180, 0, 10000, 100), enemies));
        }

        public void RightTopSplint()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 1000, 1f, AttackInfo.RightTopSplint(), new Enemy(1, new Vector2((int)winSize.X + 100, -100), 200, 250, -45, 0, 10000, 100), enemies));
        }

        public void LeftTopSplint()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 1000, 1f, AttackInfo.LeftTopSplint(), new Enemy(1, new Vector2(-100, -100), 200, 250, 45, 0, 10000, 100), enemies));
        }

        public void SpinTop()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.15f, AttackInfo.SpinTop(), new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 200, 400, 0, 0, 10000, 100), enemies));
        }


        public void GameStart()
        {
            CenteredText("START", (int)winSize.X, 150, 300, 0);
            if (timer > 1)
            {
                gameplayState = 9;
                timer -= 1;
                SatRight();
            }
        }

        public void Wave(int time, SatSpawn sat)
        {
            if (timer > time)
            {
                gameplayState++;
                timer -= time;
                sat();
            }
        }







        
    }
}