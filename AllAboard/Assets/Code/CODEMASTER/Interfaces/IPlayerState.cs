using UnityEngine;

public interface IPlayerState : IState
{
	void OnCollisionEnter(Collision collision);
}