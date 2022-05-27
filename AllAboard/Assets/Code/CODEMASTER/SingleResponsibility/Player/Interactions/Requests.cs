using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;
using UnityEngine.UI;

public class Requests : MonoBehaviour
{
	private List<Sprite> requests;
	private int index;

	[SerializeField] Image displayRequest;

	private void Awake() => index = 0;

	private void Start()
	{
		requests = GlobalCollectionManager.GetRequests().GetRandomElements(Constants.MaxRequests);
		requests.Add(GlobalCollectionManager.GetPlatforms().GetRandomElement());
		ShowRequest();
	}

	private void IncrementRequest() => index = Mathf.Clamp(index + 1, 0, requests.Count - 1);
	private void HideRequest() => displayRequest.enabled = false;
	public void ShowRequest()
	{
		displayRequest.enabled = true;
		displayRequest.sprite = requests[index];
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Interactable"))
		{
			var info = other.GetComponent<InteractInfo>();
			if (info.SuccessfullyEntered)
			{
				HideRequest();
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.CompareTag("Interactable"))
		{
			var info = other.GetComponent<InteractInfo>();
			if (info.SuccessfullyExited)
			{
				IncrementRequest();
				ShowRequest();
			}
		}
	}

}
