using TMPro;
using UnityEngine;

public class BossEnemy : MonoBehaviour
{
	private enum ANISTATE
	{
		IdleIn,
		IdleUpdate,
		IdleOut,

		FrontIn,
		FrontUpdate,
		FrontOut,

		BackIn,
		BackUpdate,
		BackOut,

		AttackIn,
		AttackUpdate,
		AttackOut,

		Skill1In,
		Skill1Update,
		Skill1Out,

		Skill2In,
		Skill2Update,
		Skill2Out,

		DieIn,
		DieUpdate,
		DieOut,

		GroggyIn,
		GroggyUpdate,
		GroggyOut,

		Return,

	};


	[Header("Inspector")]

	[SerializeField] private EnemyEnum.ENEMYCHARINDEX index;

	[SerializeField] private Transform bulletPos;
	[SerializeField] private GameObject prefabSkill1;
	[SerializeField] private GameObject prefabSkill2;
	

	[SerializeField] private EnemyData data;
	[SerializeField] private GameObject PrefabItem;
	[SerializeField] private RayDownPos rayPos;
	[SerializeField] private BossBar bar; 

	[SerializeField] private float fMinIdleWait;
	[SerializeField] private float fMaxIdleWait;
	[SerializeField] private float walkSpeed, runSpeed;

	[SerializeField] private GameObject bulletParent;
	[SerializeField] private BossWeapon weapon;

	[SerializeField] private Transform modelTransform;	
	[SerializeField] private Animator ani;

	[SerializeField] private GameObject emoji;
	[SerializeField] private GameObject oura;

	[Header("CheckList")]
	[SerializeField] private ANISTATE state;
	[SerializeField] private Vector3 startPos;
	[SerializeField] private Vector3 endPos;
	[SerializeField] private Vector3 moveDir;

	[SerializeField] private int attackCount;
	[SerializeField] private float currentTime, stateMaxTime;
	[SerializeField] private float finalSpeed;

	[SerializeField] private GameObject targetObject;
	private Vector3 pos;
	private Ray ray;
	private RaycastHit hitData;

	[SerializeField] private float attackDelay;
	[SerializeField] private float skill1Delay;
	[SerializeField] private float skill2Delay;

	private bool bGroggy = false;

	[SerializeField] private int bossAttackDmg;
	[SerializeField] private int bossSkill1Dmg;
	[SerializeField] private int bossSkill2Dmg;

	public void SetTarget(GameObject _obj) { targetObject = _obj; }


	private float Distance => Vector3.Distance(targetObject.transform.position, transform.position);

	private bool DistanceCheck (float x, float y) => ((Distance >= x) && (Distance <= y)) ;




	private void Awake()
	{
		if (data == null) GetComponent<EnemyData>();
		ray = new Ray();
	}

	private void Start()
	{
		endPos = startPos = transform.position;
		Init();

	}

	public void Init()
	{
		attackCount = 0;
		GetComponent<Collider>().enabled = true;

		currentTime = 0.0f;
		ani.Play("Idle", 0, 0.0f);

		data.ChangeEnemy(index,1);
		transform.position = startPos;

		state = ANISTATE.IdleIn;


	}

