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
        float BoxSpawnTimer = 1f;
        float BoxSpawnTimerMax = 1f;
        public void Setup()
        {
            Window.SetSize(800, 600);
        }
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            //if mouse is pressed spawn a new box
            BoxSpawnTimer -= Time.DeltaTime;
            if (BoxSpawnTimer < 0 )
            {
                objects.AddBox(new Vector2(0, 0),new Vector2(Random.Float(0, Window.Size.X - 35),0));
                BoxSpawnTimer = BoxSpawnTimerMax;
                BoxSpawnTimerMax -= 0.005f;
            }
            if (!GameEnd)
            {
            //move and draw objects/player
            objects.MoveAndDraw();
            player.MoveAndDraw();
            //move lava up
            lava.Rise();
            }

            if (Lava.Height < Player.Position.Y)
            {
                Game.GameEnd = true;
            }
        }
    }
}
