using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour
{
    public GameObject panelToClose;
    public GameObject mainMenu;
    public GameObject txt;
    private void Update()
    {
        if (Input.GetMouseButtonDown(1) && panelToClose.gameObject.activeSelf == false)
        {     
            mainMenu.gameObject.SetActive(false);
            panelToClose.gameObject.SetActive(true);
            LeanTween.scale(panelToClose, Vector3.one, 0.5f);
        }
    }
}
