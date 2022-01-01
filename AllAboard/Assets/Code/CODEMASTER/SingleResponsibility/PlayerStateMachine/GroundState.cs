using UnityEngine;

public class GroundState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private Rigidbody rig;

	private Selector selector;

	public GroundState(PlayerStateMachine context) => Context = context;

	public void RunState()
	{
		rig = Context.GetComponent<Rigidbody>();
		if(selector != null)
		{
			Move(selector.KeepRandomPointOnArea(Context.transform.position, 5f));
			Debug.DrawLine(Context.transform.position, selector.KeepRandomPointOnArea(Context.transform.position, 5f), Color.red);
		}
		if (UserInteraction.Collider == Context.gameObject.GetComponent<Collider>())
		{
			Context.SetState(new DragState(Context));
		}
	}
	public void OnCollisionEnter(Collision collision)
	{
		if (collision.collider.CompareTag("Ground"))
		{
			selector = new Selector(collision.gameObject);
		}
	}

	private void Move(Vector3 target)
	{
		float moveSpeed = 2f;
		rig.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * moveSpeed);
	}

}
