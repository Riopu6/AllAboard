using UnityEngine;
using UnityEngine.UI;

public class DisplayManager : MonoBehaviour
{
	private Transform toLookAt;
	private static Image displayImage;


	private void Start()
	{
		toLookAt = Camera.main.gameObject.transform;
		displayImage = GetComponent<Image>();
	}

	private void Update()
	{
		transform.LookAt(toLookAt);
	}

	public static void ShowImage(Sprite sprite)
	{
		if (displayImage.sprite == null)
		{
			displayImage.enabled = false;
		}
		else
		{
			displayImage.enabled = true;
			displayImage.sprite = sprite;
		}
	}
}
