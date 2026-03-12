using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace MohawkGame2D
{

public class Objects
{
        public static List<Vector2> BoxPositions = new List<Vector2>();
        public List<Vector2> BoxVelocitys = new List<Vector2>();
        public List<bool> BoxGrounded = new List<bool>();
        int BoxSize = 35;
        int Gravity = 10;
        public void AddBox(Vector2 Velocity, Vector2 Position)
        {
            //add new box with set velocity and position
            BoxVelocitys.Add(Velocity);
            BoxPositions.Add(Position);
            BoxGrounded.Add(false);
        }
        public void MoveAndDraw()
	{
            //run collision for all boxes
            for (int i = 0; i < BoxPositions.Count; i++)
            {
                Vector2 BoxPosition = BoxPositions[i];
                //apply gravity to box if not at the bottom of the screen
                if (BoxPositions[i].Y < Window.Size.Y - BoxSize)
                {
                    if (BoxGrounded[i] == false)
                    {
                        BoxVelocitys[i] += new Vector2(0, Gravity);
                    }
                }
                else
                // if on bottom stop velocity
                {
                    BoxGrounded[i] = true;
                    BoxVelocitys[i] = new Vector2(BoxVelocitys[i].X,0);
                    BoxPositions[i] = new Vector2(BoxPositions[i].X,Window.Size.Y - BoxSize);
                }
                // check each box to see if they are colliding
                for (int I = 0; I < BoxPositions.Count; I++)
                {
                    //compare current box position to others to check if they overlap
                    if (BoxPositions[i].Y > BoxPositions[I].Y - BoxSize && BoxPositions[i].X > BoxPositions[I].X - BoxSize && BoxPositions[i].X < BoxPositions[I].X + BoxSize && BoxPositions[i].Y < BoxPositions[I].Y + BoxSize)
                    {
                        // check if box isnt the current box
                        if (i != I)
                        {
                            // if colliding stop box movement 
                            if (BoxGrounded[i] == false)
                            {
                                BoxPositions[i] = new Vector2(BoxPositions[i].X,BoxPositions[I].Y - BoxSize);
                                BoxGrounded[i] = true;
                                BoxVelocitys[i] = new Vector2(0, 0);
                            }
                        }
                    }
                }
                //a move box based on velocity and render box at its position
                BoxPositions[i] += BoxVelocitys[i] * Time.DeltaTime;
                Draw.FillColor = Color.Red;
                Draw.Square(BoxPositions[i], BoxSize);
            }
        }
}

}

