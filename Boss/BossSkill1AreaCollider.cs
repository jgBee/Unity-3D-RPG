using System.Collections;
using UnityEngine;

public class BossSkill1AreaCollider : MonoBehaviour
{
	[SerializeField] private Collider collider;
	[SerializeField] private GameObject hitEffect;

	private int tick;
	private float tickDelayTime;

	private Coroutine coroutine;

	private int totalDamage;

	public void StartSkill(int _dmg, int _tick, float _tickDelayTime)
	{
		totalDamage = _dmg;
		tickDelayTime = _tickDelayTime;
		tick = _tick;

		coroutine = StartCoroutine(ColliderOnOff());
	}

	private IEnumerator ColliderOnOff()
	{
		for (int i = 0; i < tick; i++)
		{
			collider.enabled = true;
			yield return new WaitForSeconds(0.1f);

			collider.enabled = false;
			yield return new WaitForSeconds(tickDelayTime - 0.1f);
		}
		StopCoroutine();
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other == null) return;

		switch (other.gameObject.tag)
		{
			case "Player":
				other.GetComponent<MainGirlScrpit>().Impact(totalDamage);
				if (hitEffect)
					Destroy(Instantiate(hitEffect, other.gameObject.transform.position, Quaternion.identity),0.5f);
				break;
			default:
				break;
		}
	}


	public void StopCoroutine()
	{
		StopCoroutine(coroutine);
		Destroy(gameObject);

	}
}