using System.Collections.Generic;
using UnityEngine;

public class InteractInfo : MonoBehaviour
{
	[Space]
	public TriggerCount otherTriggerCount;
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
		if (other.CompareTag("Passenger") && !asignRandomTarget.ContainsKey(other))
		{
			asignRandomTarget.Add(other, targets[otherTriggerCount.Count].position);
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if (otherTriggerCount.HasDecremented)
		{
			asignRandomTarget.Remove(other);
			otherTriggerCount.ResetIncAndDec();
		}
	}

	public Vector3 GetAssignedPosition(Collider col) => asignRandomTarget[col];

}
