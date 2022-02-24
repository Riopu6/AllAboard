using UnityEngine;

public class Clock : MonoBehaviour
{
	[SerializeField] Transform minuteScale;
	[SerializeField] Transform hourScale;

	[SerializeField] float durationOfGameMinutes = 3f;

	private float hourTracker = 0f;
	private float minuteTracker = 0f;

	private void Update()
	{
		MoveClockScales(durationOfGameMinutes, ref hourTracker, ref minuteTracker);
	}
	private void MoveClockScales(float durationCicleMinutes, ref float hourTracker, ref float minuteTracker)
	{
		float minuteAngle = 360 / 12;
		float hourAngle = minuteAngle;

		float hourCicle = (durationCicleMinutes * 60) / 12f;
		float minuteCicle = hourCicle / 12f;

		hourTracker += Time.deltaTime;
		minuteTracker += Time.deltaTime;

		if (minuteTracker >= minuteCicle)
		{
			minuteScale.Rotate(Vector3.forward, minuteAngle);
			minuteTracker = 0f;
		}


		if (hourTracker >= hourCicle)
		{
			hourScale.Rotate(Vector3.forward, hourAngle);
			hourTracker = 0f;
		}

	}
}
