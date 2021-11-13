﻿using UnityEngine;
using Unity.Extentions;

public class Selector : MonoBehaviour
{
	public GameObject MoveArea { get; private set; }

	private static Vector3 keepRandomPoint;

	private void Start()
	{
		MoveArea = GameObject.FindGameObjectWithTag("MoveArea");
	}
	public static Vector3 GetRandomPoint(Vector3 currentPosition)
	{
		return currentPosition + RandomGetter.GetRandomVector3(-10, 10);
	}

	public static void KeepRandomPointUntilMatch(Vector3 currentPosition)
	{
		keepRandomPoint = GetRandomPoint(currentPosition);

	}

	//public bool IsPointValid(Vector3 point)
	//{

	//}
}