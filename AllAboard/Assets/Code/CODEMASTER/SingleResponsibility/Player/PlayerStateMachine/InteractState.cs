using System;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public class InteractState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private InteractInfo interactableInfo;
	private bool finishedInteracting;
	private int ignoreSelf;
	private int nextTaskNum;
	private bool getNewInfo;

	public InteractState(PlayerStateMachine context)
	{
		Context = context;
	}

	public void EnterState()
	{
		nextTaskNum = 1;
		getNewInfo = true;
	}

	public void OnCollisionEnter(Collision collision)
	{
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Interactable"))
		{
			interactableInfo = other.GetComponent<InteractInfo>();
		}
	}

	public void RunState()
	{
		if (interactableInfo == null)
		{
			SetToGroundState();
			return;
		}

		var hasFinishedInteracting = Interact(interactableInfo);

		if (hasFinishedInteracting)
		{
			SetToGroundState();
		}
	}

	private void SetToGroundState()
	{
		Context.SetState(Context.groundState);
		Context.groundState.SetSelector(Vector3.one);
	}

	public bool Interact(InteractInfo info)
	{
		finishedInteracting = false;
		ignoreSelf = Context.gameObject.layer;
		if (getNewInfo)
		{
			getNewInfo = false;

			Physics.IgnoreLayerCollision(ignoreSelf, ignoreSelf, true);

			info.EntrancePosition = info.EntranceTransform == null ? Vector3.zero : info.EntranceTransform.position;

			info.RandomAnimationClipName = GlobalCollectionManager.GetAnimationClips().GetRandomElement().name;

		}

		if (nextTaskNum == 1)
		{
			Context.PlayAnimation("Walking");
			MoveTowards(Context, info.ColliderCenter, NextTask);
		}

		if (nextTaskNum == 2)
		{
			if (info.EntrancePosition == Vector3.zero)
			{
				NextTask();
			}
			else
			{
				MoveTowards(Context, info.EntrancePosition, NextTask, Constants.NearInteraction);
			}
		}

		if (nextTaskNum == 3)
		{
			if (info.GetAssignedPosition(Context.Collider) == Vector3.zero)
			{
				NextTask();
			}
			else
			{
				MoveTowards(Context, info.GetAssignedPosition(Context.Collider), NextTask);
			}
		}

		if (nextTaskNum == 4)
		{
			if (!string.IsNullOrWhiteSpace(info.RandomAnimationClipName))
			{
				Context.PlayAnimation(info.RandomAnimationClipName);
			}

			if (!AnimationPlaying(Context) && Context.Animator.GetCurrentAnimatorClipInfo(0)[0].clip.name == info.RandomAnimationClipName)
			{
				NextTask();
			}

		}

		if (nextTaskNum == 5)
		{
			if (info.EntrancePosition == Vector3.zero)
			{
				NextTask();
			}
			else
			{
				Context.PlayAnimation("Walking");
				MoveTowards(Context, info.EntrancePosition, NextTask);
			}
		}

		if (nextTaskNum == 6)
		{
			Context.PlayAnimation("Walking");
			MoveTowards(
				Context,
				info.ColliderCenter,
				() =>
				{
					finishedInteracting = true;
					nextTaskNum = 1;
					getNewInfo = true;
					Physics.IgnoreLayerCollision(ignoreSelf, ignoreSelf, false);

				}
			);
		}

		return finishedInteracting;
	}

	private void MoveTowards(PlayerStateMachine Context, Vector3 towards, Action executeAction, float marginOfError = 0.1f)
	{
		Move(Context, towards);
		Rotate(Context, towards);
		if (Context.transform.position.ExcludeAxis(SnapAxis.Y).AproxMatch(towards.ExcludeAxis(SnapAxis.Y), marginOfError))
		{
			executeAction();
		}
	}

	private void Move(PlayerStateMachine Context, Vector3 target) => Context.Rigidbody.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * Constants.PassengerMovingSpeed);

	private void Rotate(PlayerStateMachine Context, Vector3 target)
	{
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * Constants.PassengerRotationSpeed);
	}

	private void NextTask() => nextTaskNum = Mathf.Clamp(nextTaskNum + 1, 1, Constants.ShopCapacity);

	private bool AnimationPlaying(PlayerStateMachine Context) => Context.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1;
}