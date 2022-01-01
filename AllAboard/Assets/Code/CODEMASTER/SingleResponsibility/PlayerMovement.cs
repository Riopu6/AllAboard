using Unity.Extentions;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

	[SerializeField] float moveSpeed = 2f;
	private Rigidbody rig;
	private Selector selector;

	private void Start()
	{
		rig = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		Vector3 target = selector.KeepRandomPointOnArea(transform.position, 5f);
		Move(target);
	}

	private void Move(Vector3 target)
	{
		rig.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * moveSpeed);
		Debug.DrawLine(transform.position, target, Color.red);
	}

	private void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("MoveArea"))
		{
			selector = new Selector(collision.gameObject);
		}
	}
}