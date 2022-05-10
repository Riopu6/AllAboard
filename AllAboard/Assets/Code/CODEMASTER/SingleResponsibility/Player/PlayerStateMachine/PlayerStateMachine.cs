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
	public InteractState interactState;

	public Rigidbody Rigidbody { get; private set; }
	public Collider Collider { get; private set; }


	#region Unity Callbacks

	private void Start()
	{
		groundState = new GroundState(this, groundedCollection);
		dragState = new DragState(this, dragCollection);
		fallingState = new FallingState(this, fallingCollection);
		trainState = new TrainState(this, trainCollection);
		interactState = new InteractState(this);

		SetState(groundState);

		Rigidbody = GetComponent<Rigidbody>();
		Collider = GetComponent<Collider>();
	}
	private void FixedUpdate() => currentState?.RunState();
	private void OnCollisionEnter(Collision collision) => currentState.OnCollisionEnter(collision);
	private void OnTriggerEnter(Collider other) => currentState.OnTriggerEnter(other);

	private void OnDisable() => PassengerSpawner.OnDestroyedPassenger.LocalInvoke();

	#endregion

	#region Player State Machine

	public void SetState(IPlayerState state)
	{
		currentState = state;
		currentState.EnterState();
	}
	public void PlayAnimation(string animation) => Animator.Play(animation);
	public void DestroyObject() => Destroy(gameObject);

	#endregion

}