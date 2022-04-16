using UnityEngine;

public class FallingState : IPlayerState
{
	private PlayerStateMachine Context;
	private StateCollection collection;

	public FallingState(PlayerStateMachine context, StateCollection fallingCollection)
	{
		Context = context;
		collection = fallingCollection;
	}

	public void EnterState()
	{
		Context.PlayAnimation(collection.AnimationName);
	}
	public void RunState() {}

	public void OnCollisionEnter(Collision collision) { Context.SetState(Context.groundState); Context.groundState.OnCollisionEnter(collision); }

}
