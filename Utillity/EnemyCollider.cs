using System.Collections;
using UnityEngine;

public class EnemyCollider : MonoBehaviour
{
	public GameObject PrefabHitEffect;

	private int dmg;
	//TrailRenderer trailEffect;
	[SerializeField] private Collider collider;

	private float attackDelay;

	Coroutine coroutine;

	private void Awake()
	{
		collider = GetComponent<Collider>();
	}
	public void Use(int _dmg, float _attackDelay)
	{
		attackDelay = _attackDelay;
		dmg = _dmg;
		coroutine = StartCoroutine(Swing());
	}

	public void StopCoroutine()
	{
		if (coroutine != null) StopCoroutine(coroutine);
	}

	private IEnumerator Swing()
	{
		yield return new WaitForSeconds(attackDelay);
		collider.enabled = true;
	
		yield return new WaitForSeconds(0.1f);
		collider.enabled = false;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == null) return;
		switch (other.gameObject.tag)
		{
			case "Enemy":
				other.GetComponent<EnemyMove>().ImpactDamage(dmg);
				if (PrefabHitEffect)
					Destroy(Instantiate(PrefabHitEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
				break;
			case "Boss":
				other.GetComponent<BossEnemy>().ImpactDamage(dmg);
				if (PrefabHitEffect)
					Destroy(Instantiate(PrefabHitEffect, other.gameObject.transform.position, Quaternion.identity), 0.5f);
				break;
			default:
				return;
		}
	}
}