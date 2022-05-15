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
		collection = trainCollection;
	}

	public void EnterState() => Context.PlayAnimation(collection.AnimationName);

	public void RunState()
	{ 

		Move(GetTrainPoint());
		Rotate(GetTrainPoint());
		

		if (UserInteraction.SelectedCollider == Context.Collider)
		{
			Context.SetState(Context.dragState);
		}

	}

	private Vector3 GetTrainPoint()
	{
		if (Context.Rigidbody.position.AproxMatch(TrainPathPoints[index], Constants.NearATrain))
		{
			index = Mathf.Clamp(index + 1, 0, TrainPathPoints.Count - 1);
		}

		return TrainPathPoints[index];
	}

	public void OnCollisionEnter(Collision collision)
	{
		if((GetTrainPoint() - Context.transform.position).magnitude > Constants.TrainRange)
		{
			Context.SetState(Context.groundState);
			Context.groundState.SetSelector(collision.gameObject);
		}
	}

	public void OnTriggerEnter(Collider other) { if (other.CompareTag("TrainCenter")) { Context.DestroyObject(); } }

	private void Move(Vector3 target) => Context.Rigidbody.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * Constants.PassengerMovingSpeed);

	private void Rotate(Vector3 target)
	{
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * Constants.PassengerRotationSpeed);
	}

}

