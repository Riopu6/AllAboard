using UnityEngine;

public enum TypeOfAnim
{
	Scale,
	Move,
	Rotate,
	Alpha
}

public class GenAnimLT : MonoBehaviour
{
	public GameObject objectToAnimate;

	public TypeOfAnim animationType;
	public LeanTweenType easeType;

	public float duration;
	public float delay;
	public bool loop;
	public bool pingPong;

	public bool startPositionOffset;
	public Vector3 from;
	public Vector3 to;

	private LTDescr _tweenObject;

	public bool showOnEnable;
	public bool showOnDisable;

	public void OnEnable()
	{
		if (showOnEnable)
		{
			Show();
		}
	}

	public void Show()
	{
		HandleTween();
	}

	public void HandleTween()
	{
		if (objectToAnimate == null)
		{
			objectToAnimate = gameObject;
		}

		switch (animationType)
		{
			case TypeOfAnim.Move:
				Move();
				break;
			case TypeOfAnim.Scale:
				Scale();
				break;
			case TypeOfAnim.Rotate:
				Rotate();
				break;
			case TypeOfAnim.Alpha:
				Fade();
				break;
		}

		_tweenObject.setDelay(delay);
		_tweenObject.setEase(easeType);
		_tweenObject.setIgnoreTimeScale(true);

		if (loop)
		{
			_tweenObject.loopCount = int.MaxValue;
		}
		if (pingPong)
		{
			_tweenObject.setLoopPingPong();
		}


	}

	public void Fade()
	{
		if (gameObject.GetComponent<CanvasGroup>() == null)
		{
			gameObject.AddComponent<CanvasGroup>();
		}
		if (startPositionOffset)
		{
			objectToAnimate.GetComponent<CanvasGroup>().alpha = from.x;
		}
		_tweenObject = LeanTween.alphaCanvas(objectToAnimate.GetComponent<CanvasGroup>(), to.x, duration);
	}

	public void Move()
	{
		objectToAnimate.GetComponent<RectTransform>().anchoredPosition = from;

		_tweenObject = LeanTween.move(objectToAnimate.GetComponent<RectTransform>(), to, duration);
	}

	public void Scale()
	{
		if (startPositionOffset)
		{
			objectToAnimate.GetComponent<RectTransform>().localScale = from;
		}
		_tweenObject = LeanTween.scale(objectToAnimate, to, duration);
	}

	public void Rotate()
	{
		_tweenObject = LeanTween.rotate(objectToAnimate.GetComponent<RectTransform>(), to, duration);
	}

	void SwapDirection()
	{
		var temp = from;
		from = to;
		to = temp;
	}

	public void Disable()
	{
		SwapDirection();
		HandleTween();

		_tweenObject.setOnComplete(() =>
		{
			SwapDirection();
			gameObject.SetActive(false);
		});
	}

	public void ResetTween()
	{
		_tweenObject.reset();
	}
}
