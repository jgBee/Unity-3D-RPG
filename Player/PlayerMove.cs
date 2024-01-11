using UnityEngine;

public class PlayerMove : MonoBehaviour
{
	private Vector3 moveDir;

	private float finalSpeed;


	public void SetSpeed(float _speed)
	{
		finalSpeed = _speed;
	}

	public void Move(ref Vector3 dir)
	{
		if (dir == Vector3.zero) return;

		moveDir = dir;

		Ray ray = new Ray(transform.position, moveDir);

		RaycastHit hitData;

		if (Physics.Raycast(ray, out hitData, 0.5f) == true)
		{
			if (hitData.collider.transform.tag == "Wall") return;
		}

		transform.rotation = Quaternion.LookRotation(moveDir);
		//회전한 후 전진방향으로 이동
		transform.Translate(Vector3.forward * Time.deltaTime * finalSpeed);
	}


	private void LateUpdate()
	{
		//gameObject.SetActive(false);
		//Vector3 start = transform.position;

		//start.y += 50.0f;

		//Ray ray = new Ray(start,-Vector3.up);

		//RaycastHit hitData;
		//if( Physics.Raycast(ray, out hitData, 100))
		//{
		//	if( hitData.collider.tag == "Terrain")
		//	{
		//		transform.position = new Vector3(transform.position.x, hitData.collider.transform.position.y, transform.position.z);
		//	}

		//}
		//gameObject.SetActive(true);
	}
}