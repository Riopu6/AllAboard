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
	}


}
