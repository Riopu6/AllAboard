using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AllRequests : MonoBehaviour
{
	[SerializeField]  List<Sprite> allPossibleRequests;

	public static AllRequests instance;

	private void Start()
	{
		if (instance == null) instance = this;
	}
	public static List<Sprite> Get() => instance.allPossibleRequests;
}