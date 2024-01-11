using UnityEngine;

public class BossZoneEvent : MonoBehaviour
{
	[Header("Warning UI")]

	[Header("Enemy")]
	[SerializeField] GameObject EnemyGroupPrefab;

	[Header("DontMoveWall")]
	[SerializeField] GameObject[] wallList;
	
	public Transform enemyCreatePoisition;

	[SerializeField] private Collider col;
	[SerializeField] private Rigidbody rigid;	

	private GameObject enemyGroup;


	private bool bUpdate = false;
	private void Start()
	{
		Vector3 pos = enemyCreatePoisition.transform.position;
		pos.y = 10;
		enemyGroup = Instantiate(EnemyGroupPrefab, pos, Quaternion.Euler(0,0,0));
		enemyGroup.transform.parent = enemyCreatePoisition.transform;
		enemyGroup.gameObject.SetActive(false);

		if (wallList != null)
		{
			foreach (GameObject item in wallList)
			{
				item.SetActive(false);
			}
		}
	}

	public void Init(bool _clear)
	{
		enemyGroup.SetActive(_clear);

		if (wallList != null)
		{
			foreach (GameObject item in wallList)
			{
				item.SetActive(_clear);
			}
		}
		bUpdate = true;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag != "Player") return;

		other.gameObject.GetComponent<MainGirlScrpit>().InFightZone(true);

		enemyGroup.GetComponent<BossEnemy>().SetTarget(other.gameObject);

		UIManager.Instance.BossBar(true);
		UIManager.Instance.Warning(true, 2.0f);

		Init(true);
		UIManager.Instance.PlayMode(2);
		SoundManager.Instance.PlayBGM(2);
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag != "Player") return;
		
		Init(false);
		UIManager.Instance.BossBar(false);
		UIManager.Instance.PlayMode(0);
		SoundManager.Instance.PlayBGM(0);

	}
}