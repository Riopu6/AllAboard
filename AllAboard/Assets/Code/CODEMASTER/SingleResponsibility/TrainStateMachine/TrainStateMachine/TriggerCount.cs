using System.Collections.Generic;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
	public Collider ObjectCollider { get; set; }
	public Collider LastEntered { get; set; }
	public Collider LastExited { get; set; }
	public readonly List<Collider> containedColliders = new List<Collider>();
	public int Count { get; private set; } = 0;

	public bool HasIncremented { get; private set; } = false;
	public bool HasDecremented { get; private set; } = false;

	private void Start() => ObjectCollider = GetComponent<Collider>();

	private void OnTriggerEnter(Collider other)
	{
		LastEntered = other;
		if (!containedColliders.Contains(other)) containedColliders.Add(other);

		if (other.CompareTag("Passenger"))
		{
			IncrementCount();
		}
	}

	private void OnTriggerExit(Collider other)
	{
		LastExited = other;
		containedColliders.Remove(other);

		if (other.CompareTag("Passenger"))
		{
			DecrementCount();
		}
	}
	public void ResetIncAndDec() => HasIncremented = HasDecremented = false;
	public bool IsEmpty() => Count <= 0;
	private void IncrementCount()
	{
		Count = Mathf.Clamp(Count + 1, 0, Count + 1);
		HasIncremented = true;
		HasDecremented = !HasIncremented;
	}

	private void DecrementCount()
	{
		Count = Mathf.Clamp(Count - 1, 0, Count);
		HasIncremented = false;
		HasDecremented = !HasIncremented;
	}
}