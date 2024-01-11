using System.Collections;
using UnityEngine;

public class EnemyWeaponCollider : MonoBehaviour
{
	public GameObject PrefabHitEffect;
	public GameObject PrefabStartEffect;

	private int dmg;
	private bool bAttack;
	//TrailRenderer trailEffect;
	[SerializeField] private Collider collider;

	private float attackDelay;

	private Coroutine attackCoroutine;

	private void Awake()
	{
		collider = GetComponent<Collider>();

	}
	public void Use(int _dmg, float _attackDelay)
	{
		attackDelay = _attackDelay;
		dmg = _dmg;
		attackCoroutine = StartCoroutine(Swing());
	}

	public void StopCoroutine()
	{
		collider.enabled = false;
		if(attackCoroutine != null)
			StopCoroutine(attackCoroutine);
	}

	private IEnumerator Swing()
	{
		//if (PrefabStartEffect)
		//	Destroy(Instantiate(PrefabStartEffect, transform.position, Quaternion.identity), 1f);

		yield return new WaitForSeconds(attackDelay);
		collider.enabled = true;
		bAttack = true;

		yield return new WaitForSeconds(0.3f);
		collider.enabled = false;
		bAttack = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag != "Player") return;

		if (bAttack == true)
		{
			other.GetComponent<MainGirlScrpit>().Impact(dmg);
		//	if (PrefabHitEffect)
		//		Destroy(Instantiate(PrefabHitEffect, transform.position, Quaternion.identity), 1f);
		}
	}
}