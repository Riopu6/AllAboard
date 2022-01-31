using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour
{
	public Animator Animator;

	#region PlayerCollections
	[SerializeField] PlayerCollection groundedCollection;
	[SerializeField] PlayerCollection dragCollection;
	[SerializeField] PlayerCollection fallingCollection;
	#endregion

	private IPlayerState currentState;

	public GroundState groundState;
	public DragState dragState;
	public FallingState fallingState;

	private void Start()
	{
		groundState = new GroundState(this, groundedCollection);
		dragState = new DragState(this, dragCollection);
		fallingState = new FallingState(this, fallingCollection);

		SetState(groundState);
	}

	private void FixedUpdate() => currentState?.RunState();
	public void SetState(IPlayerState state)
	{
		currentState = state;
		currentState.EnterState();
	}

	public void PlayAnimation(string animation)
	{
		Animator.Play(animation);
	}

	private void OnCollisionEnter(Collision collision) => currentState.OnCollisionEnter(collision);
}