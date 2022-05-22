using UnityEngine;

public class DestroyArea : MonoBehaviour
{
	private void OnCollisionEnter(Collision collision) => Destroy(collision.gameObject);

	private void OnTriggerEnter(Collider other) => Destroy(other.gameObject);
}
