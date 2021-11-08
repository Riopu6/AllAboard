using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[CreateAssetMenu(fileName = "New Level", menuName = "Create New Level")]
public class LevelSO : ScriptableObject
{
    public string levelTitle;
    public string levelDescription;
    public string cityTitle;

    public string sceneToLoad;

    public Sprite levelPicture;

    public string starInfo_1;
    public string starInfo_2;
    public string starInfo_3;
}
