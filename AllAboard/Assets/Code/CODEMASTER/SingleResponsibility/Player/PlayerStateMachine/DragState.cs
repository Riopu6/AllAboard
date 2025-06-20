﻿using Unity.Extentions;
using UnityEngine;

public class DragState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private StateCollection collection;
	
	public DragState(PlayerStateMachine context, StateCollection collection)
	{
		Context = context;
		this.collection = collection;
	}

	public void OnCollisionEnter(Collision collision) { }

	public void OnTriggerEnter(Collider other) { }

	public void EnterState()
	{
		SwitchGravity();
		Context.PlayAnimation(collection.AnimationName);
	}


	public void RunState()
	{
		Vector3 touchPos = UserInteraction.ScreenToWorldTouchPosition;
		Vector3 offset = Vector3Ext.GetDirectionNormalized(touchPos, UserInteraction.ScreenOriginPosition) * 20;
		Vector3 perspective;

		if (Input.GetMouseButton(0)) // Drag Passenger
		{
			perspective = touchPos + offset;

			Context.transform.position = perspective;
		}

		else // Falling / Letting Go
		{
			Vector3 moveByX = Vector3Ext.GetDirection(Context.transform.position.ExcludeAxis(SnapAxis.Y), touchPos);
			Vector3 moveByY = Context.transform.position.ExcludeAxis(SnapAxis.X).ExcludeAxis(SnapAxis.Z);

			offset = Context.GetComponent<Collider>().bounds.size;

			Context.transform.position += moveByX - moveByY + offset;
			
			SwitchGravity();
			Context.SetState(Context.fallingState);
		}
	}

	private void SwitchGravity() => Context.Rigidbody.useGravity = !Context.Rigidbody.useGravity;
}