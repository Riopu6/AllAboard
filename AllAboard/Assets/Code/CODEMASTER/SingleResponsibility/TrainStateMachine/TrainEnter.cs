using Unity.Extentions;
using UnityEngine;

public class TrainEnter : ITrainState
{

	private readonly TrainStateMachine Context;
	private StateCollection collection;
	private Vector3 StopPosition;

	public TrainEnter(TrainStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}

	public void EnterState()
	{
		Context.transform.position = Context.MovePoints.StartPosition;

		StopPosition = GetRandomPlatform();

		Context.PlayAnimation(collection.AnimationName);

	}

	public void RunState()
	{
		Move();
		if (Context.Rig.position.AproxMatch(StopPosition))
		{ 
			Context.Rig.position = StopPosition;
			Context.SetState(Context.trainOpenDoors);
		}
	}

	private void Move()
	{
		Vector3 startPosition = Context.transform.position;
		Vector3 platformPosition = StopPosition;

		float moveSpeed = 2.5f;
		Context.Rig.position = Vector3.Lerp(startPosition, platformPosition, Time.deltaTime * moveSpeed);

	}
	private Vector3 GetRandomPlatform()
	{
		return new Vector3[] { Context.MovePoints.Stop1Position, Context.MovePoints.Stop2Position }.GetRandomElement();
	}
}