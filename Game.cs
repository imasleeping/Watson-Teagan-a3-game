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
        float BoxSpawnTimer = 3f;
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
                objects.AddBox(new Vector2(0, 0),new Vector2(Random.Float(0, Window.Size.X),0));
                BoxSpawnTimer = 3f;
            }
            //move and draw objects/player
            objects.MoveAndDraw();
            player.MoveAndDraw();
        }
    }
}
