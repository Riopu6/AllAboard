using UnityEngine;

public class GameStats : MonoBehaviour
{
	public static int AllPlayerPoints;
	public int Points { get; private set; } = 0;
	public void AddPoint()
	{
		AllPlayerPoints++;
		Points++;
	}
}
