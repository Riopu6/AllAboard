using UnityEngine;

public class InteractState : IPlayerState
{
	private readonly PlayerStateMachine Context;
	private Interactable interactWith;

	public InteractState(PlayerStateMachine context)
	{
		Context = context;
	}

	public void EnterState()
	{
	}

	public void OnCollisionEnter(Collision collision)
	{	
	}

	public void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Interactable"))
		{
			interactWith = other.GetComponent<Interactable>();
		}	
	}

	public void RunState()
	{
		var hasFinishedInteracting = interactWith.Interact(Context);

		if (hasFinishedInteracting)
		{
			Context.SetState(Context.groundState);
			Context.groundState.SetSelector(Vector3.one);
		}
	}
}