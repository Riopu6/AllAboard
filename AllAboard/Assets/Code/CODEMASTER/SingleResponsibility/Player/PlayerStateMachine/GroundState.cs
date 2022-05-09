using Unity.Extentions;
using UnityEngine;

public class GroundState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private StateCollection collection;

	private Selector selector;

	public GroundState(PlayerStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}

	public void EnterState()
	{
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
			Context.SetState(Context.dragState);
		}
	}
	public void OnCollisionEnter(Collision collision)
	{
		Collider collider = collision.collider;

		if (collider.CompareTag("Ground")) selector = new Selector(collision.gameObject);
		if (collider.CompareTag("Return")) selector = new Selector(GameObject.FindGameObjectWithTag("Ground"));
		if (collider.CompareTag("Stairs")) selector = new Selector(Vector3.one);
	}

	public void OnTriggerEnter(Collider other) 
	{
		if (other.CompareTag("Platform")) Context.SetState(Context.trainState);
	}

	private void Move(Vector3 target)
	{
		Context.Rigidbody.position = Vector3.MoveTowards(Context.transform.position, target, Time.deltaTime * Constants.PassengerMovingSpeed);
	}

	private void Rotate(Vector3 target)
	{
		Vector3 targetDirection = Vector3Ext.GetDirectionNormalized(Context.transform.position, target).ExcludeAxis(SnapAxis.Y);
		Context.transform.rotation = Quaternion.Lerp(Context.transform.rotation, Quaternion.LookRotation(targetDirection), Time.deltaTime * Constants.PassengerRotationSpeed);
	}

}
