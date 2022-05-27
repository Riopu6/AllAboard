using System;
using UnityEngine;
using UnityEngine.UI;

public class UiSwitch : BoolOperation
{
	private Image displayImage;
	private Vector3 imagePosition;

	private void Start()
	{
		displayImage = GetComponent<Image>();
		imagePosition = displayImage.gameObject.transform.position;
	}

	private void Update()
	{
		RunIf(info.isFull);
	}

	public override void RunIf(Func<bool> condition)
	{
		Switch(condition());
	}

	private void Switch(bool value)
	{
		Animation(value);
		displayImage.enabled = value;
	}

	private void Animation(bool run)
	{
		if (run)
		{
			LeanTween.moveX(displayImage.gameObject, imagePosition.x + 0.5f, 0.5f).setEaseShake();
		}
	}
}

