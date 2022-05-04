using UnityEngine;

public class TriggerCount : MonoBehaviour
{
	private int _inside = 0;

	public void IncrementCount() => _inside = Mathf.Clamp(_inside + 1, 0, _inside + 1);
	public void DecrementCount() => _inside = Mathf.Clamp(_inside - 1, 0, _inside);
	public bool IsEmpty() => _inside <= 0;

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