using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider))]
public class PlayerStateMachine : MonoBehaviour
{
	public Animator Animator;

	#region PlayerCollections
	[SerializeField] private PlayerCollection groundedCollection;
	[SerializeField] private PlayerCollection dragCollection;
	#endregion

	private IPlayerState currentState;

	public GroundState groundState;
	public DragState dragState;

	private void Start()
	{
		groundState = new GroundState(this, groundedCollection);
		dragState = new DragState(this, dragCollection);

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