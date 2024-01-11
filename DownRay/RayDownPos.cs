using UnityEngine;

public class RayDownPos : MonoBehaviour
{
	private Ray ray;
	private RaycastHit hitData;

	public LayerMask layerMask;



	public float Y;

	private void Awake()
	{
		ray = new Ray();
	}

	public void RayToTarget(ref Ray _ray, string _targetTag)
	{
		ray = _ray;

		//Debug.Log("RayToTarget : " + ray.origin + "\t RayDirection : " + ray.direction+ "\t" + _targetTag + "\t" + layerMask.value);
		//Debug.DrawRay(ray.origin, ray.direction,Color.red,100.0f);

		if ( Physics.Raycast(ray, out hitData, 100,layerMask))
		{
			//Debug.Log("raycast : " + hitData.collider.gameObject.tag);
			if( hitData.collider.gameObject.tag == _targetTag)
			{
				Y = hitData.point.y;
			}
		}
	}

	public void  LineToTarget(ref Vector3 _start, ref Vector3 _end, string _targetTag)
	{
		Debug.DrawLine(_start, _end);

		if( Physics.Linecast(_start,_end,out hitData,layerMask))
		{
			if (hitData.collider.gameObject.tag != _targetTag) return;

			Y = hitData.point.y;
		}
	}
}