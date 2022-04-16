using Unity.Extentions;
using UnityEngine;

public class TrainReset : ITrainState
{
	private readonly TrainStateMachine Context;

	public TrainReset(TrainStateMachine context) => Context = context;

	public void EnterState() => Context.GetComponent<SimpleTrainCustomizer>().Colorize();

	public void RunState()
	{
		new Timer(Context).DelayForSecondsOnce(5, () =>
		{
			Context.SetState(Context.trainEnter);
		}
		);
	}
}

