using UnityEngine;

public class UnityEventTest<T> : MonoBehaviour
{
	public static event System.Action<T> UnityEventSystem;

	public static void Run()
	{
		UnityEventSystem?.Invoke(default);
	}

}
