using UnityEngine;

[ExecuteInEditMode]
public class CreatePassenger : MonoBehaviour
{
	public bool Applay = false;
	private void Update()
	{
		if (Applay)
		{
			gameObject.AddComponent<PlayerStateMachine>();
			GetComponent<Rigidbody>().freezeRotation = true;
			gameObject.tag = "Passenger";
			SetLayerRecursively(gameObject, 6);
			var coll = GetComponent<CapsuleCollider>();
			coll.center = new Vector3(0, -2, 0);
			coll.radius = 0.8f;
			coll.height = 5;
			DestroyImmediate(this);
		}
	}

	void SetLayerRecursively(GameObject obj, int newLayer)
	{
		if (obj != null)
		{
			obj.layer = newLayer;

			foreach (Transform child in obj.transform)
			{
				if (child != null)
				{
					SetLayerRecursively(child.gameObject, newLayer);
				}
			}
		}
	}
}
