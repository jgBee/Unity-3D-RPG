using UnityEngine;
using TMPro;

public class EnemyMove : MonoBehaviour
{
	private enum ANISTATE
	{
		IdleIn,
		IdleUpdate,
		IdleOut,

		WalkIn,
		WalkUpdate,
		WalkOut,

		RunIn,
		RunUpdate,
		RunOut,

		AttackIn,
		AttackUpdate,
		AttackOut,

		Impact,

		Return,

		DieIn,
		DieUpdate,
		DieOut,

		Respawn,
	};

	[Header("Test")]
	[SerializeField] private EnemyFind findSphere;

	[Header("Inspector")]
	[SerializeField] private EnemyData data;
	[SerializeField] private EnemyBar bar;
	[SerializeField] private GameObject PrefabItem;
	[SerializeField] private RayDownPos rayPos;	

	[SerializeField]private float fMoveRadius;
	[SerializeField] private float fMinIdleWait; 
	[SerializeField] private float fMaxIdleWait;
	[SerializeField] private float walkSpeed,runSpeed;

	[SerializeField] private GameObject discover;
	[SerializeField] private EnemyReadCollider weapon;

	[SerializeField] private Animator ani;

	[SerializeField]private MainGirlScrpit mainGirl;


	[Header("CheckList")]
	[SerializeField]private ANISTATE state;
	[SerializeField]private Vector3 startPos;
	[SerializeField] private Vector3 endPos;
	[SerializeField] private Vector3 moveDir;

	[SerializeField] private float currentTime, stateMaxTime;
	[SerializeField] private float finalSpeed;

	[SerializeField]private GameObject targetObject;

	private Ray ray;
	private RaycastHit hitData;


	private float attackAniDelay = 3.4f;



	private void Awake()
	{
		if (data == null) GetComponent<EnemyData>();
		ray = new Ray();
	}

	private void Start()
	{
		endPos = startPos = transform.position;
		Init();
		data.TestChange();
		findSphere.transform.localScale = new Vector3(fMoveRadius, 1, fMoveRadius);

	
	}
	public void Init()
	{
		GetComponent<Collider>().enabled = true;

		currentTime = 0.0f;
		ani.Play("idle1", 0, 0.0f);

		data.TestChange();
		transform.position = startPos;

		state = ANISTATE.IdleIn;
		gameObject.tag = "Enemy";

	}

	private void Update()
	{



		if(Input.GetKeyDown(KeyCode.R))
		{
			Init(); 
			return;
		}

		targetObject = findSphere.Target;

		switch (state)
		{
			case ANISTATE.IdleIn:
				currentTime = 0;
				stateMaxTime = Random.Range(fMinIdleWait, fMaxIdleWait);
				state = ANISTATE.IdleUpdate;
				discover.SetActive(false);

				ani.Play("idle1", 0, 0.0f);
				break;
			case ANISTATE.IdleUpdate:
				if( targetObject != null)
				{
					state = ANISTATE.RunIn;
					break;
				}

				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.IdleOut;
					break;
				}
				else
					currentTime += Time.deltaTime;	

				break;
			case ANISTATE.IdleOut:
				if (data.HPPercent > 0.5f)
				{
					if (UnityEngine.Random.Range(0, 2) == 0)
						state = ANISTATE.IdleIn;
					else
						state = ANISTATE.WalkIn;
				}
				else
				{
					state = ANISTATE.RunIn;
				}
				break;
			case ANISTATE.WalkIn:
				if( targetObject != null)
				{
					state = ANISTATE.RunIn;
					return;
				}
				ani.Play("walk1", 0, 0.0f);

				finalSpeed = walkSpeed;
				ResetEndPos();
				state = ANISTATE.WalkUpdate;

				discover.SetActive(false);

				transform.LookAt(endPos);
				break;
			case ANISTATE.WalkUpdate:
				if( Vector3.Distance(transform.position,startPos) >= fMoveRadius/2)
				{
					finalSpeed = runSpeed;
					targetObject = null;
					transform.LookAt(startPos);
					state = ANISTATE.Return;
					break;
				}

				if(targetObject)
				{
					state = ANISTATE.RunIn;
					break;
				}
				else
				{

					if (Vector3.Distance(endPos, transform.position) <= 1.0f)
					{
						state = ANISTATE.WalkOut;
						break;
					}
					else
					{
						transform.position = Vector3.MoveTowards(transform.position,endPos ,finalSpeed * Time.deltaTime);
					}
				}
				break;
			case ANISTATE.WalkOut:
					state = ANISTATE.IdleIn;
				break;
			case ANISTATE.RunIn:
				if( targetObject == null)
				{
					state = ANISTATE.WalkIn;
					return;
				}
				discover.SetActive(true);

				ani.Play("walk2", 0, 0.0f);

				finalSpeed = runSpeed;
				Vector3 pos = targetObject.transform.position;
				pos.y = transform.position.y;
				transform.LookAt(pos);
				state = ANISTATE.RunUpdate;
				break;
			case ANISTATE.RunUpdate:
				if (Vector3.Distance(transform.position, startPos) >= fMoveRadius / 2)
				{
					finalSpeed = runSpeed;
					targetObject = null;

					transform.LookAt(startPos);
					state = ANISTATE.Return;
					break;
				}

				if (targetObject == null)
				{
					state = ANISTATE.WalkIn;
					break;
				}
				else
				{

					if (Vector3.Distance(targetObject.transform.position, transform.position) <= 1.25f)
					{
						state = ANISTATE.AttackIn;
						break;
					}
					else
					{
						Vector3 targetPos = targetObject.transform.position;
						targetPos.y = transform.position.y;
						transform.position = Vector3.MoveTowards(transform.position, targetPos, finalSpeed * Time.deltaTime);
					}
				}
				break;
			case ANISTATE.RunOut:

				break;
			case ANISTATE.AttackIn:
				ani.Play("OneAttack", 0, 0.0f);
				discover.SetActive(true);
				state = ANISTATE.AttackUpdate;
				stateMaxTime = 1.0f;
				currentTime = 0.0f;

				weapon.Use(15, 0.4f);
				SoundManager.Instance.PlayEnemySoundEffect(0);

				break;
			case ANISTATE.AttackUpdate:
				if (currentTime >= stateMaxTime)
				{
					currentTime = 0.0f;
					stateMaxTime = attackAniDelay;
					state = ANISTATE.AttackOut;

				}
				else
					currentTime += Time.deltaTime;

				break;
			case ANISTATE.AttackOut:
				if (targetObject == null)
					state = ANISTATE.Return;

				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.RunIn;
				}
				else
					currentTime += Time.deltaTime;


