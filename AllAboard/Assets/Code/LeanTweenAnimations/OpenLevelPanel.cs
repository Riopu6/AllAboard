using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class OpenLevelPanel : MonoBehaviour
{
	public Image panel;

	public Text cityText;
	public Text levelText;
	public Text descriptionText;

	public Image levelPhoto;

	public Text starInf1;
	public Text starInf2;
	public Text starInf3;

	private string loadLevelScene;

	public void LoadLevelPanel(string levelToLoad)
	{
		LevelSO level = Resources.Load(levelToLoad) as LevelSO;

		cityText.text = level.cityTitle;
		levelText.text = level.levelTitle;
		descriptionText.text = level.levelDescription;

		levelPhoto.sprite = level.levelPicture;

		starInf1.text = level.starInfo_1;
		starInf2.text = level.starInfo_2;
		starInf3.text = level.starInfo_3;

		loadLevelScene = level.sceneToLoad;

		panel.gameObject.SetActive(true);
	}

	public void LoadTheLevel(string sceneName)
	{
		sceneName = loadLevelScene;
		SceneManager.LoadScene(sceneName);
	}
}
