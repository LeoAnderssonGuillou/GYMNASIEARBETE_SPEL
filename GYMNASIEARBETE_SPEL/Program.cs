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
            Raylib.SetTargetFPS(144);

            Texture2D shipTexOld = Raylib.LoadTexture(@"media\shiptest.png");
            Texture2D shipTex = Raylib.LoadTexture(@"media\ship.png");
            Texture2D shotTex = Raylib.LoadTexture(@"media\shottest.png");
            Texture2D satTex = Raylib.LoadTexture(@"media\satelite.png");
            Texture2D bulletTex = Raylib.LoadTexture(@"media\bullet.png");

            Game game = new Game(winSize, bulletTex);
            Ship ship = new Ship(winSize, new Gun(), shipTex);
            


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
                            game.TutorialScreen1(ship);
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
                            game.Wave(4, game.SatRight);
                            break;
                        case 9:
                            game.Wave(6, game.SpinTop);
                            break;
                        //DiagonalSplints
                        case 10:
                            game.Wave(10, game.DiagonalSplintRight);
                            break;
                        case 11:
                            game.Wave(3, game.DiagonalSplintLeft);
                            break;
                        case 12:
                            game.Wave(3, game.DiagonalSplintRight);
                            break;
                        case 13:
                            game.Wave(2, game.DiagonalSplintLeft);
                            break;
                        case 14:
                            game.Wave(2, game.DiagonalSplintRight);
                            break;
                        case 15:
                            game.Wave(1, game.DiagonalSplintLeft);
                            break;
                        case 16:
                            game.Wave(1, game.DiagonalSplintRight);
                            break;
                        case 17:
                            game.Wave(0.7f, game.DiagonalSplintLeft);
                            break;
                        case 18:
                            game.Wave(0.7f, game.DiagonalSplintRight);
                            break;
                        case 19:
                            game.Wave(0.5f, game.DiagonalSplintLeft);
                            break;
                        case 20:
                            game.Wave(0.5f, game.DiagonalSplintRight);
                            break;
                        //End
                        case 21:
                            game.Wave(4, game.SpinDouble);
                            break;
                        case 22:
                            game.Wave(17, game.RightTopSplint);
                            break;
                        case 23:
                            game.Wave(0, game.LeftTopSplint);
                            break;
                        case 24:
                            game.Wave(10, game.AllSides);
                            break;
                        case 25:
                            game.Wave(10, game.SpinTopSuper);
                            break;
                        //SpeedBois
                        case 26:
                            game.Wave(10, game.SpeedBoi);
                            break;
                        case 27:
                            game.Wave(2, game.SpeedBoi);
                            break;
                        case 28:
                            game.Wave(2, game.SpeedBoi);
                            break;
                        case 29:
                            game.Wave(2f, game.SpeedBoi2);
                            break;
                        case 30:
                            game.Wave(1.4f, game.SpeedBoi2);
                            break;
                        case 31:
                            game.Wave(1.4f, game.SpeedBoi2);
                            break;
                        case 32:
                            game.Wave(1.4f, game.SpeedBoi);
                            break;
                        case 33:
                            game.Wave(0.9f, game.SpeedBoi);
                            break;
                        case 34:
                            game.Wave(0.9f, game.SpeedBoi);
                            break;
                        case 35:
                            game.Wave(1.4f, game.SpeedBoi2);
                            break;
                        case 36:
                            game.Wave(0.6f, game.SpeedBoi2);
                            break;
                        case 37:
                            game.Wave(0.6f, game.SpeedBoi2);
                            break; //a
                        case 38:
                            game.Wave(0.6f, game.SpeedBoi);
                            break;
                        case 39:
                            game.Wave(0.4f, game.SpeedBoi);
                            break;
                        case 40:
                            game.Wave(0.4f, game.SpeedBoi);
                            break;
                        case 41:
                            game.Wave(0.4f, game.SpeedBoi);
                            break;
                        case 42:
                            game.Wave(1f, game.SpeedBoi2);
                            break;
                        case 43:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 44:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 45:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 46:
                            game.Wave(1f, game.SpeedBoi);
                            break;
                        case 47:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 48:
                            game.Wave(0.4f, game.SpeedBoi);
                            break;
                        case 49:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 50:
                            game.Wave(1f, game.SpeedBoi);
                            break;
                        case 51:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        case 52:
                            game.Wave(0.4f, game.SpeedBoi);
                            break;
                        case 53:
                            game.Wave(0.4f, game.SpeedBoi2);
                            break;
                        //End
                        case 54:
                            game.Wave(5 - 2, game.SpinBothSides);
                            break;
                        case 55:
                            game.Wave(4f, game.SpinBothSides);
                            break;
                        case 56:
                            game.Wave(4f, game.SpinBothSides);
                            break;
                        case 57:
                            game.Wave(4f, game.SpinBothSides);
                            break;
                        case 58:
                            game.Wave(4f, game.SpinBothSides);
                            break;
                        case 59:
                            game.Wave(1f, game.SpinBothSides);
                            break;
                        case 60:
                            game.Wave(7f, game.SpinAcrossSuper);
                            break;
                        //Arcs
                        case 61:
                            game.Wave(4 - 1f, game.Arc);
                            break;
                        case 62:
                            game.Wave(1f, game.Arc);
                            break;
                        case 63:
                            game.Wave(1f, game.Arc);
                            break;
                        case 64:
                            game.Wave(1f, game.Arc);
                            break;
                        case 65:
                            game.Wave(0f, game.TightSplintTop);
                            break;
                        case 66:
                            game.Wave(1f, game.Arc2);
                            break;
                        case 67:
                            game.Wave(1f, game.Arc2);
                            break;
                        case 68:
                            game.Wave(1f, game.Arc2);
                            break;
                        case 69:
                            game.Wave(1f, game.Arc2);
                            break;
                        case 70:
                            game.Wave(1f, game.Arc2);
                            break;
                        case 71:
                            game.Wave(1f, game.Arc);
                            break;
                        case 72:
                            game.Wave(0f, game.Arc2);
                            break;
                        case 73:
                            game.Wave(1f, game.Arc);
                            break;
                        case 74:
                            game.Wave(0f, game.Arc2);
                            break;
                        case 75:
                            game.Wave(1f, game.Arc);
                            break;
                        case 76:
                            game.Wave(0f, game.Arc2);
                            break;
                        case 77:
                            game.Wave(1f, game.Arc);
                            break;
                        case 78:
                            game.Wave(0f, game.Arc2);
                            break;
                        //End
                        //DiagonalSplints2
                        case 79:
                            game.Wave(3, game.DiagonalSplintRight);
                            break;
                        case 80:
                            game.Wave(1, game.DiagonalSplintLeft);
                            break;
                        case 81:
                            game.Wave(1, game.DiagonalSplintRight);
                            break;
                        case 82:
                            game.Wave(0.7f, game.DiagonalSplintLeft);
                            break;
                        case 83:
                            game.Wave(0.7f, game.DiagonalSplintRight);
                            break;
                        case 84:
                            game.Wave(0.7f, game.DiagonalSplintLeft);
                            break;
                        case 85:
                            game.Wave(0.44f, game.DiagonalSplintRight);
                            break;
                        case 86:
                            game.Wave(0.44f, game.DiagonalSplintLeft);
                            break;
                        case 87:
                            game.Wave(0.44f, game.DiagonalSplintRight);
                            break;
                        case 88:
                            game.Wave(0.44f, game.DiagonalSplintLeft);
                            break;
                        case 89:
                            game.Wave(0.3f, game.DiagonalSplintRight);
                            break;
                        case 90:
                            game.Wave(0.3f, game.DiagonalSplintLeft);
                            break;
                        case 91:
                            game.Wave(0.3f, game.DiagonalSplintRight);
                            break;
                        case 92:
                            game.Wave(0.3f, game.DiagonalSplintLeft);
                            break;
                        case 93:
                            game.Wave(0.3f, game.DiagonalSplintRight);
                            break;
                        case 94:
                            game.Wave(0.2f, game.DiagonalSplintLeft);
                            break;
                        case 95:
                            game.Wave(0.2f, game.DiagonalSplintRight);
                            break;
                        case 96:
                            game.Wave(0.2f, game.DiagonalSplintLeft);
                            break;
                        case 97:
                            game.Wave(0.2f, game.DiagonalSplintRight);
                            break;
                        case 98:
                            game.Wave(0.2f, game.DiagonalSplintLeft);
                            break;
                        case 99:
                            game.Wave(0.2f, game.DiagonalSplintRight);
                            break;
                        //End
                        case 100:
                            game.Wave(0f, game.RightTopSplint);
                            break;
                        case 101:
                            game.Wave(0f, game.LeftTopSplint);
                            break;
                        case 102:
                            game.Wave(2f, game.SpinTopSuper);
                            break;
                        case 103:
                            game.Wave(13f, game.SpinAcrossSuper);
                            break;
                        case 104:
                            game.Wave(2f, game.SpinAcrossSuper);
                            break;
                        case 105:
                            game.Wave(2f, game.SpinAcrossSuper);
                            break;         
                        case 106:
                            game.Wave(5f, game.SpinTopSplint);
                            break;
                        case 107:
                            game.Wave(14, game.SpinWall);
                            break;
                        //Hell
                        case 108:
                            game.Wave(19, game.TightSplintTop);
                            break;
                        case 109:
                            game.Wave(0, game.Hexa);
                            break;
                        case 110:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 111:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 112:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 113:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 114:
                            game.Wave(3, game.SpinTopSuper);
                            break;
                        case 115:
                            game.Wave(2f, game.TightSplintTop);
                            break;
                        case 116:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 117:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 118:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 119:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 120:
                            game.Wave(5, game.Hexa);
                            break;
                        //Hell 2
                        case 121:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 122:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 123:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 124:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 125:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 126:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 127:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 128:
                            game.Wave(0.5f, game.SpinAcrossSuper);
                            break;
                        case 129:
                            game.Wave(4f, game.ByeBye);
                            break;
                        case 130:
                            game.Wave(8f, game.Hexa);
                            break;
                        case 131:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 132:
                            game.Wave(2f, game.Hexa);
                            break;
                        case 133:
                            game.Wave(0f, game.Hexa);
                            break;
                        case 134:
                            game.FinalWave(5f, game.SpinTopSuper);
                            break;
                    }


                    //Shots
                    Shot.MoveShots(game.shots, delta);
                    Shot.DrawShots(game.shots);
                    Shot.CheckCollisionWithEnemy(game.shots, game.enemies);
                    Shot.DeleteOffScreenShots(game.shots, winSize);

                    //Bullets
                    Bullet.DrawBullets(game.bullets, bulletTex);
                    Bullet.MoveBullets(game.bullets, delta);
                    Bullet.CheckCollisionWithShip(game.bullets, ship);
                    Bullet.DeleteOffScreenBullets(game.bullets, winSize);

                    //Enemies and repeats
                    Enemy.TickAllEnemies(game.enemies, delta, winSize, satTex, game);
                    Repeat.TickAllRepeats(game.repeats, delta);

                    //Ship
                    ship.MoveShip(delta, winSize);
                    ship.DrawShip(delta);
                    ship.DrawHealhtBar(winSize, game);
                    ship.gun.Aim();
                    ship.gun.Shoot(game.shots, ship, delta, shotTex);

                    //Game
                    game.Tick(delta, ship);
                    //Console.WriteLine(game.enemies.Count);
                    break;

                case 3:
                    game.GameOverScreen();
                    break;
            }



                

                //FPS
                int fps = Raylib.GetFPS();
                //Raylib.DrawText($"{fps}", 50, 50, 50, Color.GRAY);

                Raylib.EndDrawing();
            }
        }
    }
}
