using System.Collections.Generic;
using UnityEngine;

public class SomeScript : MonoBehaviour
{
    public GameObject panelToClose;
    public GameObject mainMenu;
    public List<RectTransform> buttons;
    public RectTransform continueText;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && panelToClose.gameObject.activeSelf==true)
        {
            LeanTween.scale(panelToClose, Vector3.zero, 0.5f).setEaseInBack();
            panelToClose.gameObject.SetActive(false);
            mainMenu.transform.localScale = Vector3.zero;
            mainMenu.gameObject.SetActive(true);
            LeanTween.scale(mainMenu, Vector3.one, 1f).setEaseOutCubic().setDelay(0.5f);

            foreach (RectTransform b in buttons)
            {
                LeanTween.alpha(b, 1f, 3f);
            }
        }

        if (Input.GetMouseButtonDown(1) && panelToClose.gameObject.activeSelf == false)
        {     
            mainMenu.gameObject.SetActive(false);
            panelToClose.gameObject.SetActive(true);
            LeanTween.scale(panelToClose, Vector3.one, 0.5f);
            LeanTween.alpha(continueText, 0f, 1f).setLoopPingPong(-1);
        }
    }
}
