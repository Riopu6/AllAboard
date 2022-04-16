using UnityEngine;

public interface IPlayerState : IState
{
	void OnCollisionEnter(Collision collision);
	void OnTriggerEnter(Collider other);
}