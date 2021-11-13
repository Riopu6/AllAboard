using UnityEngine;

public class Movement : MonoBehaviour
{
	private float speed = 2f;
	private Rigidbody rig;

	private void Start()
	{
		rig = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Move(Selector.GetRandomPoint(transform.position));
	}

	private void Move(Vector3 target)
	{
		Vector3 velocity = rig.velocity;
		rig.AddForce(target - new Vector3(velocity.x, 0, velocity.z), ForceMode.VelocityChange);
	}
}