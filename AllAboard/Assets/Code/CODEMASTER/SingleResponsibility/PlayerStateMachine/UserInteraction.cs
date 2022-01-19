using UnityEngine;

public class UserInteraction : MonoBehaviour
{

	public static Vector3 ScreenTouchPosition { get; private set; }
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
		print(SelectedCollider);
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
				if (hitInfo.collider.CompareTag("Passenger") && !isSelectedCollider)
				{
					SelectedCollider = hitInfo.collider;
					isSelectedCollider = true;
				}
				Debug.DrawLine(mainCamera.transform.position, SelectedCollider.transform.position, Color.red);
			}
		}
		if (Input.GetMouseButtonUp(0))
		{
			SelectedCollider = null;
			isSelectedCollider = false;
		}
	}
}