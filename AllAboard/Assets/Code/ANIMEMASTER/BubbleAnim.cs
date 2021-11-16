using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BubbleAnim : MonoBehaviour
{
    public GameObject requestBubble;
    public float duration;
    public float alphaDuration;

    public void BubbleOpenAnim()
    {
        GameObject[] currRequests = new GameObject[3];
        
        foreach(GameObject request in currRequests)
        {
            Instantiate(request, requestBubble.transform);
            request.GetComponent<RectTransform>().localPosition = Vector3.zero;
            request.GetComponent<RectTransform>().localScale = Vector3.one;
            LeanTween.alpha(request, 1f, alphaDuration);
        }

        requestBubble.GetComponent<RectTransform>().localScale = Vector3.zero;
        requestBubble.gameObject.SetActive(true);
        LeanTween.scale(requestBubble, Vector3.one, duration);

    }

    public void BubbleCloseAnim()
    {
        for(int i = requestBubble.transform.childCount-1; i >= 0; i--)
        {
            var req = requestBubble.transform.GetChild(i);
            LeanTween.alpha(req.gameObject, 0f, alphaDuration);
            Destroy(req.gameObject);
        }

        LeanTween.scale(requestBubble, Vector3.zero, duration);
        requestBubble.gameObject.SetActive(false);
    }

}
