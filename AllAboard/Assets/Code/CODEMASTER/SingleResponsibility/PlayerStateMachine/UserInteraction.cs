using UnityEngine;

public class UserInteraction : MonoBehaviour
{

	public static Vector3 ScreenTouchPosition { get; private set; }
	public static Collider SelectedCollider { get; private set; }

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
			Ray ray2 = ray;
			if (Physics.Raycast(ray, out RaycastHit hitInfo, Mathf.Infinity, ~ignoreRaycast))
			{
				ScreenTouchPosition = hitInfo.point;
				Debug.DrawLine(mainCamera.transform.position, ScreenTouchPosition, Color.yellow);
			}
			if (Physics.Raycast(ray2, out RaycastHit hitInfo2))
			{
				SelectedCollider = hitInfo2.collider;
				Debug.DrawLine(mainCamera.transform.position, SelectedCollider.transform.position, Color.red);
			}
		}
		else
		{
			SelectedCollider = null;
		}
	}
}