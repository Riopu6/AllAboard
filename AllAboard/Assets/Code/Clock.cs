using System.Collections;
using UnityEngine;

public class Clock : MonoBehaviour
{
	[SerializeField] Transform smallScale;
	[SerializeField] Transform largeScale;

	private void Start()
	{
		StartCoroutine(MoveClockScales());
	}
	private IEnumerator MoveClockScales()
	{
		while (true)
		{
			yield return new WaitForSeconds(0.5f);
			largeScale.Rotate(Vector3.forward, 6f); 
			smallScale.Rotate(Vector3.forward, 0.5f);
		}
	}
}
