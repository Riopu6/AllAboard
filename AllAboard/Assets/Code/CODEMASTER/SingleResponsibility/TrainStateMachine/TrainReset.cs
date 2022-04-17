using Unity.Extentions;
using UnityEngine;

public class TrainReset : ITrainState
{
	private readonly TrainStateMachine Context;
	private Timer timer;
	public TrainReset(TrainStateMachine context) => Context = context;

	public void EnterState()
	{
		Context.GetComponent<SimpleTrainCustomizer>().Colorize();
		timer = new Timer(Context);
	}

	public void RunState()
	{
		timer.DelayForSecondsOnce(Constants.TrainResetTime, () =>
		{
			Context.SetState(Context.trainEnter);
		}
		);
	}
}

