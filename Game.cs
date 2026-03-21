using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

namespace MohawkGame2D
{
    public class Game
    {

        Objects objects = new Objects();
        Player player = new Player();
        Lava lava = new Lava();
        public static bool GameEnd = false;
        float BoxSpawnTimer = 0.8f;
        float BoxSpawnTimerMax = 0.8f;
        bool Win = false;
        public static Texture2D GameOver = Graphics.LoadTexture("..\\..\\..\\Images\\GameOver.png");
        public static Texture2D WinScreen = Graphics.LoadTexture("..\\..\\..\\Images\\WinScreen.png");
        public void Setup()
        {
            Window.SetSize(600, 800);
            player.Setup();
        }
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            //if mouse is pressed spawn a new box
            BoxSpawnTimer -= Time.DeltaTime;
            if (BoxSpawnTimer < 0 )
            {
                objects.AddBox(new Vector2(0, 0),new Vector2(Random.Float(0, Window.Size.X - 35),-50));
                BoxSpawnTimer = BoxSpawnTimerMax;
                if (BoxSpawnTimerMax > 0.05)
                {
                BoxSpawnTimerMax -= 0.01f;
                }
            }
            if (!GameEnd)
            {
            //move and draw objects/player
            objects.MoveAndDraw();
            player.MoveAndDraw();
            //move lava up
            lava.Rise();
            }
            else
            {

                Graphics.Scale = 0.75f;
                if (!Win)
                {
                    Graphics.Draw(GameOver, 0, 0);
                }
                else
                {
                    Graphics.Draw(WinScreen, 0, 0);
                }
            }

            if (Lava.Height < Player.Position.Y)
            {
                GameEnd = true;
            }
            // if player reaches top of screen the win
            if (Player.Position.Y < 0)
            {
                GameEnd = true;
                Win = true;
            }
        }
    }
}
