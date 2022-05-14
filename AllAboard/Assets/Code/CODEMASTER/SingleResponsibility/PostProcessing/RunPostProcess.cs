using UnityEngine;

[ExecuteInEditMode]
public class RunPostProcess : MonoBehaviour
{
	public Material executeMaterial;

	private void OnRenderImage(RenderTexture source, RenderTexture destination)
	{
		Graphics.Blit(source, destination, executeMaterial);
	}
}
