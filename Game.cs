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
        Vector2 Velocity = new Vector2(0, 0);
        Vector2 Position = new Vector2(100, 100);
        int Size = 50;
        int Speed = 50;
        int JumpForce = 400;
        int Gravity = 10;
        public void Setup()
        {
            Window.SetSize(1400, 1000);
        }
        public void Update()
        {

            Window.ClearBackground(Color.Black);

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

            //if mouse is pressed spawn a new box
            if (Input.IsMouseButtonPressed(0))
            {
                objects.AddBoxVelocity(new Vector2(0, 0));
                objects.AddBoxPosition(Input.GetMousePosition());
            }
            //move and draw objects
            objects.MoveAndDraw();
        }
    }
}
