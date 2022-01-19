using UnityEngine;
using Unity.Extentions;

public class DragState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private Vector3 CameraPosition;
	private PlayerCollection collection;
	public DragState(PlayerStateMachine context, PlayerCollection collection)
	{
		Context = context;
		CameraPosition = Camera.main.transform.position;
		this.collection = collection;
	}

	public void OnCollisionEnter(Collision collision) {}

	public void EnterState() {}

	public void RunState()
	{
		if (Input.GetMouseButton(0))
		{
			Vector3 touchPos = UserInteraction.ScreenTouchPosition;
			Vector3 direction = Vector3Ext.GetDirection(touchPos, CameraPosition);
			Vector3 perspective = touchPos + direction * 25;

			Context.transform.position = perspective;
		}

		else
		{
			Context.SetState(Context.groundState);
		}
	}
}