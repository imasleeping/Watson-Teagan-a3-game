using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Numerics;

namespace MohawkGame2D
{

public class Objects
{
        public List<Vector2> BoxPositions = new List<Vector2>();
        public List<Vector2> BoxVelocitys = new List<Vector2>();
        Vector2 CurrBoxVelocity = new Vector2(0, 0);
        Vector2 CurrBoxPos = new Vector2(0, 0);
        int BoxSize = 50;
        int Gravity = 10;
        public void AddBoxVelocity(Vector2 Velocity)
        {
            //add new box with set velocity
            BoxVelocitys.Add(Velocity);
        }
        public void AddBoxPosition(Vector2 Position)
            //add new box with set position
        {
            BoxPositions.Add(Position);
        }
        public void MoveAndDraw()
	{
            //run collision for all boxes
            for (int i = 0; i < BoxPositions.Count; i++)
            {
                Vector2 BoxPosition = BoxPositions[i];
                CurrBoxVelocity = BoxVelocitys[i];
                CurrBoxPos = BoxPositions[i];
                //apply gravity to box if not at the bottom of the screen
                if (CurrBoxPos.Y < Window.Size.Y - BoxSize)
                {
                    BoxVelocitys[i] += new Vector2(0, Gravity);
                }
                else
                // if on bottom stop velocity
                {
                    CurrBoxVelocity.Y = 0;
                    CurrBoxPos.Y = Window.Size.Y - BoxSize;
                }
                // check each box to see if they are colliding
                for (int I = 0; I < BoxPositions.Count; I++)
                {
                    if (CurrBoxPos.Y > BoxPositions[I].Y)
                    {
                        //compare current box position to others to check if they overlap
                        if (CurrBoxPos != BoxPositions[I])
                        {
                            // if colliding stop box movement
                            CurrBoxVelocity = new Vector2(0, 0);
                        }
                    }
                }
                //a move box based on velocity and render box at its position
                BoxPositions[i] += CurrBoxVelocity * Time.DeltaTime;
                Draw.FillColor = Color.Red;
                Draw.Square(BoxPositions[i], BoxSize);
            }
        }
}

}

