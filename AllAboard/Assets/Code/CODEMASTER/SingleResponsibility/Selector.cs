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
	public static Vector3 GetRandomPointFrom(Vector3 currentPosition, float min, float max) => currentPosition + RandomGetter.GetRandomVector3(min, max);
	public static Vector3 GetRandomPointFrom(Vector3 currentPosition, float range) => currentPosition + RandomGetter.GetRandomVector3(-range, range);

	public Vector3 KeepRandomPointOnArea(Vector3 currentPosition, float marginOfError = 0.1f)
	{
		if (changePosition)
		{
			var rndPos = GetRandomPointFrom(currentPosition, 20).ExcludeAxis(SnapAxis.Y);

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

	private bool IsPointValid(Bounds moveAreaBounds, Vector3 point) => moveAreaBounds.Contains(point);
	#endregion
}