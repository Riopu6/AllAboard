using UnityEngine;
using UnityEngine.UI;

public class PausePanelInfo : MonoBehaviour
{
	public Image panel;

	public Text levelTitle;

	public Text starInf1;
	public Text starInf2;
	public Text starInf3;

	public void LoadPausePanel(string levelToLoad)
	{
		LevelSO level = Resources.Load(levelToLoad) as LevelSO;

		levelTitle.text = level.levelTitle;

		starInf1.text = level.starInfo_1;
		starInf2.text = level.starInfo_2;
		starInf3.text = level.starInfo_3;

		panel.gameObject.SetActive(true);
	}
}
