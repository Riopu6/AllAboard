using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SomeScript : MonoBehaviour
{
    public GameObject panelToClose;
    public GameObject mainMenu;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            panelToClose.gameObject.SetActive(false);
            mainMenu.gameObject.SetActive(true);
        }
    }
}
