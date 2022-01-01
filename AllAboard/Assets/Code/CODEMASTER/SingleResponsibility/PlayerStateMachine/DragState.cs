using UnityEngine;
using Unity.Extentions;

public class DragState : IPlayerState
{
	private PlayerStateMachine Context;
	private Vector3 CameraPosition;


	public DragState(PlayerStateMachine context)
	{
		Context = context;
		CameraPosition = Camera.main.transform.position;
	}

	public void OnCollisionEnter(Collision collision) {}

	public void RunState()
	{
		var rig = Context.GetComponent<Rigidbody>();
		if (Input.GetMouseButton(0))
		{
			rig.useGravity = false;
			Vector3 touchPos = UserInteraction.ScreenTouchPosition;
			Vector3 direction = Vector3Ext.GetDirection(touchPos, CameraPosition);
			Vector3 perspective = touchPos + direction * 7;

			Context.transform.position = perspective;
		}

		else
		{
			rig.useGravity = true;
			Context.SetState(new GroundState(Context));
		}
	}
}