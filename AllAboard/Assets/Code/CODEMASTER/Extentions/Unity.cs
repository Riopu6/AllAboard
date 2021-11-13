using UnityEngine;

namespace Unity
{
	namespace Extentions
	{
		public class RandomGetter
		{
			public static Vector3 GetRandomVector3(float min = 0, float max = 100)
			{
				return new Vector3(Random.Range(min, max), Random.Range(min, max), Random.Range(min, max));
			}
		}
		public static class Ext
		{
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
			public static Vector3 ReplaceAxis(this Vector3 vector, SnapAxis axis,float value)
			{
				switch (axis)
				{
					case SnapAxis.None:
						return vector;
					case SnapAxis.X:
						return new Vector3(value, vector.y, vector.z);
					case SnapAxis.Y:
						return new Vector3(vector.x, value, vector.z);
					case SnapAxis.Z:
						return new Vector3(vector.x, vector.y, value);
					case SnapAxis.All:
						return Vector3.zero;
				}
				return vector;
			}
		}
	}
}