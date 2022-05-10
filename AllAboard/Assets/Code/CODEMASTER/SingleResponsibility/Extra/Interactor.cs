using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public class Interactor : MonoBehaviour, Interactable
{
	[Space]
	[SerializeField] TriggerCount otherTriggerCount;
	[Space]
	[SerializeField] List<Transform> targets;
	[SerializeField] List<AnimationClip> animationClips;

	private Vector3 firstPosition;
	private int nextTaskNum = 1;
	private bool finishedInteracting;
	private Vector3 randomPlace;
	private string randomAnimationClipName;

	private void Start()
	{
		firstPosition = GetComponent<Collider>().transform.position;
		randomPlace = targets.Count == 0 ? Vector3.zero : targets.Select(x => x.position).GetRandomElement();
		randomAnimationClipName = animationClips.Count == 0 ? null : animationClips.GetRandomElement().name;
	}

	public bool Interact(PlayerStateMachine Context)
	{
		finishedInteracting = false;

		if (nextTaskNum == 1)
		{
			Context.PlayAnimation("Walking");
			Move(Context, firstPosition);
			Rotate(Context, firstPosition);
			if (Context.transform.position.ExcludeAxis(SnapAxis.Y).AproxMatch(firstPosition.ExcludeAxis(SnapAxis.Y), Constants.NearInteraction))
			{
				NextTask();
			}
		}

		if (nextTaskNum == 2)
		{
			if (randomPlace == Vector3.zero) NextTask();

			Move(Context, randomPlace);
			Rotate(Context, randomPlace);
			if(Context.transform.position.ExcludeAxis(SnapAxis.Y).AproxMatch(randomPlace.ExcludeAxis(SnapAxis.Y), Constants.NearInteraction))
			{
				NextTask();
			}
		}

		if(nextTaskNum == 3)
		{
			if (!string.IsNullOrWhiteSpace(randomAnimationClipName))
				Context.PlayAnimation(randomAnimationClipName);

			if (!AnimationPlaying(Context) && Context.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == randomAnimationClipName)
			{
				NextTask();
			}

		}

		if(nextTaskNum == 4)
		{
			Context.PlayAnimation("Walking");
			Move(Context, firstPosition);
			Rotate(Context, firstPosition);
			if (Context.transform.position.ExcludeAxis(SnapAxis.Y).AproxMatch(firstPosition.ExcludeAxis(SnapAxis.Y)))
			{
				finishedInteracting = true;
				nextTaskNum = 1;
			}
		}

		return finishedInteracting;
	}
	private void Move(PlayerStateMachine Context, Vector3 target) => Context.Rigidbody.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * Constants.PassengerMovingSpeed);

	private void Rotate(PlayerStateMachine Context, Vector3 target)
	{
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * Constants.PassengerRotationSpeed);
	}

	private void NextTask() => nextTaskNum = Mathf.Clamp(nextTaskNum + 1, 0, Constants.LimitShop);

	private bool AnimationPlaying(PlayerStateMachine Context) => Context.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1;

}
