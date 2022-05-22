using System;
using UnityEngine.UI;

public class UiSwitch : BoolOperation
{
	private Image displayImage;

	private void Start()
	{
		displayImage = GetComponent<Image>();
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
		displayImage.enabled = value;
	}

}

