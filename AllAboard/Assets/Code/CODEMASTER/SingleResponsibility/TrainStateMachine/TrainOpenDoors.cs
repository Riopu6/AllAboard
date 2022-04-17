using Unity.Extentions;

public class TrainOpenDoors : ITrainState
{
	private readonly TrainStateMachine Context;
	private StateCollection collection;
	private Timer timer;

	public TrainOpenDoors(TrainStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}
	public void EnterState()
	{
		timer = new Timer(Context);
		Context.PlayAnimation(collection.AnimationName);
	}

	public void RunState()
	{
		timer.DelayForSecondsOnce(Constants.TrainStopTime, () =>
		{
			Context.SetState(Context.trainExit);
		});
	}
}