	private void Update()
	{
		if (UIManager.Instance.bUIOn) return;

		if(!( state == ANISTATE.DieIn || state == ANISTATE.DieUpdate || state == ANISTATE.DieOut
			|| state == ANISTATE.GroggyIn || state == ANISTATE.GroggyUpdate|| state == ANISTATE.GroggyOut))
		{
			if (targetObject)
			{
				pos = targetObject.transform.position;
				pos.y = transform.position.y;

				modelTransform.LookAt(pos);
			}
		}


		switch (state)
		{
			case ANISTATE.IdleIn:
				state = ANISTATE.IdleUpdate;
				ani.Play("Idle", 0, 0.0f);

				currentTime = 0.0f;
				stateMaxTime = Random.Range(fMinIdleWait, fMaxIdleWait);

				break;
			case ANISTATE.IdleUpdate:

				if (DistanceCheck(0, 2) == true)
				{
					state = ANISTATE.AttackIn;
					break;
				}
				else
				{
					if (currentTime >= stateMaxTime)
					{
						switch (Random.Range(0, 5))
						{
							case 0:
							case 1:
							case 2:
								state = ANISTATE.FrontIn; break;
							case 3:
							case 4:
								state = ANISTATE.AttackIn; break;
						}
						break;
					}
					else
						currentTime += Time.deltaTime;
				}
				
				break;
			case ANISTATE.IdleOut:
				break;
			case ANISTATE.FrontIn:
				state = ANISTATE.FrontUpdate;

				if (bGroggy) finalSpeed = walkSpeed / 2;
				else finalSpeed = walkSpeed;

				switch (Random.Range(0,3))
				{
					case 0: moveDir = modelTransform.forward; break;
					case 1: moveDir = -modelTransform.right; break;
					case 2: moveDir = modelTransform.right; break;
				}

				currentTime = 0.0f;
				stateMaxTime = 1.0f;
				ani.Play("Front",0,0);
				break;
			case ANISTATE.FrontUpdate:
				if (DistanceCheck(0, 2) == true)
				{
					state = ANISTATE.AttackIn; 
					break;
				}
				else
				{
					if (currentTime >= stateMaxTime)
					{
						switch (Random.Range(0, 2))
						{
							case 0: state = ANISTATE.IdleIn; break;
							case 1: state = ANISTATE.AttackIn; break;
						}
						break;
					}
					else
						currentTime += Time.deltaTime;

					pos = moveDir * finalSpeed * Time.deltaTime;

					ray.origin = transform.position + pos;
					ray.direction = modelTransform.forward;

					if( Physics.Raycast(ray, out hitData, 1.0f))
					{
						if(hitData.collider.tag == "Wall")
						{
							state = ANISTATE.IdleIn;
							break;
						}
					}

					transform.position += pos;
				}
				break;
			case ANISTATE.FrontOut:
				break;
			case ANISTATE.BackIn:
				state = ANISTATE.BackUpdate;
				if (bGroggy) finalSpeed = runSpeed / 2;
				else finalSpeed = runSpeed;
				currentTime = 0.0f;
				stateMaxTime = 1.0f;

				moveDir = -modelTransform.forward;

				ani.Play("Back", 0, 0);
				break;
			case ANISTATE.BackUpdate:
				if (DistanceCheck(0, 7) == false)
				{
					state = ANISTATE.IdleIn;
					break;
				}
				else
				{
					if (currentTime >= stateMaxTime)
					{
						state = ANISTATE.IdleIn;
						break;
					}
					else
					{
						currentTime += Time.deltaTime;

						pos = moveDir * finalSpeed * Time.deltaTime;

						ray.origin = transform.position + pos;
						ray.direction = -modelTransform.forward;

						if (Physics.Raycast(ray, out hitData, 1.0f))
						{
							if (hitData.collider.tag == "Wall")
							{
								state = ANISTATE.IdleIn;
								break;
							}
						}

						transform.position += pos;
					}
				}
				break;
			case ANISTATE.BackOut:
				break;
			case ANISTATE.AttackIn:
				attackCount++;
				if( attackCount == 3)
				{
					state = ANISTATE.Skill1In;
					break;
				}
				else if( attackCount == 6)
				{
					state = ANISTATE.Skill2In;
					break;
				}
				else
				{
				SoundManager.Instance.PlayBossSoundEffect(1);
					state = ANISTATE.AttackUpdate;

					currentTime = 0.0f;
					stateMaxTime = attackDelay;
					ani.Play("Attack", 0, 0);
				}

				break;
			case ANISTATE.AttackUpdate:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.AttackOut;

					if (targetObject)
					{
						weapon.CreateBullet(bossAttackDmg, bulletPos.position, targetObject.transform.position);
						//Destroy(Instantiate(prefabAttack, targetObject.transform.position, Quaternion.identity), 1.0f);
					}
				}
				else
					currentTime += Time.deltaTime;
				break;
			case ANISTATE.AttackOut:
				if( ani.GetCurrentAnimatorStateInfo(0).IsName("Attack")==false)
				{
					state = ANISTATE.BackIn;
				}
				break;
			case ANISTATE.Skill1In:

				ani.Play("Magic Area Attack 01", 0, 0);
				SoundManager.Instance.PlayBossSoundEffect(2);

				currentTime = 0;
				stateMaxTime = skill1Delay;
				state = ANISTATE.Skill1Update;
				break;
			case ANISTATE.Skill1Update:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.Skill1Out;

					if (targetObject)
					{
						//Destroy(Instantiate(prefabSkill1, targetObject.transform.position, Quaternion.identity), 1.0f);
						Instantiate(prefabSkill1, targetObject.transform.position, Quaternion.identity).GetComponent<BossSkill1AreaCollider>().StartSkill(bossSkill1Dmg, 4,1.0f);
					}
				}
				else
					currentTime += Time.deltaTime;
				break;
			case ANISTATE.Skill1Out:
				if (ani.GetCurrentAnimatorStateInfo(0).IsName("Magic Area Attack 01") == false)
				{
					state = ANISTATE.BackIn;
				}
				break;
			case ANISTATE.Skill2In:


