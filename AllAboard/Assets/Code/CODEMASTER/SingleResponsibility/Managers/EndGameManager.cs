using System.Collections;
using UnityEngine;

public class EndGameManager : MonoBehaviour
{
	[SerializeField] GameObject switchGO;
	private IEnumerator Start()
	{
		yield return new WaitForSecondsRealtime(3*60);
		Time.timeScale = 0;
		switchGO.SetActive(true);
	}
}
