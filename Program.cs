using System;
using Raylib_cs;

namespace ht_20_projekt
{
    class Program
    {
        static void Main(string[] args)
        {
            Raylib.InitWindow(800, 600, "bildtest");

            Rectangle playerRect = new Rectangle(0, 0, 30, 30);
            Rectangle enemyRect = new Rectangle(150, 150, 30, 30);

            Color red = new Color(255, 0, 0, 128);

            while(!Raylib.WindowShouldClose())
            {
                Raylib.BeginDrawing();

                Raylib.ClearBackground(Color.WHITE);

                Raylib.DrawRectangleRec(playerRect, Color.BLACK);

                if (Raylib.CheckCollisionRecs(playerRect, enemyRect))
                {
                    Raylib.DrawText("colliding!", 0, 550, 32, Color.BLACK);
                }

                Raylib.EndDrawing();
            }
        }
    }
}
