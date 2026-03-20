using System;
using System.Collections.Generic;
using System.Numerics;
namespace MohawkGame2D
{
    public class Player
    {
        Vector2 Velocity = new Vector2(0, 0);
        public static Vector2 Position = new Vector2(100, 100);
        int SizeY = 41;
        int SizeX = 35;
        int Speed = 50;
        int JumpForce = 250;
        int Gravity = 10;
        int boxsize;
        public Texture2D PlayerTexture = Graphics.LoadTexture("..\\..\\..\\Images\\SmallClown.png");

        public void Setup()
        {
            boxsize = Objects.BoxSize;
        }
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
            //if player isnt on floor
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
                //jump
                if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
                {
                    Velocity.Y -= JumpForce;
                }
            }
            // get box positions from object class
            List<Vector2> BoxPositions = Objects.BoxPositions;
            // get box velocitys from object class
            List<Vector2> BoxVelocitys = Objects.BoxVelocitys;
            for (int I = 0; I < BoxPositions.Count; I++)
            {
                if (Position.Y > Window.Size.Y)
                {
                    BoxPositions[I] = new Vector2(BoxPositions[I].X,BoxPositions[I].Y - 200);
                }
                //compare current player position to box position to check if they overlap
                if (Position.Y > BoxPositions[I].Y - SizeY && Position.X > BoxPositions[I].X - SizeX && Position.X < BoxPositions[I].X + boxsize && Position.Y < BoxPositions[I].Y + boxsize)
                {
                    Vector2 Collider = BoxPositions[I];

                    //jump if on box and jump pressed
                    if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
                    {
                        Velocity.Y = -JumpForce;
                    }
                        // check if player is on bottom of the box
                        if (Position.Y >= Collider.Y + boxsize - boxsize / 3)
                        {
                            // block vertical movement on the bottom of the box
                            Velocity.Y = 0;
                            Position.Y = Collider.Y + boxsize + 1;
                            if (BoxVelocitys[I].Y > 0)
                            {
                            Game.GameEnd = true;
                            }
                        }
                        else
                        {
                            //check if player is on top of the box
                            if (Position.Y <= Collider.Y - SizeY + boxsize / 3)
                            {
                                // block vertical movement on the top of the box
                                Position.Y = Collider.Y - SizeY;
                            if (Velocity.Y > 10)
                            {
                                Velocity.Y = 10;
                            }
                            }
                            else
                            {
                            //check if player collides with left side of box
                            if (Position.X <= Collider.X + boxsize / 4)
                                {
                                    // block sideways movement on the left side of the box
                                    Position.X = Collider.X - SizeX;
                                }
                                //check if player collides with right side of box
                                if (Position.X >= Collider.X + boxsize - boxsize / 4)
                                {
                                    // block sideways movemnt on the right side of the box
                                    Position.X = Collider.X + boxsize;
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


