using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Unity
{
	namespace Extentions
	{
		public static class RandomGetter
		{
			public static Vector3 GetRandomVector3(float min = float.MinValue, float max = float.MaxValue) => new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
			public static T GetRandomElement<T>(this IEnumerable<T> list) => list.Count() == 0 ? default : list.ElementAt(Random.Range(0, list.Count()));
		}


		public static class MathExt
		{
			public static bool AproxMatch(this Vector3 vector, Vector3 compare, float marginOfError = 0.1f) => Vector3.Distance(vector, compare) <= marginOfError;
			public static bool AproxMatch(this Vector2 vector, Vector2 compare, float marginOfError = 0.1f) => Vector2.Distance(vector, compare) <= marginOfError;
		}

		public static class Vector3Ext
		{
			public static Vector3 ReplaceX(this Vector3 vector, float value) { vector.x = value; return vector; }
			public static Vector3 ReplaceY(this Vector3 vector, float value) { vector.y = value; return vector; }
			public static Vector3 ReplaceZ(this Vector3 vector, float value) { vector.z = value; return vector; }
			public static Vector3 AddX(this Transform transform, float value)
			{
				var tranPos = transform.position;
				tranPos.x += value;
				return tranPos;
			}
			public static Vector3 AddY(this Transform transform, float value)
			{
				var tranPos = transform.position;
				tranPos.y += value;
				return tranPos;
			}
			public static Vector3 AddZ(this Transform transform, float value)
			{
				var tranPos = transform.position;
				tranPos.z += value;
				return tranPos;
			}
			public static Vector3 ExcludeAxis(this Vector3 vector, SnapAxis excludeAxis)
			{
				switch (excludeAxis)
				{
					case SnapAxis.None:
						return vector;
					case SnapAxis.X:
						return new Vector3(0, vector.y, vector.z);
					case SnapAxis.Y:
						return new Vector3(vector.x, 0, vector.z);
					case SnapAxis.Z:
						return new Vector3(vector.x, vector.y, 0);
					case SnapAxis.All:
						return Vector3.zero;
				}
				return vector;
			}
			public static Vector3 GetDirectionNormalized(Vector3 origin, Vector3 des) => (des - origin).normalized;

			public static Vector3 GetDirection(Vector3 origin, Vector3 des) => (des - origin);


		}

		public static class Vector2Ext
		{
			public static Vector2 ReplaceX(this Vector2 vector, float value)
			{
				vector.x = value;
				return vector;
			}

			public static Vector2 ReplaceY(this Vector2 vector, float value)
			{
				vector.y = value;
				return vector;
			}

			public static Vector2 ExcludeAxis(this Vector2 vector, SnapAxis excludeAxis)
			{
				switch (excludeAxis)
				{
					case SnapAxis.None:
						return vector;
					case SnapAxis.X:
						return new Vector2(0, vector.y);
					case SnapAxis.Y:
						return new Vector2(vector.x, 0);
					case SnapAxis.All:
						return Vector2.zero;
				}
				return vector;
			}
		}

		public static class ConvertExt
		{
			public static Vector2 ToVector2(this Vector3 vector) => vector;
		}

		public static class DebugExt
		{
			public static void Print(this object toPrint, Object context = null) => Debug.Log(toPrint, context);
			public static void Print(this object toPrint, string seperator, params object[] extraInfo) => Debug.Log(toPrint + seperator + string.Join(seperator, extraInfo));
		}

		public class Timer
		{
			private static MonoBehaviour monoInstance;
			private float timeIsUp = 0;

			public Timer(MonoBehaviour monoBehaviour)
			{
				monoInstance = monoBehaviour;
			}
			public void DelayForSecondsOnce(float seconds, System.Action action) => monoInstance.StartCoroutine(WaitForSeconds(seconds, action));

			public void DelayUntilOnce(System.Func<bool> func, System.Action action) => monoInstance.StartCoroutine(WaitUntil(func, action));

			public void DelayForSecondsRepeat(float seconds, System.Action action)
			{
				if (timeIsUp >= seconds)
				{
					action();
					timeIsUp = 0;
				}

				timeIsUp += Time.deltaTime;

			}

			#region IEnumerators
			private IEnumerator WaitForSeconds(float seconds, System.Action action)
			{
				yield return new WaitForSeconds(seconds);
				action();
			}
			private IEnumerator WaitUntil(System.Func<bool> funk, System.Action action)
			{
				yield return new WaitUntil(funk);
				action();
			}
			#endregion
		}
	}
}