using Unity.Extentions;
using UnityEngine;

public class TrainExit : ITrainState
{
	private readonly TrainStateMachine Context;
	private StateCollection collection;
	private Vector3 EndPosition;

	public TrainExit(TrainStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}

	public void EnterState()
	{
		EndPosition = Context.MovePoints.EndPosition;
		Context.PlayAnimation(collection.AnimationName);
	}

	public void RunState()
	{
		if (!AnimationPlaying())
		{
			Move();
			if (Context.Rig.position.AproxMatch(EndPosition))
			{
				Context.DestroyTrain();

			}
		}

	}

	private bool AnimationPlaying()
	{
		return Context.Animator.GetCurrentAnimatorStateInfo(0).normalizedTime <= 1;
	}
	private void Move()
	{
		Vector3 startPosition = Context.transform.position;
		Vector3 platformPosition = EndPosition;

		float moveSpeed = 1.5f;
		var velocity = Vector3.zero;
		Context.Rig.position = Vector3.Lerp(startPosition, platformPosition, Time.deltaTime * moveSpeed);

	}


}