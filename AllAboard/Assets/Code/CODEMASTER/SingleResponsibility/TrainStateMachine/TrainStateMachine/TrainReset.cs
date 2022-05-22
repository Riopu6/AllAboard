public class TrainReset : ITrainState
{
	private readonly TrainStateMachine Context;
	public TrainReset(TrainStateMachine context) => Context = context;

	public void EnterState()
	{
		Context.GetComponent<Customizer>().Colorize();
	}

	public void RunState()
	{
		Context.SetState(Context.trainEnter);
	}
}

