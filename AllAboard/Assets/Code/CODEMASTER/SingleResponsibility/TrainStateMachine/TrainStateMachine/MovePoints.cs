using UnityEngine;

[System.Serializable]
public struct MovePoints
{
	[SerializeField] Transform Start;
	[SerializeField] Transform Stop1;
	[SerializeField] Transform Stop2;
	[SerializeField] Transform End;

	public Vector3 StartPosition => Start.position;
	public Vector3 Stop1Position => Stop1.position;
	public Vector3 Stop2Position => Stop2.position;
	public Vector3 EndPosition => End.position;
}