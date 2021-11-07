using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeSceneScript : MonoBehaviour
{
    public void SceneLoading(int levelIndex)
    {
        SceneManager.LoadScene(levelIndex);
    }
}
