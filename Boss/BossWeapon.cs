using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossWeapon : MonoBehaviour
{
	public GameObject PrefabBullet;
	public void CreateBullet(int _dmg,Vector3 _startPos,Vector3 _endPos)
	{
		GameObject obj = Instantiate(PrefabBullet, Vector3.zero, Quaternion.identity);

		_endPos.y = _startPos.y;
		obj.GetComponent<BossAttack>().StartBullet(_dmg,_startPos, _endPos);
	}

	//public GameObject PrefabBullet;
	//public GameObject PrefabStartEffect;

	//private int dmg;
	//private bool bAttack;
	////TrailRenderer trailEffect;
	//private float attackDelay;

	//private Coroutine attackCoroutine;

	//public void Use(int _dmg, float _attackDelay)
	//{
	//	attackDelay = _attackDelay;
	//	dmg = _dmg;
	//	attackCoroutine = StartCoroutine(Swing());
	//}

	//public void StopCoroutine()
	//{
	//	if (attackCoroutine != null)
	//		StopCoroutine(attackCoroutine);
	//}

	//private IEnumerator Swing()
	//{
	//	//if (PrefabStartEffect)
	//	//	Destroy(Instantiate(PrefabStartEffect, transform.position, Quaternion.identity), 1f);

	//	yield return new WaitForSeconds(attackDelay);
	//	bAttack = true;

	//	yield return new WaitForSeconds(0.3f);
	//	bAttack = false;
	//}

	//private void OnTriggerEnter(Collider other)
	//{
	//	if (other.gameObject.tag != "Player") return;

	//	if (bAttack == true)
	//	{
	//		other.GetComponent<MainGirlScrpit>().Impact(dmg);
	//		//	if (PrefabHitEffect)
	//		//		Destroy(Instantiate(PrefabHitEffect, transform.position, Quaternion.identity), 1f);
	//	}
	//}
}
