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
        Texture2D tex;

        //Testing
        float timeSurvived;
        float waveTime;
        public int enemiesDestroyed;


        public List<Bullet> bullets = new List<Bullet>();
        public List<Shot> shots = new List<Shot>();
        public List<Repeat> repeats = new List<Repeat>();
        public List<Enemy> enemies = new List<Enemy>();
        public AttackLibrary attacks;
        public AttackInfo testInfo;
        public Vector2 start = new Vector2(960, 0);

        public Game(Vector2 windowSize, Texture2D texture)
        {
            winSize = windowSize;
            attacks = new AttackLibrary() { bulletList = bullets };
            tex = texture;
            testInfo = AttackInfo.Default();
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

        public void GameOverScreen()
        {
            CenteredText("GAME OVER", (int)winSize.X, 100, 140, 0);
            CenteredText($"BULLETS SPAWNED: {attacks.bulletsSpawned}", (int)winSize.X, 60, 600, 0);
            CenteredText($"TIME SURVIVED: {timeSurvived}", (int)winSize.X, 60, 700, 0);
        }

        public void Tick(float delta, Ship ship)
        {
            timer += delta;
            waveTime += delta;

            if (ship.hp <= 0)
            {
                gameState = 3;
                timeSurvived += waveTime;
            }
            Console.WriteLine(timeSurvived);
        }

        public void TutorialScreen1(Ship ship)
        {
            CenteredText("SHOOT WITH WSAD", (int)winSize.X / 2, 60, 200, 0);
            CenteredText("MOVE WITH ARROWKEYS", (int)winSize.X / 2, 60, 200, (int)winSize.X / 2);
            CenteredText("[PRESS ENTER]", (int)winSize.X, 30, 1100, 0);
            ship.hp = ship.maxHp;
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
            ship.hp = ship.maxHp;
            if (bullets.Count < 1)
            {
                gameplayState = 3;
                ship.hp = ship.maxHp;
                timer = 0;
            }
        }

        public void GameStart()
        {
            CenteredText("START", (int)winSize.X, 150, 300, 0);
            if (timer > 1)
            {
                gameplayState++;
                timer -= 1;
                attacks.bulletsSpawned = 0;
                SatRight();
            }
        }

        public void Wave(float time, SatSpawn sat)
        {
            if (timer > time)
            {
                gameplayState++;
                timer -= time;
                sat();

                timeSurvived+= time;
                waveTime = 0;
            }
        }

        public void FinalWave(float time, SatSpawn sat)
        {
            if (timer > time)
            {
                gameplayState--;
                timer -= time;
                sat();
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
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.15f, AttackInfo.SpinTop(), new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 200, 400, 0, 0, 10000, 500), enemies));
        }

        public void DiagonalSplintRight()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 2.6f, 1.4f, AttackInfo.DiagonalSplintRight(), new Enemy(1, new Vector2(1300, -300), 500, 10000, 45, -20, 10000, 100), enemies));
        }

        public void DiagonalSplintLeft()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 2.6f, 1.4f, AttackInfo.DiagonalSplintLeft(), new Enemy(1, new Vector2(620, -300), 500, 10000, -45, 20, 10000, 100), enemies));
        }

        public void SpinDouble()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 9.5f, 0.1f, AttackInfo.SpinFromLeft(), new Enemy(1, new Vector2(-100, 500), 400, 1000, 90, 0, 10000, 500), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 9.5f, 0.1f, AttackInfo.SpinFromRight(), new Enemy(1, new Vector2(2020, 500), 400, 1000, -90, 0, 10000, 500), enemies));
        }

        public void AllSides()
        {
            SatDown();
            SatUp();
            SatRight();
            SatLeft();
        }

        public void SpinTopSuper()
        {
            Enemy twinGun = new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 250, 400, 0, 0, 10000, 500);
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.030f, AttackInfo.SpinTopSuper(true), twinGun, enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.030f, AttackInfo.SpinTopSuper(false), twinGun, enemies));
        }

        public void SpeedBoi()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.28f, AttackInfo.SpeedBoi(), new Enemy(1, new Vector2(-200, 100), 1000, 10000, 90, 0, 10000, 100), enemies));
        }

        public void SpeedBoi2()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.28f, AttackInfo.SpeedBoi2(), new Enemy(1, new Vector2(2120, 1100), 1000, 10000, -90, 0, 10000, 100), enemies));
        }

        public void SpinBothSides()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.12f, AttackInfo.SpinBothSides(), new Enemy(1, new Vector2(400, -100), 250, 10000, 0, 0, 10000, 500), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.12f, AttackInfo.SpinBothSides(), new Enemy(1, new Vector2((int)winSize.X - 400, -100), 250, 10000, 0, 0, 10000, 500), enemies));
        }

        public void DiagonalSplintLefts()   //??
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 2.6f, 1.4f, AttackInfo.DiagonalSplintLeft(), new Enemy(1, new Vector2(620, -300), 500, 10000, -45, 20, 10000, 100), enemies));
        }

        public void SpinAcrossSuper()
        {
            Enemy twinGun = new Enemy(1, new Vector2(-150, 300), 500, 2600, 90, 0, 10000, 500);
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.035f, AttackInfo.SpinAcrossSuper(true), twinGun, enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.035f, AttackInfo.SpinAcrossSuper(false), twinGun, enemies));
        }

        public void Arc()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.3f, AttackInfo.Arc(), new Enemy(1, new Vector2(-200, 1300), 550, 10000, 160, -15, 10000, 100), enemies));
        }

        public void Arc2()
        {
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.3f, AttackInfo.Arc2(), new Enemy(1, new Vector2(2120, 1300), 550, 10000, 200, 15, 10000, 100), enemies));
        }

        public void TightSplintTop()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 1000, 0.5f, AttackInfo.TightSplintTop(), new Enemy(1, new Vector2(960, -100), 200, 150, 0, 0, 10000, 300), enemies));
        }

        public void SpinTopSplint()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 1000, 0.04f, AttackInfo.SpinTopSplint(), new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 200, 600, 0, 0, 10000, 500), enemies));
        }

        public void SpinWall()
        {
            Enemy twinGun = new Enemy(2, new Vector2((int)winSize.X  / 2, -100), 350, 640, 0, 0, 10000, 500);
            repeats.Add(new Repeat(attacks.SingleBullet, 14, 0.035f, AttackInfo.SpinWall(true), twinGun, enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 14, 0.035f, AttackInfo.SpinWall(false), twinGun, enemies));
        }

        public void Hexa()
        {
            repeats.Add(new Repeat(attacks.SplinterShot, 2.6f, 1.4f, AttackInfo.DiagonalSplintRight(), new Enemy(1, new Vector2(1300, -300), 500, 10000, 45, -20, 10000, 100), enemies));
            repeats.Add(new Repeat(attacks.SplinterShot, 2.6f, 1.4f, AttackInfo.DiagonalSplintLeft(), new Enemy(1, new Vector2(620, -300), 500, 10000, -45, 20, 10000, 100), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.3f, AttackInfo.Arc(), new Enemy(1, new Vector2(-200, 1300), 550, 10000, 160, -15, 10000, 100), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.3f, AttackInfo.Arc2(), new Enemy(1, new Vector2(2120, 1300), 550, 10000, 200, 15, 10000, 100), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.28f, AttackInfo.SpeedBoi(), new Enemy(1, new Vector2(-200, 100), 1000, 10000, 90, 0, 10000, 100), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.28f, AttackInfo.SpeedBoi2(), new Enemy(1, new Vector2(2120, 1100), 1000, 10000, -90, 0, 10000, 100), enemies));

        }

        public void ByeBye()
        {
            Enemy twinGun = new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 250, 400, 0, 0, 10000, 500);
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.030f, AttackInfo.SpinTopSuper(true), twinGun, enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.030f, AttackInfo.SpinTopSuper(false), twinGun, enemies));
            repeats.Add(new Repeat(attacks.SplinterShot, 1000, 0.5f, AttackInfo.TightSplintTop(), new Enemy(1, new Vector2(960, -100), 200, 150, 0, 0, 10000, 300), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.12f, AttackInfo.SpinBothSides(), new Enemy(1, new Vector2(400, -100), 250, 10000, 0, 0, 10000, 500), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.12f, AttackInfo.SpinBothSides(), new Enemy(1, new Vector2((int)winSize.X - 400, -100), 250, 10000, 0, 0, 10000, 500), enemies));
            repeats.Add(new Repeat(attacks.SingleBullet, 1000, 0.15f, AttackInfo.SpinTop(), new Enemy(1, new Vector2((int)winSize.X  / 2, -100), 200, 400, 0, 0, 10000, 500), enemies));

        }

    }
}