using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;
using UnityEngine.UI;

public class Requests : MonoBehaviour
{
	[SerializeField] List<Sprite> Sprites;
	[SerializeField] Image displayRequest;

	private int index;

	public Requests() => index = 0;

	public static GameEvent OnRequestFinished = new GameEvent();

	private void OnEnable() => OnRequestFinished.LocalEvent += OnRequest_Finished;

	private void OnDisable() => OnRequestFinished.LocalEvent -= OnRequest_Finished;
	private void OnRequest_Finished() => index = Mathf.Clamp(index + 1, 0, GlobalCollectionManager.GetRequests().Count - 1);

	private void Start() => Sprites = GlobalCollectionManager.GetRequests().GetRandomElements(3);

	public void Display() => displayRequest.sprite = Sprites[index];

}
