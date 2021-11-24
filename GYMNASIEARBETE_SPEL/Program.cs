using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("test");
            Vector2 winSize = new Vector2(1920, 1200);
            Raylib.InitWindow((int)winSize.X, (int)winSize.Y, "Gymnasiearbete");
            Raylib.SetTargetFPS(165);

            Texture2D shipTex = Raylib.LoadTexture(@"media\shiptest.png");
            Texture2D shotTex = Raylib.LoadTexture(@"media\shottest.png");
            Texture2D satTex = Raylib.LoadTexture(@"media\satelite.png");

            Game game = new Game(winSize);
            Ship ship = new Ship(winSize, new Gun(), shipTex);
            


            //Test attacks
            //attacks.BulletCircle(start, 200, 12, Color.WHITE, 11);
            //attacks.SplinterShot(start, 500, 0, 5, Color.WHITE, 15, 4);

            //Test spiral repeat attack
            AttackInfo testInfo2 = AttackInfo.Default();
            testInfo2.Color = Color.RED;
            testInfo2.Angle += 180;
            //repeats.Add(new Repeat(attacks.SingleBullet, 20, 0.01f, testInfo));
            //repeats.Add(new Repeat(attacks.SplinterShot, 80, 0.03f, testInfo));
            //repeats.Add(new Repeat(attacks.SingleBullet, 80, 0.005f, testInfo2));
            //repeats.Add(new Repeat(attacks.SplinterShot, 40, 0.03f, testInfo2));
            //repeats.Add(new Repeat(attacks.SingleBullet, 40, 0.05f, testInfo));



            while (!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();
                Raylib.ClearBackground(Color.BLACK);
                float delta = Raylib.GetFrameTime();

                switch (game.gameState)
            {
                //Menu
                case 1:
                    game.MenuScreen();
                    game.gameState = game.MenuInput();

                    break;
                //Tutorial and gameplay
                case 2:
                    switch (game.gameplayState)
                    {
                        case 1:
                            game.TutorialScreen1();
                            break;
                        case 2:
                            game.TutorialScreen2(ship);
                            break;
                        case 3:
                            game.GameStart();
                            break;
                        case 4:
                            game.Wave(4, game.SatDown);
                            break;
                        case 5:
                            game.Wave(4, game.SatLeft);
                            break;
                        case 6:
                            game.Wave(5, game.SatUp);
                            break;
                        case 7:
                            game.Wave(5, game.RightTopSplint);
                            break;
                        case 8:
                            game.Wave(4, game.LeftTopSplint);
                            break;
                        case 9:
                            game.Wave(6, game.SpinTop);
                            break;
                    }


                    //Shots
                    Shot.MoveShots(game.shots, delta);
                    Shot.DrawShots(game.shots);
                    Shot.CheckCollisionWithEnemy(game.shots, game.enemies);
                    Shot.DeleteOffScreenShots(game.shots, winSize);

                    //Bullets
                    Bullet.DrawBullets(game.bullets);
                    Bullet.MoveBullets(game.bullets, delta);
                    Bullet.CheckCollisionWithShip(game.bullets, ship);
                    Bullet.DeleteOffScreenBullets(game.bullets, winSize);

                    //Enemies and repeats
                    Enemy.TickAllEnemies(game.enemies, delta);
                    Repeat.TickAllRepeats(game.repeats, delta);

                    //Ship
                    ship.MoveShip(delta, winSize);
                    ship.DrawShip(delta);
                    ship.DrawHealhtBar(winSize, game);
                    ship.gun.Aim();
                    ship.gun.Shoot(game.shots, ship, delta, shotTex);

                    //Game
                    game.Tick(delta);
                    break;
            }



                

                //FPS
                int fps = Raylib.GetFPS();
                Raylib.DrawText($"{fps}", 50, 50, 50, Color.GRAY);

                Raylib.EndDrawing();
            }
        }
    }
}
