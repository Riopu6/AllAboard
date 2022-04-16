using UnityEngine;

[RequireComponent(typeof(Rigidbody), typeof(CapsuleCollider), typeof(Animator))]
public class PlayerStateMachine : MonoBehaviour
{
	public Animator Animator;

	#region StateCollections
	[SerializeField] StateCollection groundedCollection;
	[SerializeField] StateCollection dragCollection;
	[SerializeField] StateCollection fallingCollection;
	[SerializeField] StateCollection trainCollection;
	#endregion

	private IPlayerState currentState;

	public GroundState groundState;
	public DragState dragState;
	public FallingState fallingState;
	public TrainState trainState;

	public Rigidbody Rig { get; private set; }

	private void Start()
	{
		groundState = new GroundState(this, groundedCollection);
		dragState = new DragState(this, dragCollection);
		fallingState = new FallingState(this, fallingCollection);
		trainState = new TrainState(this, trainCollection);

		SetState(groundState);

		Rig = GetComponent<Rigidbody>();
	}

	private void FixedUpdate() => currentState?.RunState();

	public void SetState(IPlayerState state)
	{
		currentState = state;
		currentState.EnterState();
	}

	public void PlayAnimation(string animation) => Animator.Play(animation);

	private void OnCollisionEnter(Collision collision) => currentState.OnCollisionEnter(collision);

	private void OnTriggerEnter(Collider other) => currentState.OnTriggerEnter(other);
}