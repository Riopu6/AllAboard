using System;
using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public class TrainOpenDoors : ITrainState
{
	private readonly TrainStateMachine Context;
	private StateCollection collection;
	private readonly List<GameObject> linkedObjects;
	private Timer timer;
	private TriggerCount triggerCount;

	public TrainOpenDoors(TrainStateMachine context, StateCollection collection, List<GameObject> linkedObjects)
	{
		Context = context;
		this.collection = collection;
		this.linkedObjects = linkedObjects;
	}
	public void EnterState()
	{
		timer = new Timer(Context);
		Context.PlayAnimation(collection.AnimationName);
		triggerCount = ClosestObject().GetComponent<TriggerCount>();
	}

	private GameObject ClosestObject() => linkedObjects.OrderBy(x => x.transform.position.AproxMatch(Context.transform.position)).FirstOrDefault();

	public void RunState()
	{
		timer.DelayForSecondsOnce(Constants.TrainStopTime, () =>
		{
			triggerCount.IsEmpty().Print();
			timer.DelayUntilOnce(
				() => triggerCount.IsEmpty(), 
				() => Context.SetState(Context.trainExit));
		});
	}
}