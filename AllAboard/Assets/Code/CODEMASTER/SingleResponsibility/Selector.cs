using System.Collections.Generic;
using System.Linq;
using Unity.Extentions;
using UnityEngine;

public class Selector
{
	#region PrivateFunctionVars
	private Bounds bounds;
	private Vector3 keepRandomPoint = Vector3.zero;
	private bool changePosition = true;
	#endregion
	public Vector3 Target { get; private set; }
	public List<Vector3> TrainPathPoints { get; private set; }

	private List<Collider> avoidInteractables = new List<Collider>();

	public Selector() => SetInteractables();


	public Selector(GameObject MoveArea)
	{
		SetInteractables();
		bounds = MoveArea.GetComponent<Collider>().bounds;
	}

	public Selector(Vector3 Point)
	{
		SetInteractables();
		Target = Point;
	}

	#region Functions
	public static Vector3 GetRandomPointFrom(Vector3 currentPosition, float min, float max) => currentPosition + RandomGetter.GetRandomVector3(min, max);

	public static Vector3 GetRandomPointFrom(Vector3 currentPosition, float radius) => currentPosition + RandomGetter.GetRandomVector3(-radius, radius);

	public Vector3 KeepRandomPointOnArea(Vector3 currentPosition, float marginOfError = 0.1f)
	{
		if (changePosition)
		{
			var rndPos = GetRandomPointFrom(currentPosition, 20).ExcludeAxis(SnapAxis.Y);
			if (IsPointValid(bounds, rndPos))
			{
				keepRandomPoint = rndPos;
				Target = keepRandomPoint;
				changePosition = !changePosition;
			}
		}

		if (keepRandomPoint.AproxMatch(currentPosition, marginOfError))
		{
			changePosition = !changePosition;
		}

		return keepRandomPoint;
	}

	private void SetInteractables() => avoidInteractables = GameObject.FindGameObjectsWithTag("Interactable").Select(x => x.GetComponent<Collider>()).ToList();

	private bool IsPointValid(Bounds moveAreaBounds, Vector3 point)
	{
		bool containedInColliders = false;
		foreach (var coll in avoidInteractables)
		{
			containedInColliders = containedInColliders || coll.bounds.Contains(point);
		}
		return moveAreaBounds.Contains(point) && !containedInColliders;
	}
	#endregion
}