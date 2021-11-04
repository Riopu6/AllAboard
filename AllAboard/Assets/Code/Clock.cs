using UnityEngine;

public class Clock : MonoBehaviour
{
	[SerializeField] Transform smallScale;
	[SerializeField] Transform largeScale;

	[SerializeField] float durationOfGameMinutes = 3f;

	private float timeElapsed;

	private void Update()
	{
		MoveClockScales(durationOfGameMinutes, ref timeElapsed);
	}
	private void MoveClockScales(float durationCicleMinutes, ref float timeTracker)
	{
		float smallScaleAngle = 360 / (durationCicleMinutes * 60);
		float largeScaleAngle = smallScaleAngle * 60;

		largeScale.Rotate(Vector3.forward, Mathf.LerpAngle(0, largeScaleAngle, Time.deltaTime));

		timeTracker += Time.deltaTime;

		if (timeTracker >= 1f)
		{
			smallScale.Rotate(Vector3.forward, smallScaleAngle);
			timeTracker = 0;
		}

	}
}
