using Unity.Extentions;
using UnityEngine;

public class GroundState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private Rigidbody rig;
	private StateCollection collection;

	private Selector selector;

	public GroundState(PlayerStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}

	public void EnterState()
	{
		rig = Context.GetComponent<Rigidbody>();
		Context.PlayAnimation(collection.AnimationName);
	}

	public void RunState()
	{
		if (selector != null)
		{
			const float MarginOfError = 5f;
			Vector3 currentPosition = Context.transform.position.ReplaceY(selector.Target.y);
			Vector3 target = selector.KeepRandomPointOnArea(currentPosition, MarginOfError);
			Move(target);
			Rotate(target);
			Debug.DrawLine(currentPosition, selector.Target, Color.red);
		}

		if (UserInteraction.SelectedCollider == Context.GetComponent<Collider>())
		{
			Debug.Log(UserInteraction.SelectedCollider);
			Context.SetState(Context.dragState);
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
		float moveSpeed = 5f;
		rig.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * moveSpeed);
	}

	private void Rotate(Vector3 target)
	{
		float rotSpeed = 3f;
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * rotSpeed);
	}

}
