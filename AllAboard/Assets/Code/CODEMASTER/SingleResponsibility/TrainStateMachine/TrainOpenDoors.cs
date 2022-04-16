using Unity.Extentions;

public class TrainOpenDoors : ITrainState
{
	private readonly TrainStateMachine Context;
	private StateCollection collection;

	public TrainOpenDoors(TrainStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}
	public void EnterState()
	{
		Context.PlayAnimation(collection.AnimationName);
	}

	public void RunState()
	{
		Timer timer = new Timer(Context);
		timer.DelayForSecondsOnce(10, () =>
		{
			Context.SetState(Context.trainExit);
		});
	}
}