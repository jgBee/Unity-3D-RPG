using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossAttack : MonoBehaviour
{
	public GameObject hitEffect;

	Vector3 moveDir;
	private float moveSpeed = 25;

	Coroutine bulletCoroutine;

	int dmg;


	public void StartBullet(int _dmg,Vector3 _startVec,Vector3 _endPos)
	{
		dmg = _dmg;
		transform.position = _startVec;

		moveDir = (_endPos - _startVec).normalized;
		bulletCoroutine = StartCoroutine(BulletUpdate());
	}
	IEnumerator BulletUpdate() {

		for (int i = 0; i < 50; i++)
		{
			transform.Translate(moveDir * moveSpeed* Time.deltaTime);
			yield return new WaitForSeconds(0.1f);
		}
		StopCoroutine();
	}

	public void StopCoroutine()
	{
		if (bulletCoroutine != null)
		{
			StopCoroutine(bulletCoroutine);
		}
		Destroy(gameObject);
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;

		other.GetComponent<MainGirlScrpit>().Impact(dmg);
		if (hitEffect)
			Destroy(Instantiate(hitEffect,other.transform.position,Quaternion.identity ), 0.5f);

		StopCoroutine();
	}
}
