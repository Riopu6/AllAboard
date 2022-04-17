using System;
using System.Collections.Generic;
using Unity.Extentions;
using UnityEngine;

public class PassengerSpawner : MonoBehaviour
{
	[SerializeField] List<GameObject> Prefabs = new List<GameObject>();
	[SerializeField] List<Transform> Spawns = new List<Transform>();

	private readonly int maxCount = Constants.MaxPassengers;
	private int currentCount = 0;
	private Timer timer;

	private void OnEnable() => GameEvent.GlobalEvent += DecrementCurrentCount;

	private void Start() => timer = new Timer(this);

	private void Update()
	{
		if (currentCount < maxCount)
		{
			timer.DelayForSecondsRepeat(1, () => { Instantiate(Prefabs.GetRandomElement(), Spawns.GetRandomElement().position, Quaternion.identity); currentCount++; });
		}
	}

	private void OnDisable() => GameEvent.GlobalEvent -= DecrementCurrentCount;

	private void DecrementCurrentCount() => currentCount--;
}
