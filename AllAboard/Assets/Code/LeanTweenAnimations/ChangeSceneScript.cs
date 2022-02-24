using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
	public void SceneLoading(int levelIndex)
	{
		SceneManager.LoadScene(levelIndex);
	}

	public void GameExit()
	{
		Application.Quit();
	}
}
