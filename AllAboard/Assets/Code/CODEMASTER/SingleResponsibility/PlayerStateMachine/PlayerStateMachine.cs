using UnityEngine;

public class PlayerStateMachine : MonoBehaviour
{
	private IPlayerState currentState;

	private void Start()
	{
		currentState = new GroundState(this);
	}

	private void FixedUpdate() => currentState?.RunState();

	public void SetState(IPlayerState state) => currentState = state;

	private void OnCollisionEnter(Collision collision)
	{
		currentState.OnCollisionEnter(collision);
	}
}