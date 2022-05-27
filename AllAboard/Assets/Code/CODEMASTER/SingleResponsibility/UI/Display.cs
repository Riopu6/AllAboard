using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public abstract class Display : MonoBehaviour
{
	private Transform toLookAt;
	public Image DisplayImage { get; set; }

	public virtual void Start()
	{
		toLookAt = Camera.main.gameObject.transform;
		DisplayImage = GetComponent<Image>();
	}

	public virtual void Update()
	{
		transform.LookAt(toLookAt);
	}

}