				ani.Play("Magic Attack 01", 0, 0);
				currentTime = 0;
				stateMaxTime = skill2Delay;

				SoundManager.Instance.PlayBossSoundEffect(3);
				state = ANISTATE.Skill2Update;
				break;
			case ANISTATE.Skill2Update:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.Skill2Out;


					if (targetObject)
					{
						//Destroy(Instantiate(prefabSkill1, targetObject.transform.position, Quaternion.identity), 1.0f);
						Instantiate(prefabSkill2, targetObject.transform.position, Quaternion.identity).GetComponent<BossSkill1AreaCollider>().StartSkill(bossSkill2Dmg, 8, 0.5f);
					}
				}
				else
					currentTime += Time.deltaTime;
				break;
			case ANISTATE.Skill2Out:
				if (ani.GetCurrentAnimatorStateInfo(0).IsName("Magic Attack 01") == false)
				{
					state = ANISTATE.BackIn;
				}
				break;
			case ANISTATE.DieIn:
				if (UnityEngine.Random.Range(0, 2) == 0) 
					ani.Play("Death1", 0, 0.0f);
				else 
					ani.Play("Death2", 0, 0.0f);

				currentTime = 0;
				stateMaxTime = 5.0f;
				state = ANISTATE.DieUpdate;
				SoundManager.Instance.PlayBossSoundEffect(0);
				QuestManager.Instance.AddValue(2, 1);
				break;
			case ANISTATE.DieUpdate:
				if (currentTime >= stateMaxTime)
				{
					state = ANISTATE.DieOut;
				}
				else
					currentTime += Time.deltaTime;
				break;
			case ANISTATE.DieOut:
				UIManager.Instance.QuestInfoOkOnly(2, null);
				Destroy(gameObject);
				break;
			case ANISTATE.GroggyIn:
				currentTime = 0;
				stateMaxTime = 5.0f;
				emoji.SetActive(true);
				oura.SetActive(true);
				ani.Play("GroggyIn", 0, 0);
				state = ANISTATE.GroggyUpdate;
				break;
			case ANISTATE.GroggyUpdate:
				if (currentTime >= stateMaxTime)
				{
					ani.Play("GroggyToIdle", 0, 0);
					state = ANISTATE.GroggyOut;
					emoji.SetActive(false);
					oura.SetActive(false);
				}
				else
					currentTime += Time.deltaTime;
				break;
			case ANISTATE.GroggyOut:
				if (ani.GetCurrentAnimatorStateInfo(0).IsName("GroggyToIdle") == false)
				{
					state = ANISTATE.IdleIn;
				}
				break;
			case ANISTATE.Return:
				break;
			default:
				
				break;
		}

		{
			pos = transform.position;
			ray.origin = pos + (Vector3.up * 15.0f);
			ray.direction = -(Vector3.up );
			rayPos.RayToTarget(ref ray, "Terrain");
			pos.y = rayPos.Y;
			transform.position = pos;
		}
	}


	public void ResetEndPos()
	{
		transform.position = startPos;
		data.HPReset();
		UIManager.Instance.SetBossBar(1f, data.HP, data.HPMax);
		gameObject.SetActive(false);
	}

	public void ImpactDamage(int _dmg)
	{
		if (data == null) return;

		if (data.IsDead == true) return;

		if (data.Impact(_dmg))
		{
			gameObject.tag = "EnemyDie";
			state = ANISTATE.DieIn;
			UIManager.Instance.SetBossBar(data.HPPercent, data.HP, data.HPMax);
		}
		else
		{
			if( bGroggy == false)
			{
				if (data.HPPercent <= 0.5f) {
					state = ANISTATE.GroggyIn;
					bGroggy = true;

				}
			}
			currentTime = 0;
			stateMaxTime = 0.5f;
			UIManager.Instance.BossBar(true);
			UIManager.Instance.SetBossBar(data.HPPercent, data.HP, data.HPMax);
		}
	}
}