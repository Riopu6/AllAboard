using UnityEngine;

public class TrainStateMachine : MonoBehaviour
{
	public Animator Animator;
	public MovePoints MovePoints;
	public Rigidbody Rig { get; set; }

	#region StateCollections
	[SerializeField] StateCollection TrainEnterCollection;
	[SerializeField] StateCollection TrainOpenDoorsCollection;
	[SerializeField] StateCollection TrainExitCollection;
	#endregion

	private ITrainState currentState;

	public TrainEnter trainEnter;
	public TrainOpenDoors trainOpenDoors;
	public TrainExit trainExit;

	private void Start()
	{
		trainEnter = new TrainEnter(this, TrainEnterCollection);
		trainOpenDoors = new TrainOpenDoors(this, TrainOpenDoorsCollection);
		trainExit = new TrainExit(this, TrainExitCollection);

		SetState(trainEnter);

		Rig = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		currentState?.RunState();
	}

	public void SetState(ITrainState state)
	{
		currentState = state;
		currentState.EnterState();
	}

	public void PlayAnimation(string animation)
	{
		Animator.Play(animation);
	}

	public void DestroyTrain()
	{
		Destroy(gameObject);
	}
}
