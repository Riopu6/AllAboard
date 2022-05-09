using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public class TrainOpenDoors : ITrainState
{
	private readonly TrainStateMachine Context;
	private readonly List<GameObject> linkedObjects;
	private StateCollection collection;

	private TriggerCount triggerCount;
	private float timePassed;
	private float sum;

	public TrainOpenDoors(TrainStateMachine context, StateCollection collection, List<GameObject> linkedObjects)
	{
		Context = context;
		this.collection = collection;
		this.linkedObjects = linkedObjects;
	}
	public void EnterState()
	{
		Context.PlayAnimation(collection.AnimationName);
		triggerCount = ClosestObject().GetComponent<TriggerCount>();
	}
	public void RunState()
	{
		timePassed += Time.deltaTime;

		sum += Time.deltaTime;

		if (triggerCount.HasIncremented)
		{
			timePassed = Mathf.Clamp(timePassed - 1, -1, 6);
			triggerCount.ResetIncAndDec();
		}
		
		if (timePassed >= Constants.TrainStopTime)
		{

			if (triggerCount.IsEmpty())
			{
				timePassed = 0;
				sum = 0;
				Context.SetState(Context.trainExit);
			}
		}

	}
	private GameObject ClosestObject() => linkedObjects.OrderBy(x => Vector3.Distance(x.transform.position, Context.transform.position))
		.FirstOrDefault();

}