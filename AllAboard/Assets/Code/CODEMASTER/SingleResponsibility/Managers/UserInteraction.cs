using UnityEngine;

public class UserInteraction : MonoBehaviour
{

	public static Vector3 ScreenToWorldTouchPosition { get; private set; }
	public static Vector3 ScreenOriginPosition { get; private set; }
	public static Collider SelectedCollider { get; private set; }
	private static bool isSelectedCollider;

	[SerializeField] LayerMask ignoreRaycast;

	private Camera mainCamera;
	private void Start()
	{
		mainCamera = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

			ScreenOriginPosition = ray.origin;

			if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~ignoreRaycast)) // hit behind Passenger
			{
				ScreenToWorldTouchPosition = hitInfo.point;
				Debug.DrawLine(ray.origin, ScreenToWorldTouchPosition, Color.yellow);
			}

			if (Physics.Raycast(ray, out hitInfo)) // hit Passenger
			{
				if (hitInfo.collider.CompareTag("Passenger") && !isSelectedCollider)
				{
					SelectedCollider = hitInfo.collider;
					isSelectedCollider = true;
				}
			}
		}

		if (Input.GetMouseButtonUp(0))
		{
			SelectedCollider = null;
			isSelectedCollider = false;
		}
	}
}