using UnityEngine;

public class Billboarding : MonoBehaviour
{
	Vector3 cameraDir;

	private void Update()
	{
		cameraDir = Camera.main.transform.forward;
		cameraDir.y = 0;

		transform.rotation = Quaternion.LookRotation(cameraDir);
	}
}