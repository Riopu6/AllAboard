using Unity.Extentions;
using UnityEngine;

public class TriggerCount : MonoBehaviour
{
	public int Count { get; private set; } = 0;

	public bool HasIncremented { get; private set; } = false;
	public bool HasDecremented { get; private set; } = false;

	public void IncrementCount()
	{
		Count = Mathf.Clamp(Count + 1, 0, Count + 1);
		HasIncremented = true;
		HasDecremented = !HasIncremented;
	}

	public void ResetIncAndDec() => HasIncremented = HasDecremented = false;

	public void DecrementCount()
	{
		Count = Mathf.Clamp(Count - 1, 0, Count);
		HasIncremented = false;
		HasDecremented = !HasIncremented;
	}

	public bool IsEmpty() => Count <= 0;

	private void OnTriggerEnter(Collider other)
	{
		if(other.CompareTag("Passenger"))
			IncrementCount();
	}

	private void OnTriggerExit(Collider other)
	{
		if(other.CompareTag("Passenger"))
			DecrementCount();
	}
}