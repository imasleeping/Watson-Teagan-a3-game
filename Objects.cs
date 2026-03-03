using System;
using System.Collections.Generic;
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
        int Gravity = 10;
        public void AddBoxVelocity(Vector2 Velocity)
        {
            BoxVelocitys.Add(Velocity);
        }
        public void AddBoxPosition(Vector2 Position)
        {
            BoxPositions.Add(Position);
        }
        public void MoveAndDraw()
	{
            for (int i = 0; i < BoxPositions.Count; i++)
            {
                Vector2 BoxPosition = BoxPositions[i];
                CurrBoxVelocity = BoxVelocitys[i];
                CurrBoxPos = BoxPositions[i];
                if (CurrBoxPos.Y < Window.Size.Y - 50)
                {
                    BoxVelocitys[i] += new Vector2(0, Gravity);
                }
                else
                {
                    CurrBoxVelocity.Y = 0;
                }
                for (int I = 0; I < BoxPositions.Count; I++)
                {
                    if (CurrBoxPos.Y > BoxPositions[I].Y)
                    {
                        if (CurrBoxPos != BoxPositions[I])
                        {
                            CurrBoxVelocity = new Vector2(0, 0);
                        }
                    }
                }
                BoxPositions[i] += CurrBoxVelocity * Time.DeltaTime;
                Draw.FillColor = Color.Red;
                Draw.Square(BoxPositions[i], 50);
            }
        }
}

}

