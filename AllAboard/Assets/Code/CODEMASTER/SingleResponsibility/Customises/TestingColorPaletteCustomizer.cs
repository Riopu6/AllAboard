using UnityEngine;

class TestingColorPaletteCustomizer : Customizer
{
	private void Update()
	{
		if(Time.frameCount % 60 == 0)
		{
			Colorize();
		}
	}
}