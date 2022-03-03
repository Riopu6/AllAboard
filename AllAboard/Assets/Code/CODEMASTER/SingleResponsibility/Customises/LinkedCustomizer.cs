using System.Collections.Generic;
using UnityEngine;

public abstract class LinkedCustomizer : Customizer
{
	public List<GameObject> ColorLinkedObjects;

	public override void Colorize()
	{
		base.Colorize();

		var linkedColor = ColorLinkedObjects[0].GetComponent<Renderer>().material.color;
		foreach (var item in ColorLinkedObjects)
		{
			item.GetComponent<Renderer>().material.color = linkedColor;
		}
	}
}