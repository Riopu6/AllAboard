using System.Collections.Generic;
using UnityEngine;

public class GlobalCollectionManager : MonoBehaviour
{
	[SerializeField] List<Sprite> requests;
	[SerializeField] List<AnimationClip> interactionAnimationClips;

	public static GlobalCollectionManager instance;

	private void Awake() => instance = this;
	public static List<Sprite> GetRequests() => instance.requests;
	public static List<AnimationClip> GetAnimationClips() => instance.interactionAnimationClips;
}