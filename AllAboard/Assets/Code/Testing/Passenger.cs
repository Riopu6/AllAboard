using UnityEngine;
using Unity.Extentions;

public class Passenger : MonoBehaviour
{
	private void OnEnable()
	{
		UnityEventTest<int>.UnityEventSystem += ChangeColor;
		UnityEventTest<string>.UnityEventSystem += Jes;
	}

	private void Jes(string obj)
	{
		name = new string[] { "1", "2", "3" }.GetRandomElement();
	}

	private void ChangeColor(int a)
	{
		GetComponent<Renderer>().material.color = Random.ColorHSV();
	}

	private void OnDisable()
	{
		UnityEventTest<int>.UnityEventSystem += ChangeColor;
	}

	private void OnCollisionEnter(Collision collision)
	{
		UnityEventTest<int>.Run();
		UnityEventTest<string>.Run();
	}
}
