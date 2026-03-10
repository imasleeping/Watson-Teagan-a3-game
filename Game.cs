// Include the namespaces (code libraries) you need below.
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
        public void Setup()
        {
            Window.SetSize(800, 600);
        }
        public void Update()
        {
            Window.ClearBackground(Color.Black);

            //if mouse is pressed spawn a new box
            if (Input.IsMouseButtonPressed(0))
            {
                objects.AddBox(new Vector2(0, 0),Input.GetMousePosition());
            }
            //move and draw objects/player
            objects.MoveAndDraw();
            player.MoveAndDraw();
        }
    }
}
