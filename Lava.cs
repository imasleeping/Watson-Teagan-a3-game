using MohawkGame2D;
using System;
using System.Numerics;

public class Lava
{
	public static float Height = Window.Size.Y;
	float Speed = 0.01f;

    public Texture2D LavaSprite = Graphics.LoadTexture("..\\..\\..\\Images\\Lava.png");
	public void Rise()
	{
		Console.WriteLine(Height);
		Height -= Speed;
		Speed += 0.0001f;
        Graphics.Scale = 1f;
        Graphics.Draw(LavaSprite, new Vector2(0,Height));
	}
}
