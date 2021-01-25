using System;
using Raylib_cs;
using System.Numerics;

namespace ht_20_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            int height = 800;
            int width = 1200;

            Raylib.InitWindow(width, height, "ht 20 projekt");

            Raylib.SetTargetFPS(60);

            string scene = "game";

            //Font stringFont = new Font("Arial", 16);

            Rectangle playerRect;
            Rectangle enemyRect;
            float playerMoveSpeedX = 15;
            float playerMoveSpeedY = 15;
            float playerMoveSpeedX2 = 15;
            float playerMoveSpeedY2 = 15;
            float posX = 0;
            float posY = 0;
            float posX2 = 0;
            float posY2 = 0;
            float playerHeight = 100;
            float playerWidth = 50;
            float speed1 = 15:

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

                enemyRect = new Rectangle(posX,posY, playerWidth, playerHeight);
                playerRect = new Rectangle(posX2, posY2, playerWidth, playerHeight);

                //Raylib.DrawTexture(galaxyImage, 0, 0, Color.WHITE);

                if(scene == "menu")
                {

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "game";
                    }

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.DARKBLUE);

                    Raylib.DrawText("Welcome to pew pew guns", width/2 - 50, height/2 - 25, 50, red);
                }
                else if(scene == "game")
                {
                    //player 1 movements
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                    posX -= 1 * playerMoveSpeedX;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                    posX += 1 * playerMoveSpeedX;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_UP))
                    {
                    posY -= 1 * playerMoveSpeedY;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_DOWN))
                    {
                    posY += 1 * playerMoveSpeedY;
                    }

                    //player 2 movements
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                    posX2 -= 1 * playerMoveSpeedX2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                    posX2 += 1 * playerMoveSpeedX2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_W))
                    {
                    posY2 -= 1 * playerMoveSpeedY2;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_S))
                    {
                    posY2 += 1 * playerMoveSpeedY2;
                    }
                    
                    //ändra scene till menyn från game
                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "menu";    
                    }

                    //player 1 collision
                    if(Raylib.IsKeyDown(KeyboardKey.KEY_LEFT) && posX < 0)
                    {
                        playerMoveSpeedX = speed1;
                    }

                     if(Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT) && posX > 1150)
                    {
                        posX = -playerMoveSpeedX;
                    }

                     if(Raylib.IsKeyDown(KeyboardKey.KEY_UP) && posX < 0)
                    {
                        posX = -playerMoveSpeedX;
                    }

                     if(Raylib.IsKeyDown(KeyboardKey.KEY_DOWN) && posX < 0)
                    {
                        posX = -playerMoveSpeedX;
                    }

                    if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
                    {
                    Raylib.DrawText("colliding!", 0, 550, 32, Color.BLACK);
                    //players die below
                    }

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.GRAY);

                    Raylib.DrawRectangleRec(playerRect, Color.BLACK);

                    Raylib.DrawRectangleRec(enemyRect, Color.BLACK);

                    Raylib.DrawText(scene, 50, 50, 30, Color.BLACK);
                }

                Raylib.EndDrawing();
            }
        }
    }
}
