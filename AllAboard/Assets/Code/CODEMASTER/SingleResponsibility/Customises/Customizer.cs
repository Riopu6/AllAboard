using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public abstract class Customizer : MonoBehaviour
{
	public List<GameObject> Accessories;

	public virtual void AddRandomExtentions()
	{
		for (int i = 0; i < Accessories.Count; i++)
		{
			bool value = Random.value >= 0.3f;
			Accessories[i].SetActive(value);
		}
	}

	public virtual void Colorize()
	{
		Dictionary<GameObject, ColorPaletteCollection> gameObjectsWithColorPalettes =
			gameObject.GetComponentsInChildren<ColorPaletteCollection>().ToDictionary(x => x.gameObject, x => x.GetComponent<ColorPaletteCollection>());

		foreach (var objectWithPalette in gameObjectsWithColorPalettes)
		{
			objectWithPalette.Key.GetComponent<Renderer>().material.color = objectWithPalette.Value.ColorPalette.GetRandomElement();
		}
	}
}