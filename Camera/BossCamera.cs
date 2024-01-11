using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossCamera : MonoBehaviour
{
	public Transform target;
	public Transform playerFollow;

	private void Start()
	{
		transform.parent = playerFollow;
		transform.position = new Vector3(0, 0, 0);
	}

	private void Update()
	{
		if (target == null) return;

		transform.LookAt(target.position);
	}
}