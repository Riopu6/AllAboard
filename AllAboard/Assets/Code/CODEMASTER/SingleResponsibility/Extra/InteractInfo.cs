using System.Collections.Generic;
using UnityEngine;

public class InteractInfo : MonoBehaviour
{
	[Space]
	public TriggerCount otherTriggerCount;
	[SerializeField] int maxNumberOfPassengers;
	[Space]
	[Space]
	[Space]
	public Transform EntranceTransform;
	public List<Transform> targets;

	private Dictionary<Collider, Vector3> asignRandomTarget = new Dictionary<Collider, Vector3>();

	public Vector3 ColliderCenter { get; set; }

	public string RandomAnimationClipName { get; set; }
	public Vector3 EntrancePosition { get; set; }

	private void Start()
	{
		ColliderCenter = GetComponent<Collider>().transform.position;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (otherTriggerCount.Count < maxNumberOfPassengers)
		{
			if (other.CompareTag("Passenger") && !asignRandomTarget.ContainsKey(other))
			{
				asignRandomTarget.Add(other, targets[otherTriggerCount.Count].position);
			}
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (otherTriggerCount.HasDecremented)
		{
			asignRandomTarget.Remove(otherTriggerCount.LastExited);
			otherTriggerCount.ResetIncAndDec();
		}
	}

	public Vector3 GetAssignedPosition(Collider col)
	{
		if(asignRandomTarget.ContainsKey(col))
			return asignRandomTarget[col];
		return Vector3.negativeInfinity;
	}

	public int GetMaxNumberOfPassengers() => maxNumberOfPassengers;
	public bool isFull() => otherTriggerCount.Count >= maxNumberOfPassengers;
}
