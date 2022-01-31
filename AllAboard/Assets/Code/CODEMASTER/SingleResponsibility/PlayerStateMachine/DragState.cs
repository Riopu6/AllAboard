using UnityEngine;
using Unity.Extentions;
using Unity;

public class DragState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private Vector3 CameraPosition;
	private PlayerCollection collection;
	private Rigidbody rig;
	public DragState(PlayerStateMachine context, PlayerCollection collection)
	{
		Context = context;
		CameraPosition = Camera.main.transform.position;
		this.collection = collection;
	}

	public void OnCollisionEnter(Collision collision) {}

	public void EnterState() 
	{
		rig = Context.GetComponent<Rigidbody>();
		SwitchGravity();
		Context.PlayAnimation(collection.animationName);
	}


	public void RunState()
	{
		if (Input.GetMouseButton(0))
		{
			DragPassenger();			
		}

		else
		{
			SwitchGravity();
			Context.SetState(Context.fallingState);
		}
	}

	private void DragPassenger()
	{
		Vector3 touchPos = UserInteraction.ScreenTouchPosition;
		Vector3 direction = Vector3Ext.GetDirection(touchPos, CameraPosition);
		Vector3 perspective = touchPos + direction * 25;

		Context.transform.position = perspective;
	}

	private void SwitchGravity() => rig.useGravity = !rig.useGravity;
}