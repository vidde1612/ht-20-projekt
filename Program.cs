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

            string scene = "menu";

            //Font stringFont = new Font("Arial", 16);

            Rectangle playerRect;
            Rectangle enemyRect;
            float playerMoveSpeed = 15f;
            float posX = 0f;
            float posY = 700f;
            float posX2 = 1150f;
            float posY2 = 700f;
            float playerHeight = 100f;
            float playerWidth = 50f;
            bool playerJumping = false;
            float gravity = 9.82f;
            float force = 100f;

            //Sätter värden för delta time, tiden mellan två frames för att spelet inte ska påverkas av fps (sidenote "double" hade även funkat)
            float lastFrameTime = 0f;
            float currentFrameTime = 0f;
            float deltaTime = 0f;

            Texture2D galaxyImage = Raylib.LoadTexture("galaxy.png");

            while(!Raylib.WindowShouldClose())
            {
                //Visar FPS, frame time, time, delta time och player positions X & y värden
                Raylib.DrawRectangle(0, 0, 200, 100, Color.BLACK);
                Raylib.DrawText("FPS: " + Raylib.GetFPS().ToString(), 12, 12, 12, Color.WHITE);
                Raylib.DrawText("Frame Time: " + Raylib.GetFrameTime().ToString(), 12, 24, 12, Color.WHITE);
                Raylib.DrawText("Time: " + Raylib.GetTime().ToString(), 12, 36, 12, Color.WHITE);
                Raylib.DrawText("Delta Time: " + deltaTime.ToString(), 12, 48, 12, Color.WHITE);
                Raylib.DrawText("PlayerOne Pos: " + posX + " , Y: " + posY, 12, 60, 12, Color.WHITE);
                Raylib.DrawText("PlayerOne Pos: " + posX2 + " , Y: " + posY2, 12, 72, 12, Color.WHITE);

                lastFrameTime = currentFrameTime;
                currentFrameTime = (float)Raylib.GetTime() ;
                deltaTime = currentFrameTime - lastFrameTime;

                playerRect = new Rectangle(posX, posY, playerWidth, playerHeight);
                enemyRect = new Rectangle(posX2, posY2, playerWidth, playerHeight);

                //Raylib.DrawTexture(galaxyImage, 0, 0, Color.WHITE);

                if(scene == "menu")
                {

                    if (Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "game";
                    }

                    Raylib.BeginDrawing();

                    Raylib.ClearBackground(Color.BLACK);

                    Raylib.DrawText("Welcome to pew pew guns", 300, height/2 - 25, 50, Color.WHITE);
                }
                else if(scene == "game")
                {
                    //player 1 movements )
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_A))
                    {
                        posX -= playerMoveSpeed;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_D))
                    {
                        posX += playerMoveSpeed;
                    }

                    //player 2 movements
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_LEFT))
                    {
                        posX2 -= 15f;
                    }
                    if (Raylib.IsKeyDown(KeyboardKey.KEY_RIGHT))
                    {
                        posX2 += 15f;
                    }

                    //player 1 keep in screen
                    if((posX + playerWidth) >= width) 
                    {
                        posX = width - playerWidth;
                    }

                    if (posX <= 0f) 
                    {
                        posX = 0f;
                    }

                    if((posY + playerHeight) >= height)
                    {
                        posY = height - playerHeight;
                    }

                    if(posY <= 0f)
                    {
                        posY = 0f;
                    }

                    //player 2 keep in screen
                    if((posX2 + playerWidth) >= width) 
                    {
                        posX2 = width - playerWidth;
                    }

                    if (posX2 <= 0f) 
                    {
                        posX2 = 0f;
                    }

                    if((posY2 + playerHeight) >= height)
                    {
                        posY2 = height - playerHeight;
                    }

                    if(posY2 <= 0f)
                    {
                        posY2 = 0f;
                    }

                    //player 1 gravity
                    if(!playerJumping)
                    {
                        posY += gravity;
                    }

                    else if(Raylib.IsKeyPressed(KeyboardKey.KEY_W))
                    {
                        posY -= force;
                    }
         
                    //ändra scene till menyn från game
                    if(Raylib.IsKeyPressed(KeyboardKey.KEY_ENTER))
                    {
                        scene = "menu";    
                    }

                    if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
                    {
                    Raylib.DrawText("colliding!", 0, 550, 32, Color.BLACK);
                    //players die below
                    }

                    Raylib.BeginDrawing();

                    Raylib.DrawText(posX.ToString(), 600, 400, 32, Color.BLACK);

                    Raylib.ClearBackground(Color.GRAY);

                    Raylib.DrawRectangleRec(playerRect, Color.GREEN);

                    Raylib.DrawRectangleRec(enemyRect, Color.BLACK);

                    Raylib.DrawText(scene, width-150, 20, 50, Color.BLACK);
                }

                Raylib.EndDrawing();
            
            }
        }
    }
}
