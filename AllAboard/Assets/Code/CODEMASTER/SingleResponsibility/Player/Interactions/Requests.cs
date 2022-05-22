using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Requests : MonoBehaviour
{
	private List<Sprite> requests;
	[SerializeField] Image displayRequest;

	private int index;

	public Requests() => index = 0;

	public UnityEvent OnRequestFinished;

	private void Start() => requests = GlobalCollectionManager.GetRequests().GetRandomElements(3);

	private void OnRequest_Finished() => index = Mathf.Clamp(index + 1, 0, requests.Count - 1);
	public void Display() => displayRequest.sprite = requests[index];

}
