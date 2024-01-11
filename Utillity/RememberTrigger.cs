using UnityEngine;

public class EnemyFind : MonoBehaviour
{
	public GameObject Target;
	public string targetTag;


	private void Awake()
	{
		Target = null;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != targetTag) return;
		
		Target = other.gameObject;
		//Debug.Log(Target.name + "\t" + Target.tag + "targetTag Collider Enter");
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.tag != targetTag) return;
		
		//Debug.Log( Target.name + "\t" + Target.tag + "targetTag Collider Exit");
		Target = null;
	}
}