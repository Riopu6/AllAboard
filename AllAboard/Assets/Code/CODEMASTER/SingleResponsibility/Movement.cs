using Unity.Extentions;
using UnityEngine;

public class Movement : MonoBehaviour
{
	private const float moveSpeed = 4f;
	private Rigidbody rig;
	private Selector selector;

	private void Start()
	{
		selector = gameObject.AddComponent<Selector>().GetComponent<Selector>();
		rig = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 target = selector.KeepRandomPointUntilMatch(transform.position).ExcludeAxis(SnapAxis.Y);
		Move(target);
	}

	private void Move(Vector3 target)
	{
		rig.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
		Debug.DrawLine(transform.position, target, Color.red);
	}
}