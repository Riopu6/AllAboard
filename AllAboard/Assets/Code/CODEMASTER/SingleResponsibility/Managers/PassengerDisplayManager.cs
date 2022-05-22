using System.Collections.Generic;
using UnityEngine;

public class PassengerDisplayManger : Display
{
	private List<Sprite> requests = new List<Sprite>();

	//private void OnEnable() => Requests.OnRequestFinished.LocalEvent += NextRequestSprite;
	//private void OnDisable() => Requests.OnRequestFinished.LocalEvent -= NextRequestSprite;

	public override void Start()
	{
		base.Start();
	}

	public override void Update()
	{
		base.Update();
	}

	private void NextRequestSprite()
	{
		int index = requests.IndexOf(DisplayImage.sprite);
		DisplayImage.sprite = requests[index + 1];
	}

	public void ShowImage(Sprite sprite)
	{
		if (DisplayImage.sprite == null)
		{
			DisplayImage.enabled = false;
		}
		else
		{
			DisplayImage.enabled = true;
			DisplayImage.sprite = sprite;
		}
	}
}

