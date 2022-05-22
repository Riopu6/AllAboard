using System.Collections.Generic;
using UnityEngine;

public class GlobalCollectionManager : MonoBehaviour
{
	[SerializeField] List<Sprite> requests;
	[SerializeField] List<Sprite> platforms;

	[SerializeField] List<AnimationClip> interactionAnimationClips;
	[SerializeField] List<AudioClip> interactionSoundClips;

	public static GlobalCollectionManager instance;

	private void Awake() => instance = this;
	public static List<Sprite> GetRequests() => instance.requests;
	public static List<AnimationClip> GetAnimationClips() => instance.interactionAnimationClips;
	public static List<AudioClip> GetSoundClips() => instance.interactionSoundClips;
	public static List<Sprite> GetPlatforms() => instance.platforms;
}