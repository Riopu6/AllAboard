using System;
using UnityEngine;

[Serializable]
public struct StateCollection
{
	public AudioClip audioClip;
	[SerializeField] AnimationClip animation;
	public string AnimationName => animation.name;
}
