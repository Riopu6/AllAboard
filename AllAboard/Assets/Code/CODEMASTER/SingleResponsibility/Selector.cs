using Unity.Extentions;
using UnityEngine;

public class Selector : MonoBehaviour
{
	public GameObject MoveArea { get; private set; }

	#region PrivateFunctionVars
	private Bounds ren;
	private Vector3 keepRandomPoint = Vector3.zero;
	private bool changePosition = true; 
	#endregion

	private void Start()
	{
		MoveArea = GameObject.FindGameObjectWithTag("MoveArea");
		ren = MoveArea.GetComponent<Renderer>().bounds;
	}

	public static Vector3 GetRandomPoint(Vector3 currentPosition)
	{
		return currentPosition + RandomGetter.GetRandomVector3(-10, 10);
	}

	public Vector3 KeepRandomPointUntilMatch(Vector3 currentPosition)
	{
		if (changePosition)
		{
			var rndPos = GetRandomPoint(currentPosition);
			if (IsPointValid(ren, rndPos))
			{
				keepRandomPoint = rndPos;
				changePosition = !changePosition;
			}
		}

		if (keepRandomPoint.AproxMatch(currentPosition, 2f, SnapAxis.Y))
		{
			changePosition = !changePosition;
		}

		return keepRandomPoint;
	}

	private bool IsPointValid(Bounds moveAreaBounds, Vector3 point)
	{
		return moveAreaBounds.Contains(point);
	}
}