				break;
			case ANISTATE.Impact:
				if( currentTime >= stateMaxTime)
				{
					state = ANISTATE.IdleIn;
					break;
				}
				else 
					currentTime += Time.deltaTime;

				break;
			case ANISTATE.Return:

				discover.SetActive(false);
				if (Vector3.Distance(transform.position, startPos ) <= 1.0f)
				{
					state = ANISTATE.IdleIn;
					return;
				}

				transform.position = Vector3.MoveTowards(transform.position, startPos, finalSpeed * Time.deltaTime);
				break;
			case ANISTATE.DieIn:
				currentTime = 0.0f;

				stateMaxTime = 2.0f;
				state = ANISTATE.DieUpdate;

				if (data.GetIndex == EnemyEnum.ENEMYCHARINDEX.Char_N_SpearMan)
				{
					QuestManager.Instance.AddValue(1,1);
				}


				if (PrefabItem != null)
				{
					int itemCount = Random.Range(1, 3);
					for (int i = 0; i < itemCount; i++)
					{
						Instantiate(PrefabItem, transform.position + (Vector3.up * 3), Quaternion.identity);
					}
				}
			
				break;
			case ANISTATE.DieUpdate:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.DieOut;
					stateMaxTime = 2.0f;
					currentTime = 0.0f;
					break;
				}
				else
				{
					currentTime += Time.deltaTime;
				}
				break;

			case ANISTATE.DieOut:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.Respawn;
					stateMaxTime = Random.Range(10.0f, 15.0f);
					currentTime = 0;
					//Destroy(gameObject);
					break;
				}
				else
				{
					currentTime += Time.deltaTime;
				}
				break;
			case ANISTATE.Respawn:
				if (currentTime >= stateMaxTime)
				{
					Init();
					break;
				}
				else
				{
					currentTime += Time.deltaTime;
				}

				break;
		}

		{
			ray.origin = transform.position + Vector3.up;
			ray.direction = transform.position - (Vector3.up * 100);
			rayPos.RayToTarget(ref ray, "Terrain");

			Vector3 pos = transform.position;
			pos.y = rayPos.Y;
			transform.position = pos;

		}
	}


	private void ResetEndPos()
	{
		Vector3 addPos = Vector3.zero;
		while (true)
		{
			addPos.x = Random.Range(-1.0f,1.0f) * fMoveRadius/2;
			addPos.z = Random.Range(-1.0f,1.0f) * fMoveRadius/2;
			

			if (Vector3.Distance(startPos + addPos, startPos) <= fMoveRadius )
			{
				endPos = transform.position + addPos;
				moveDir = (endPos - transform.position).normalized;


				return;
			}
			transform.LookAt(endPos);
		}
	}

	public void ImpactDamage(int _dmg)
	{
		if (data == null) return;

		if (data.IsDead == true) return;

		weapon.StopCoroutine();
		if (data.Impact(_dmg))
		{
			if (mainGirl == null)
			{
				Debug.Log("mainGirlNull");
			}
			else
			{
				mainGirl.GetExpGold(data.GiveExp,data.GiveGold);
			}

			gameObject.tag = "EnemyDie";
			if( UnityEngine.Random.Range(0,2) == 0)
			{
				ani.Play("death1", 0, 0.0f);
			}
			else
				ani.Play("death2", 0, 0.0f);


			state = ANISTATE.DieIn;
		
			discover.SetActive(false);

			bar.OnBar(_dmg,false,data.HPPercent);

			SoundManager.Instance.PlayEnemySoundEffect(2);
		}
		else
		{
		
			ani.Play("Hit", 0, 0.0f);

			bar.OnBar(_dmg,false,data.HPPercent);

			if (state == ANISTATE.AttackIn || currentTime > 0.0f)
			{
				state = ANISTATE.AttackUpdate;
			}
			else
			{
				state = ANISTATE.Impact;
			}
			discover.SetActive(true);
			SoundManager.Instance.PlayEnemySoundEffect(1);


		}
	}
}