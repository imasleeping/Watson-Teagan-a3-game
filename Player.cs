using System;
using System.Collections.Generic;
using System.Numerics;
namespace MohawkGame2D
{
    public class Player
    {
        Vector2 Velocity = new Vector2(0, 0);
        Vector2 Position = new Vector2(100, 100);
        int SizeY = 41;
        int SizeX = 35;
        int Speed = 50;
        int JumpForce = 250;
        int Gravity = 10;
        int BoxSize = 45;
        public Texture2D PlayerTexture = Graphics.LoadTexture("..\\..\\..\\Images\\SmallClown.png");
        public void MoveAndDraw()
	    {
            //player parameters

            Graphics.Scale = 1.8f;
            Graphics.Draw(PlayerTexture, Position);
            //Draw.FillColor = Color.White;
            //Draw.Square(Position, Size);

            //velocity to movement
            Position += Velocity * Time.DeltaTime;

            //left boundary
            if (Position.X < 0)
            {
                //wall bouncyness left
                Velocity.X += 50;
            }
            else
            {
                //left movement
                if (Input.IsKeyboardKeyDown(KeyboardInput.A))
                {
                    Velocity.X -= Speed;
                }
            }
            //right boundary
            if (Position.X > Window.Size.X - SizeX)
            {
                //wall bouncyness right
                Velocity.X -= 50;
            }
            else
            {
                //right movemnt
                if (Input.IsKeyboardKeyDown(KeyboardInput.D))
                {
                    Velocity.X += Speed;
                }
            }
            //floor boundary
            if (Position.Y < Window.Size.Y - SizeY)
            {
                    //gravity
                    Velocity.Y += Gravity;
            }
            else
            {
                //stop on floor
                Velocity.Y = 0;
                Position.Y = Window.Size.Y - SizeY;
                //disable gravity
                //jump
                if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
                {
                    Velocity.Y -= JumpForce;
                }
            }
            // get box positions from object class
            List<Vector2> BoxPositions = Objects.BoxPositions;
            for (int I = 0; I < BoxPositions.Count; I++)
            {
                //compare current player position to box position to check if they overlap
                if (Position.Y > BoxPositions[I].Y - SizeY && Position.X > BoxPositions[I].X - SizeX && Position.X < BoxPositions[I].X + BoxSize && Position.Y < BoxPositions[I].Y + BoxSize)
                {
                    Vector2 Collider = BoxPositions[I];

                    //jump if on box and jump pressed
                    if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
                    {
                        Velocity.Y = -JumpForce;
                    }
                        // check if player is on bottom of the box
                        if (Position.Y >= Collider.Y + BoxSize + 5 - 10)
                        {
                            // block vertical movement on the bottom of the box
                            Velocity.Y = 0;
                            Position.Y = Collider.Y + BoxSize + 1;
                        }
                        else
                        {
                            //check if player is on top of the box
                            if (Position.Y <= Collider.Y - SizeY + 15)
                            {
                                // block vertical movement on the top of the box
                                Position.Y = Collider.Y - SizeY;
                            }
                            else
                            {
                            //check if player collides with left side of box
                            if (Position.X <= Collider.X + 10)
                                {
                                    // block sideways movement on the left side of the box
                                    Position.X = Collider.X - SizeX;
                                }
                                //check if player collides with right side of box
                                if (Position.X >= Collider.X + BoxSize - 10)
                                {
                                    // block sideways movemnt on the right side of the box
                                    Position.X = Collider.X + BoxSize;
                                }
                            }
                        }
                }

            }
            //drag X axis
            Velocity.X += (-Velocity.X * 0.2f);

        }
    }
}


