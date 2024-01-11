using UnityEngine;

public class NPCCollider : MonoBehaviour
{
	public GameObject target;

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;
		target = other.gameObject;

	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != "Player") return;
		target = null;
	}


}