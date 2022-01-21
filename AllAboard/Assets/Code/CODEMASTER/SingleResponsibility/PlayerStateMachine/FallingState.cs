using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingState : IPlayerState
{
	private PlayerStateMachine Context;
	private PlayerCollection collection;

	public FallingState(PlayerStateMachine context, PlayerCollection fallingCollection)
	{
		Context = context;
		this.collection = fallingCollection;
	}

	public void EnterState() 
	{
		Context.PlayAnimation(collection.animationName);	
	}
	public void RunState()
	{
		
	}

	public void OnCollisionEnter(Collision collision) { Context.SetState(Context.groundState); Context.groundState.OnCollisionEnter(collision); }

}
