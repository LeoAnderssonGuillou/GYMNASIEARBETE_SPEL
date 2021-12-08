using System;
using System.Numerics;
using System.Collections.Generic;
using Raylib_cs;

namespace GYMNASIEARBETE_SPEL
{
    public class Enemy
    {
        public Vector2 pos = new Vector2();
        Vector2 originalPos = new Vector2();
        public Vector2 Speed = new Vector2();
        public Rectangle hitbox;
        int movementIndex;
        float speedValue;
        float distanceTravelled;
        int maxDistance;
        float red = 255;
        public int hp;
        float stayTimer;
        float stayTime = 10;

        //Movement rotation
        float angle;
        float angleChange;
        float angleChanged;
        float maxAngleChange;
        public float visRotation;


        public Enemy(int moveIndex, Vector2 startPos, float speed, int distance, float startAngle, float angleChange_, float totalAngleChange, int hp_)
        {
            movementIndex = moveIndex;
            pos = startPos;
            originalPos = startPos;
            maxDistance = distance;
            speedValue = speed;
            angle = startAngle;
            angleChange = angleChange_;
            maxAngleChange = totalAngleChange;
            hp = hp_;
        }

        public Enemy()
        {
            hp = 1;
            Console.WriteLine("YUP");
        }


        public void Tick(float delta, Texture2D text)
        {
            switch (movementIndex)
            {
                case 0:
                    if (stayTimer >= stayTime)
                    {
                        Speed.X = MathF.Sin(angle * MathF.PI / 180) * speedValue * delta;
                        Speed.Y = MathF.Cos(angle * MathF.PI / 180) * speedValue * delta;
                        pos -= Speed;
                    }
                    stayTimer += delta;
                    break;
                case 1:
                    SimpleMovement(delta);
                    break;
                case 2:
                    SimpleMovement(delta);
                    stayTime = 14;
                    break;
            }
            //Draw enemy
            Raylib.DrawTexturePro(
                    text,
                    new Rectangle(0, 0, 208, 104),
                    new Rectangle(pos.X, pos.Y, 208, 104),
                    new Vector2(104.5f, 44),
                    visRotation,
                    new Color(255, (int)red, (int)red, 255)
                    );
            hitbox = new Rectangle(pos.X - 32, pos.Y - 40, 65, 65);
            //Raylib.DrawRectangleRec(hitbox, new Color(255, (int)red, (int)red, 255));
            
            //Regain color
            if (red < 255)
            {
                red += delta * 700;
                red = Math.Min(red, 255);
            }

        }

        public void SimpleMovement(float delta)
        {
            Speed.X = MathF.Sin(angle * MathF.PI / 180) * speedValue * delta;
            Speed.Y = MathF.Cos(angle * MathF.PI / 180) * speedValue * delta;
            pos += Speed;
            distanceTravelled += Speed.Length();
            angle += angleChange * delta;
            angleChanged += angleChange * delta;

            if (distanceTravelled >= maxDistance)
            {
                Speed = new Vector2(0, 0);
                movementIndex = 0;
            }
            if (angleChanged >= maxAngleChange || angleChanged <= -maxAngleChange)
            {
                angleChange = 0;
            }
        }

        public void DamageEnemy()
        {
            red = 150;
            hp -= 20;
        }



        //Runs Tick for each enemy
        public static void TickAllEnemies(List<Enemy> enemies, float delta, Vector2 window, Texture2D text, Game game)
        {
            for (int x = enemies.Count - 1; x >= 0; x--)
            {
                Enemy enemy = enemies[x];
                enemy.Tick(delta, text);
                if (enemy.hp <= 0)
                {
                    enemies.RemoveAt(x);
                    game.enemiesDestroyed++;
                }
                if (enemy.pos.X > window.X + 500 || enemy.pos.X < -500 || enemy.pos.Y > window.Y + 500 || enemy.pos.Y < -500)
                {
                    enemies.RemoveAt(x);
                }
            }
        }
    }
}