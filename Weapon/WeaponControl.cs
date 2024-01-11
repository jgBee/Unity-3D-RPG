using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

using static WeaponEnum;

public class WeaponControl : MonoBehaviour
{
	[Header("Inspector_Value")]
	public int colliderTypeIndex;


	[Header("CheckList")]
	[SerializeField] private int totalDamage;
	[SerializeField] private Collider collider;

	[SerializeField] private WEAPONTYPEINDEX index;
	[SerializeField] private byte Star;
	public int weaponDmg;

	[SerializeField]List<EnemyMove> enemyList;

	private float attackDelay;

	Coroutine attackCoroutine;
	private void Awake()
	{
		enemyList = new List<EnemyMove>();
	}

	public void Active(bool _active)
	{
		gameObject.SetActive(_active);
	}

	public void Slash(int _dmg, float _delay)
	{
		attackDelay = _delay;
		totalDamage = _dmg;
		attackCoroutine = StartCoroutine(AttackCoroutine());
	}

	public void StopCoroutine()
	{
		collider.enabled = false;
		if(attackCoroutine != null)
		StopCoroutine(attackCoroutine);
	}

	private IEnumerator AttackCoroutine()
	{
		yield return new WaitForSeconds(attackDelay);
		collider.enabled = true;
		if ( enemyList != null)
		{
			foreach (EnemyMove item in enemyList)
			{
				item.ImpactDamage(totalDamage);
			}
		}

		yield return new WaitForSeconds(0.1f);
		collider.enabled = false;
		yield break;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (collider == null) return;
		if (collider.enabled == false) return;

		switch (other.transform.tag)
		{
			case "Enemy":
				other.gameObject.GetComponent<EnemyMove>().ImpactDamage(totalDamage);
				break;
			case "Boss":
				other.gameObject.GetComponent<BossEnemy>().ImpactDamage(totalDamage);
				break;
		}
	}
}