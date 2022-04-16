using System.Collections.Generic;
using UnityEngine;

public class PlatformPath : MonoBehaviour
{
	[SerializeField] Transform ClosestPoint1;
	[SerializeField] Transform ClosestPoint2;
	[SerializeField] Transform Bridge1;
	[SerializeField] Transform Bridge2;
	[SerializeField] Transform Center;

	private void OnTriggerEnter(Collider other)
	{
		Vector3 ClosestPosition = Vector3.Distance(other.transform.position, ClosestPoint1.position) < Vector3.Distance(other.transform.position, ClosestPoint2.position) ? ClosestPoint1.position : ClosestPoint2.position;

		Vector3 BridgePosition = ClosestPosition == ClosestPoint1.position ? Bridge1.position : Bridge2.position;

		PlayerStateMachine playerStateMachine = other.GetComponent<PlayerStateMachine>();
		playerStateMachine.trainState.TrainPathPoints = new List<Vector3> { ClosestPosition, BridgePosition, Center.position };

	} 

}
