using Unity.Extentions;
using UnityEngine;

public class TrainEnter : ITrainState
{

	private readonly TrainStateMachine Context;
	private StateCollection collection;
	private Vector3 StopPosition;
	private Timer timer;

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
		timer = new Timer(Context);

	}

	public void RunState()
	{
		timer.DelayForSecondsOnce(Constants.TrainResetTime, () =>
		{
			Move();
			if (Context.Rig.position.AproxMatch(StopPosition))
			{
				Context.Rig.position = StopPosition;
				Context.SetState(Context.trainOpenDoors);
			}
		});
	}


	private void Move()
	{
		Vector3 startPosition = Context.transform.position;
		Vector3 platformPosition = StopPosition;

		Context.Rig.position = Vector3.Lerp(startPosition, platformPosition, Time.deltaTime * Constants.TrainMoveSpeed);

	}
	private Vector3 GetRandomPlatform() => new Vector3[] { Context.MovePoints.Stop1Position, Context.MovePoints.Stop2Position }.GetRandomElement();
}