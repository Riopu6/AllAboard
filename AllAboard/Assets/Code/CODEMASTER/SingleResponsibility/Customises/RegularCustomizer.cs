using System.Linq;
using UnityEngine;

public class RegularCustomizer : MonoBehaviour
{
	public Renderer Shirt;
	public Renderer Pants;

	public Color[] PantsColors;
	private void Start()
	{
		Shirt.material.color = Random.ColorHSV(0f, 1f, 1f, 1f, 0.5f, 1f);
		Pants.material.color = PantsColors.ElementAt(Random.Range(0, PantsColors.Length));
	}
}