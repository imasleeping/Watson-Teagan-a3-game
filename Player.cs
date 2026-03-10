using System;
using System.Numerics;
namespace MohawkGame2D
{
    public class Player
    {
        Vector2 Velocity = new Vector2(0, 0);
        Vector2 Position = new Vector2(100, 100);
        int Size = 25;
        int Speed = 50;
        int JumpForce = 250;
        int Gravity = 10;
            public void MoveAndDraw()
	    {
            //player parameters
            Draw.FillColor = Color.White;
            Draw.Square(Position, Size);

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
            if (Position.X > Window.Size.X - Size)
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
            if (Position.Y < Window.Size.Y - Size)
            {
                //gravity
                Velocity.Y += Gravity;
            }
            else
            {
                //stop on floor
                Velocity.Y = 0;
                Position.Y = Window.Size.Y - Size;
                //jump
                if (Input.IsKeyboardKeyPressed(KeyboardInput.W))
                {
                    Velocity.Y -= JumpForce;
                }
            }
            //drag X axis
            Velocity.X += (-Velocity.X * 0.2f);

        }
    }
}

