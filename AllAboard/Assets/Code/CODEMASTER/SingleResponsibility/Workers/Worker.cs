using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;

public class Worker : MonoBehaviour
{
	[SerializeField] InteractInfo info;
	[SerializeField] AnimationClip idleAnimation;
	[SerializeField] List<AnimationClip> interactingClips;
	private Animator Animator;
	private bool isNextAnimation;

	private void Start()
	{
		isNextAnimation = true;
		Animator = GetComponent<Animator>();
	}

	private void Update()
	{
		if (info.SuccessfullyEntered)
		{
			if(!AnimationPlaying() && isNextAnimation)
			{
				Animator.Play(interactingClips.GetRandomElement().name);
				isNextAnimation = false;
			}
		}
		else
		{
			if (!AnimationPlaying())
			{
				isNextAnimation = true;
				Animator.Play(idleAnimation.name);
			}
		}
	}

	private bool AnimationPlaying() => Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1;
}
