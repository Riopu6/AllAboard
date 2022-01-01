using UnityEngine;

public class UserInteraction : MonoBehaviour
{
	private Camera mainCamera;
	[SerializeField] LayerMask ignoreRaycast;

	public static Vector3 ScreenTouchPosition { get; private set; }
	public static Collider Collider { get; private set; }

	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~ignoreRaycast))
			{
				ScreenTouchPosition = hitInfo.point;
				Debug.DrawLine(mainCamera.transform.position, ScreenTouchPosition, Color.yellow);
			}
			if (Physics.Raycast(ray, out hitInfo))
			{
				Collider = hitInfo.collider;
			}
		}
		else
		{
			Collider = null;
		}
	}
}