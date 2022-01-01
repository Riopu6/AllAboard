using Unity.Extentions;
using UnityEngine;

public class Selector
{
	#region PrivateFunctionVars
	private Bounds bounds;
	private Vector3 keepRandomPoint = Vector3.zero;
	private bool changePosition = true; 
	#endregion

	public Selector(GameObject MoveArea)
	{
		bounds = MoveArea.GetComponent<Renderer>().bounds;
	}

	#region Functions
	public static Vector3 GetRandomPoint(Vector3 currentPosition)
	{
		return currentPosition + RandomGetter.GetRandomVector3(-10, 10);
	}

	public Vector3 KeepRandomPointOnArea(Vector3 currentPosition, float marginOfError = 0.1f)
	{
		if (changePosition)
		{
			var rndPos = GetRandomPoint(currentPosition);
			if (IsPointValid(bounds, rndPos))
			{
				keepRandomPoint = rndPos;
				changePosition = !changePosition;
			}
		}

		if (keepRandomPoint.AproxMatch(currentPosition, marginOfError))
		{
			changePosition = !changePosition;
		}

		return keepRandomPoint;
	}

	private bool IsPointValid(Bounds moveAreaBounds, Vector3 point)
	{
		return moveAreaBounds.Contains(point);
	} 
	#endregion
}