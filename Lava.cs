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
		Height -= Speed;
		// speed up lava rising
		Speed += 0.0002f;
        Graphics.Scale = 1f;
        Graphics.Draw(LavaSprite, new Vector2(0,Height));
	}
}
