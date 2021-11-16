using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Menu
    {
        Vector2 winSize;

        public Menu(Vector2 windowSize)
        {
            winSize = windowSize;
        }

        public void MenuScreen()
        {
            CenteredText("SPACE SHOOTER", (int)winSize.X, 100, 140, 0);

            CenteredText("PRESS ENTER", (int)winSize.X, 60, 600, 0);
            CenteredText("[PRESS 1-5 FOR TESTING MODES]", (int)winSize.X, 28, 700, 0);
        }

        public int Input()
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
            if (Raylib.IsKeyDown(KeyboardKey.KEY_ENTER))
            {
                state = 2;
            }
            return state;
        }






        public void CenteredText(string text, int fullWidth, int fontSize, int yPos, int xStart)
        {
            Raylib.DrawText(text, xStart + (fullWidth - Raylib.MeasureText(text, fontSize)) / 2, yPos, fontSize, Color.WHITE);
        }
    }
}