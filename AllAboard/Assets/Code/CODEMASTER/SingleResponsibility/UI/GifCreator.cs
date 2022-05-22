using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;
using UnityEngine.UI;

public class GifCreator : MonoBehaviour
{
	private Timer timer;
	private Image DisplayImage;
	private int index = 0;

	[SerializeField] List<Sprite> Sprites;
	[SerializeField, Range(0, 10)] float durationSeconds = 3;

	private void Start()
	{
		timer = new Timer(this);
		DisplayImage = GetComponent<Image>();
	}

	private void Update()
	{
		timer.DelayForSecondsRepeat(3, NextImage);
	}

	private void NextImage()
	{
		index = ResetAtTop(index + 1, 0, Sprites.Count);
		DisplayImage.sprite = Sprites[index];
	}

	private int ResetAtTop(int value, int min, int max)
	{
		if (value <= min || value >= max) value = min;
		return value;
	}
}
