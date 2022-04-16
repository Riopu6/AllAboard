using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;

public class TrainState : IPlayerState
{
	public List<Vector3> TrainPathPoints;


	private readonly PlayerStateMachine Context;
	private readonly StateCollection collection;
	private int index = 0;


	public TrainState(PlayerStateMachine context, StateCollection trainCollection)
	{
		Context = context;
		this.collection = trainCollection;
	}

	public void EnterState() => Context.PlayAnimation(collection.AnimationName);

	public void RunState()
	{
		Move(GetTrainPoint());
		Rotate(GetTrainPoint());
	}

	private Vector3 GetTrainPoint()
	{
		if (Context.Rig.position.AproxMatch(TrainPathPoints[index]))
		{
			index = Mathf.Clamp(index + 1, 0, TrainPathPoints.Count);
		}

		return TrainPathPoints[index];
	}

	public void OnCollisionEnter(Collision collision) { }

	public void OnTriggerEnter(Collider other) { }

	private void Move(Vector3 target) => Context.Rig.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * Constraints.PassengerMovingSpeed);

	private void Rotate(Vector3 target)
	{
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * Constraints.PassengerRotationSpeed);
	}

}

