// Include the namespaces (code libraries) you need below.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;

// The namespace your code is in.
namespace MohawkGame2D
{
    /// <summary>
    ///     Your game code goes inside this class!
    /// </summary>
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
                objects.AddBoxVelocity(new Vector2(0, 0));
                objects.AddBoxPosition(Input.GetMousePosition());
            }
            //move and draw objects
            objects.MoveAndDraw();
            player.MoveAndDraw();
        }
    }
}
