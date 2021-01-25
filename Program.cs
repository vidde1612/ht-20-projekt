using System;
using Raylib_cs;
using System.Numerics;

namespace ht_20_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "ht 20 projekt");

            Raylib.SetTargetFPS(60);

            string scene = "menu";

            Rectangle playerRect;
            Rectangle enemyRect;
            float playerMoveSpeed = 15;
            float posX = 0;
            float posY = 0;

            //Sätter värden för delta time, tiden mellan två frames för att spelet inte ska påverkas av fps (sidenote "double" hade även funkat)
            float lastFrameTime = 0;
            float currentFrameTime = 0;
            float deltaTime = 0;

            Color red = new Color(255, 0, 0, 128);

            Texture2D galaxyImage = Raylib.LoadTexture("galaxy.png");

            while(!Raylib.WindowShouldClose())
            {
                lastFrameTime = currentFrameTime;

                currentFrameTime = (float)Raylib.GetTime() ;

                deltaTime = currentFrameTime - lastFrameTime;

                enemyRect = new Rectangle(posX,posY, 30, 60);

                playerRect = new Rectangle(0, 0, 30, 60);

                Raylib.DrawTexture(galaxyImage, 0, 0, Color.WHITE);

                if(scene == "menu")
                {
                    Raylib.DrawText("Welcome to pew pew guns", 100, 50, 50, red);

                    Raylib.ClearBackground(Color.DARKBLUE);

                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "game";
                    }


                }

                else if(scene == "game")
                {
                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "menu";
                    }
                }
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawRectangleRec(playerRect, Color.BLACK);

                Raylib.DrawRectangleRec(enemyRect, Color.BLACK);

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    posX -= 1 * playerMoveSpeed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    posX += 1 * playerMoveSpeed;
                }
                 if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    posY -= 1 * playerMoveSpeed;
                }
                 if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    posY += 1 * playerMoveSpeed;
                }

                if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                {
                    posX -= 1 * playerMoveSpeed;
                }
                if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                {
                    posX += 1 * playerMoveSpeed;
                }
                 if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                {
                    posY -= 1 * playerMoveSpeed;
                }
                 if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                {
                    posY += 1 * playerMoveSpeed;
                }


                if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
                {
                    Raylib.DrawText("colliding!", 0, 550, 32, Color.BLACK);
                    //players die below
                }

                Raylib.DrawText(scene, 50, 50, 30, Color.BLACK);

                Raylib.EndDrawing();
            }
        }
    }
}
