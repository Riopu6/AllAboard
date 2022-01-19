using System;
using UnityEngine;

[Serializable]
public struct PlayerCollection
{
	public AudioClip audioClip;
	[SerializeField] private AnimationClip animation;
	public string animationName { get { return animation.name; } }
}
