using Unity.Extentions;
using UnityEngine;

public class TrainReset : ITrainState
{
	private TrainStateMachine Context;
	private Vector3 StartPosition;

	public TrainReset(TrainStateMachine context)
	{
		Context = context;
	}

	public void EnterState()
	{
			Context.GetComponent<SimpleTrainCustomizer>().Colorize();
	}

	public void RunState()
	{
		new Timer(Context).DelayForSeconds(5, () =>
		{
			Context.SetState(Context.trainEnter);
		}
		);
	}
}

