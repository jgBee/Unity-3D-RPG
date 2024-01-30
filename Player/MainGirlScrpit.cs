using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainGirlScrpit : MonoBehaviour
{
	private enum STATE
	{
		IdleIn,
		IdleUpdate,
		IdleOut,

		YawnIn,
		YawnUpdate,
		YawnOut,

		WalkIn,
		WalkUpdate,
		WalkOut,

		RunIn,
		RunUpdate,
		RunOut,

		DrawReadIn,
		DrawReadUpdate,
		DrawReadOut,

		IdleReadIn,
		IdleReadUpdate,
		IdleReadOut,

		SheathIn,
		SheathUpdate,
		SheathOut,

		WalkReadFrontIn,
		WalkReadFrontUpdate,
		WalkReadFrontOut,

		WalkReadBackIn, 
		WalkReadBackUpdate,
		WalkReadBackOut,
	
		RunReadIn,
		RunReadUpdate,
		RunReadOut,

		AttackIn,
		AttackUpdate,
		AttackOut,

		ImpactIn,
		ImpactUpdate,
		ImpactOut,

		ESkillIn,
		ESkillUpdate,
		ESkillOut,

		QSkillIn,
		QSkillUpdate,
		QSkillOut,

		DeathIn,
		DeathUpdate,
		DeathOut,
	};
	[SerializeField]private STATE state;
	[SerializeField] private Camera inventoryCam;


	[Header("Inspector_Value")]
	public float walkSpeed = 5;
	public float runSpeed = 10;
	[SerializeField] private PlayerBaseData data;
	[SerializeField] private Animator ani;


	[Header("Inspector_Equiptment")]
	[SerializeField] private GameObject weaponObject;
	[SerializeField] private GameObject shieldObject;

	[Header("Inspector_RayDownPos")]
	[SerializeField] private RayDownPos rayPos;

	[Header("Inspector_Effect")]
	[SerializeField] private GameObject[] effectList;


	//해당 순번으로 저장
	private enum ANINAMEINDEX : int
	{
		Idle,
		IdleYawn,
		Walk,
		Run,
		impact1,
		impact2,
		DrawRead2,
		ReadIdle,
		SheathSword1,
		WalkFront,
		WalkBack,
		WalkJump,
		RunFront,
		RunBack,
		RunJump,
		RunHelp,
		Slash,
		TwoSlash,
		eSkill_Kick,
		qSkill_Casting,
		PowerUp,
		Die1, 
		Die2,
	}
	[Header("AniName[MainGirlScriptEnum] : ClipName")]
	public string[] AniNameList;



	[Header("CheckList")]
	[SerializeField] GameObject itemObject;
	[SerializeField] GameObject NPCObject;

	private float stateWaitTime, currentTime;
	private bool bUseRead;
	[SerializeField] private float finalSpeed;

	private Vector3 goalPos, startPos, moveDir;
	private Vector3 moveLeftUp;
	private Vector3 moveLeftDown;
	private Vector3 moveRightUp;
	private Vector3 moveRightDown;

	[SerializeField] private GameObject targetEnemy;

	public float minEnemyRadius, minWallRadius;
	//public float rayLandRange;

	[SerializeField] private bool isRun;

	public Joystick joystick;

	Ray ray;
	RaycastHit rayHit;

	public GameObject rayObject;
	public GameObject model;


	private bool isLeft;
	private bool isRight;
	private bool isUp;
	private bool isDown;


	private List<string> checkList;
	[SerializeField]private ReadControl weaponCon;
	[SerializeField] private EnemyCollider ESkillCollider;
	[SerializeField] private EnemyCollider QSkillCollider;
	[SerializeField] private GameObject PrefabQSkillOura;

	private bool bBarUpdate;

	private bool bInFightZone;



	#region Awake Start Update
	private void Awake()
	{
		ray = new Ray();
		moveLeftUp = new Vector3(-0.7f, 0, 0.7f);
		moveLeftDown = new Vector3(-0.7f, 0, -0.7f);
		moveRightUp = new Vector3(0.7f, 0, 0.7f);
		moveRightDown = new Vector3(0.7f, 0, -0.7f);

		isRun = false;
		finalSpeed = walkSpeed;
		startPos = transform.position;

		checkList = new List<string>();
		//isMove = true;
		data.ChangeData(PlayerEnum.PLAYERCHARINDEX.Char_5_0_1_MainGirl,1);
	}

	private void Start()
	{
		ResetStartPoint();
		UIManager.Instance.GoField(true);

		QuestManager.Instance.QuestIn(0);

		weaponCon.Active(false);

		foreach (GameObject item in effectList)
		{
			item.SetActive(false);
		}

		SoundManager.Instance.PlayBGM(0);
	}


	private void Update()
	{
		if (bBarUpdate)
		{
			bBarUpdate = false;
			UIManager.Instance.SetPlayerBarInfo("MainGirl", 1, data.HPPercent, data.ExpPercent, data.Level);
			UIManager.Instance.SetGold(Inventory.Instance.Gold);
			UIManager.Instance.SetJewel(Inventory.Instance.Jewel);
		}

		if(AniNameEqual(AniNameList[(int)ANINAMEINDEX.impact1]) || AniNameEqual(AniNameList[(int)ANINAMEINDEX.impact2]) || AniNameEqual(AniNameList[(int)ANINAMEINDEX.eSkill_Kick]) || AniNameEqual(AniNameList[(int)ANINAMEINDEX.qSkill_Casting]) || AniNameEqual(AniNameList[(int)ANINAMEINDEX.TwoSlash]) )
		{
			return;
		}
		
		if (data.IsDead() == true) return;

		data.ESkillUpdate();
		data.QSkillUpdate();

		UIManager.Instance.SetESkill(data.ESkillValue, data.ESkillPercent);
		UIManager.Instance.SetQSkill(data.QSkillValue, data.QSkillPercent);


		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			UIManager.Instance.TestActiveJoystickAndActionButton(true);
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			UIManager.Instance.TestActiveJoystickAndActionButton(false);
		}

		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			Inventory.Instance.WeaponItemIn(ItemEnum.WEAPONITEMINDEX.Star1_1_ItemSword);
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			Inventory.Instance.WeaponItemIn(ItemEnum.WEAPONITEMINDEX.Star1_2_ItemGreatSword);
		}
		

		if (Input.GetKeyDown(KeyCode.I))
		{
			UIManager.Instance.Inventory(true);
			UIManager.Instance.GoField(false);

			Inventory.Instance.InitLeft(data.name, inventoryCam.targetTexture, data.Level, data.ExpPercent,data.HPPercent,data.Attack,data.Shild);

		}

		if (Input.GetKeyDown(KeyCode.Q))
		{
			QSkill();
		}
		if (Input.GetKeyDown(KeyCode.E))
		{
			ESkill();
		}
		if (Input.GetKeyDown(KeyCode.J))
		{
			UIManager.Instance.QuestBoard(true);
			UIManager.Instance.GoField(false);
		}
		if (Input.GetMouseButtonDown(0))
		{
			Attack();
		}

		if ( Input.GetKeyDown(KeyCode.F))
		{
			if (NPCObject == null) return;

			switch (NPCObject.tag)
			{
				case "NPC":
					model.transform.LookAt(NPCObject.transform);
					NPCObject.GetComponent<NPC>().OpenQuestInfo();
					break;
				case "NPCHeal":
					NPCObject.GetComponent<NPCHeal>().OpenUIChatWindow();
					data.HPReset();
					bBarUpdate = true;
					break;
			}
		}

		if( Input.GetKeyDown(KeyCode.G))
		{
			if (itemObject == null) return;
			if( itemObject.GetComponent<ItemField>().DestroyItem() )
			{
				UIManager.Instance.KeyGuide("");
			}
		}

		if (UIManager.Instance.bUIOn == true)
		{
			if (Input.GetKeyDown(KeyCode.Escape))
			{
				UIManager.Instance.Inventory(false);
				UIManager.Instance.GoField(true);

				bBarUpdate = true;

			}
			return;
		}


		switch (state)
		{
			case STATE.IdleIn:
				if( bUseRead)
				{
					state = STATE.IdleReadIn;
				}
				else
				{
					state = STATE.IdleUpdate;
					currentTime = 0;

					ani.Play(AniNameList[(int)ANINAMEINDEX.Idle]);
				}
				OffReadShieldObject();
				stateWaitTime = UnityEngine.Random.Range(10.0f, 15.0f);
				break;
			case STATE.IdleUpdate:
				if (MoveControl())
				{
					if (bUseRead)
					{
						if (isRun) state = STATE.RunReadIn;
						else state = STATE.WalkReadBackIn;
					}
					else
					{
						if (isRun) state = STATE.RunIn;
						else state = STATE.WalkIn;
					}
				}

				if (currentTime >= stateWaitTime)
				{
					currentTime = 0;
					state = STATE.YawnIn;
					break;
				}
				else
					currentTime += Time.deltaTime;
				break;
			case STATE.IdleOut:
				if( isRun) state = STATE.RunIn;
				else state = STATE.WalkIn;

				break;
			case STATE.YawnIn:
				currentTime = 0;
				stateWaitTime = 8.3f;
				state = STATE.YawnUpdate;
				ani.Play(AniNameList[(int)ANINAMEINDEX.IdleYawn]);
				break;
			case STATE.YawnUpdate:
				if (MoveControl())
				{
					if (bUseRead)
					{
						if (isRun) state = STATE.RunReadIn;
						else state = STATE.WalkReadBackIn;
					}
					else
					{
						if (isRun) state = STATE.RunIn;
						else state = STATE.WalkIn;
					}
				}
				if (currentTime >= stateWaitTime)
				{
					state = STATE.IdleIn;
					break;
				}
				else
					currentTime += Time.deltaTime;

				break;
			case STATE.YawnOut:
				break;
			case STATE.WalkIn:
				OffReadShieldObject();
				finalSpeed = walkSpeed;
				state = STATE.WalkUpdate;
				ani.Play(AniNameList[(int)ANINAMEINDEX.Walk], 0, 0);
				break;
			case STATE.WalkUpdate:
				if (MoveControl() == false)
				{
					state = STATE.IdleIn;
					return;
				}

				if (isRun)
				{
					if (bUseRead)
					{
						state = STATE.RunReadIn;
					}
					else
					{
						 state = STATE.RunIn;
					}
				}

				Moving();

				break;
			case STATE.WalkOut:
				break;
			case STATE.RunIn:
				OffReadShieldObject();
				finalSpeed = runSpeed;
				ani.Play(AniNameList[(int)ANINAMEINDEX.Run]);
				state = STATE.RunUpdate;
				break;
			case STATE.RunUpdate:
				if (MoveControl() == false)
				{
					state = STATE.IdleIn;
					return;
				}

				if (isRun == false)
				{
					if (bUseRead)
					{
						state = STATE.WalkReadFrontIn;
					}
					else
					{
						state = STATE.WalkIn;
					}
				}

				Moving();
				break;
			case STATE.RunOut:
				break;
			case STATE.DrawReadIn:
				OnReadShieldObject();

				ani.SetBool("bUseRead", true);
				ani.Play(AniNameList[(int)ANINAMEINDEX.DrawRead2]);
				state = STATE.DrawReadUpdate;
				break;
			case STATE.DrawReadUpdate:
				if (AniNameEqual(AniNameList[(int)ANINAMEINDEX.DrawRead2]) == false)
					state = STATE.IdleReadIn;

				break;
			case STATE.DrawReadOut:
				break;
			case STATE.IdleReadIn:
				ani.Play(AniNameList[(int)ANINAMEINDEX.ReadIdle]);
				state = STATE.IdleReadUpdate;
				currentTime = 0.0f;
				break;
			case STATE.IdleReadUpdate:
				if (MoveControl())
				{
					if (isRun)
						state = STATE.RunReadIn;
					else
						state = STATE.WalkReadFrontIn;
				}

				break;
			case STATE.IdleReadOut:
				break;
			case STATE.SheathIn:
				ani.Play(AniNameList[(int)ANINAMEINDEX.SheathSword1]);
				ani.SetBool("bUseRead", false);

				state = STATE.SheathUpdate;
				break;
			case STATE.SheathUpdate:
				if(AniNameEqual(AniNameList[(int)ANINAMEINDEX.SheathSword1]) == false)
				{
					state = STATE.IdleIn;
					OffReadShieldObject();
					break;
				}
				break;
			case STATE.SheathOut:
				break;
			case STATE.WalkReadFrontIn:
			
				ani.Play(AniNameList[(int)ANINAMEINDEX.WalkFront]);
				state = STATE.WalkReadFrontUpdate;
				finalSpeed = walkSpeed;
				break;
			case STATE.WalkReadFrontUpdate:
				if (MoveControl())
				{
					if (isRun)
						state = STATE.RunReadIn;
					else
						Moving();
				}
				else state = STATE.IdleReadIn;

				
				break;
			case STATE.WalkReadFrontOut:
				break;
			case STATE.WalkReadBackIn:
				ani.Play(AniNameList[(int)ANINAMEINDEX.WalkBack]);
				state = STATE.WalkReadBackUpdate;
				finalSpeed = walkSpeed;
				break;
			case STATE.WalkReadBackUpdate:
				break;
			case STATE.WalkReadBackOut:
				break;
			case STATE.RunReadIn:
				ani.Play(AniNameList[(int)ANINAMEINDEX.RunFront]);
				state = STATE.RunReadUpdate;
				finalSpeed = runSpeed;
				break;
			case STATE.RunReadUpdate:
				if (MoveControl())
				{
					if (isRun == false)
						state = STATE.WalkReadFrontIn;
					else
						Moving();
				}
				else state = STATE.IdleReadIn;
				break;
			case STATE.RunReadOut:
				break;
			case STATE.AttackIn:
				if( bUseRead)
				{
					Attack();
					state = STATE.AttackUpdate;
				}
				else
				{
					bUseRead = true;
					state = STATE.DrawReadIn;
					return;
				}
				break;
			case STATE.AttackUpdate:
				if(!(AniNameEqual(AniNameList[(int)ANINAMEINDEX.Slash]) == true || AniNameEqual(AniNameList[(int)ANINAMEINDEX.TwoSlash]) == true))
				{
					state = STATE.IdleReadIn;
					break;
				}
					break;
			case STATE.AttackOut:
				break;
			case STATE.ImpactIn:
				state = STATE.ImpactUpdate;
				break;
			case STATE.ImpactUpdate:
				break;
			case STATE.ImpactOut:
				break;
			case STATE.ESkillIn:
				SoundManager.Instance.PlayPlayerSoundEffect(1);
				ani.Play(AniNameList[(int)ANINAMEINDEX.eSkill_Kick]);
				data.ESkillReset();
				ESkillCollider.Use(data.Attack + 10, 0.2f);
				state = STATE.ESkillUpdate;
				break;
			case STATE.ESkillUpdate:
				if(AniNameEqual(AniNameList[(int)ANINAMEINDEX.eSkill_Kick]) == false)
				{
					state = STATE.IdleReadIn;
				}
				break;
			case STATE.ESkillOut:
				break;
			case STATE.QSkillIn:
				SoundManager.Instance.PlayPlayerSoundEffect(2);

				ani.Play(AniNameList[(int)ANINAMEINDEX.qSkill_Casting]);
				data.QSkillReset();
				QSkillCollider.Use(data.Attack + 20, 1.75f);
				state = STATE.QSkillUpdate;
				break;
			case STATE.QSkillUpdate:
				if (AniNameEqual(AniNameList[(int)ANINAMEINDEX.qSkill_Casting]) == false)
				{
					state = STATE.IdleReadIn;
				}
				break;
			case STATE.QSkillOut:
				break;
			case STATE.DeathIn:
				gameObject.tag = "Death";
				state = STATE.DeathUpdate;
				break;
			case STATE.DeathUpdate:
				break;
			case STATE.DeathOut:
				break;
			default:
				break;
		}
	}

	#endregion


	private void OnTriggerEnter(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "Enemy":
				targetEnemy = other.gameObject;
				break;
			case "ItemField":
				itemObject = other.gameObject;
				UIManager.Instance.KeyGuide("G");

				break;
			case "NPC":
			case "NPCHeal":
					UIManager.Instance.KeyGuide("F");
					NPCObject = other.gameObject;
				break;

			case "QuestPoint":
				// 문제점이 NPC를 갖고있어서 해당 NPC를 줘야하는데 생성하는 오브젝트라서 갖고있지 않음
				
				QuestManager.Instance.QuestClear(other.GetComponent<QuestPointAction>().actionValue);
				Destroy(other.gameObject);
				break;
			default:
				break;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		switch (other.gameObject.tag)
		{
			case "Enemy":
				targetEnemy = null;
				break;
			case "ItemField":
				itemObject = null;
				UIManager.Instance.KeyGuide("");
				break;
			case "NPC":
			case "NPCHeal":
				NPCObject = null;
				UIManager.Instance.UIChatWindow(false);
				UIManager.Instance.KeyGuide("");
				break;
			default:
				break;
		}
	}



	private bool MoveControl()
	{
#if UNITY_EDITOR_WIN || UNITY_STANDALONE
//#if UNITY_ANDROID || UNITY_IOS

		if (Input.GetKey(KeyCode.W)) { isUp = true; } else { isUp = false; }
		if (Input.GetKey(KeyCode.S)) { isDown = true; } else { isDown = false; }
		if (Input.GetKey(KeyCode.A)) { isLeft = true; } else { isLeft = false; }
		if (Input.GetKey(KeyCode.D)) { isRight = true; } else { isRight = false; }

		if (Input.GetKey(KeyCode.LeftShift)) { isRun = true; } else { isRun = false; }

		if (isUp || isDown || isLeft || isRight) return true;
#endif 
		//#if UNITY_EDITOR_WIN || UNITY_STANDALONE
#if UNITY_ANDROID || UNITY_IOS

		if ( joystick != null )
		{
			moveDir = UIManager.Instance.GetJoystick();

			if( moveDir == Vector3.zero)	return false;
			else return true;
		}
		

#endif
		return false;

	}

	public void InFightZone(bool _flag)  { 
		bInFightZone = _flag;
		if (bInFightZone)
		{
			state = STATE.DrawReadIn;
			ani.Play(AniNameList[(int)ANINAMEINDEX.DrawRead2],0,0);
		}
		else
		{
			state = STATE.SheathIn;
			ani.Play(AniNameList[(int)ANINAMEINDEX.SheathSword1], 0, 0);
		}
	}


	private void Moving()
	{
//#if UNITY_EDITOR_WIN || UNITY_STANDALONE
#if UNITY_ANDROID || UNITY_IOS

		isLeft = isRight = isUp = isDown = false;
						
		if (moveDir.x < 0) { isLeft = true; isRight = false; }
		else if (moveDir.x > 0) { isLeft = false; isRight = true; }

		if (moveDir.z > 0) { isUp = true; isDown = false; }
		else if (moveDir.z < 0) { isUp = false; isDown = true; }
						
		if (!isUp && !isDown && !isLeft && !isRight) { moveDir = Vector3.zero; return; }

#endif

#if UNITY_EDITOR_WIN || UNITY_STANDALONE
//#if UNITY_ANDROID || UNITY_IOS

		if (isLeft && isUp == false && isDown == false && isRight == false)
		{
			moveDir = -Camera.main.transform.right;
		}
		if (isRight && isUp == false && isDown == false && isLeft == false)
		{
			moveDir = Camera.main.transform.right;
		}
		if (isUp && isDown == false && isLeft == false && isRight == false)
		{
			moveDir = Camera.main.transform.forward;
		}
		if (isDown && isUp == false && isLeft == false && isRight == false)
		{
			moveDir = -Camera.main.transform.forward;
		}

		if (isLeft && isUp)
		{
			moveDir = Camera.main.transform.rotation * moveLeftUp;
		}
		else if (isLeft && isDown)
		{
			moveDir = Camera.main.transform.rotation * moveLeftDown;
		}

		if (isRight && isUp)
		{
			moveDir = Camera.main.transform.rotation * moveRightUp;
		}
		else if (isRight && isDown)
		{
			moveDir = Camera.main.transform.rotation * moveRightDown;
		}
		moveDir.y = 0.0f;
#endif


		if (moveDir != Vector3.zero)
		{
			goalPos = transform.position + moveDir * finalSpeed * Time.deltaTime;

			ray.origin = transform.position;
			ray.direction = moveDir;
			if (Physics.Raycast(ray, out rayHit, 1.5f))
			{
				if (rayHit.collider.tag == "Wall") return;
			}

			//// 땅과의 충돌
			Vector3 pos1, pos2;
			ray.origin = goalPos + (Vector3.up * 2.0f);
			ray.direction = goalPos - (Vector3.up * 5.0f);

			pos1 = goalPos + (Vector3.up * 2.0f);
			pos2 = goalPos -(Vector3.up * 5.0f);
			rayPos.LineToTarget(ref pos1, ref pos2, "Terrain");
			goalPos.y = rayPos.Y;

			model.transform.rotation = Quaternion.LookRotation(moveDir);

			transform.position = goalPos;

		}
	}


	// 플레이어의 상태를 
	public void ResetStartPoint()
	{
		bBarUpdate = true;

		data.ChangeData(PlayerEnum.PLAYERCHARINDEX.Char_5_0_1_MainGirl, 1);

		state = STATE.IdleIn;

		weaponCon.Active(false);
		transform.position = startPos;
		//isMove = true;
		state = STATE.IdleIn;
		OffReadShieldObject();
		gameObject.tag = "Player";
		ani.SetBool("bUseRead", false);
	}



	private int AniAttack()
	{
		checkList.Clear();
		checkList.Add(AniNameList[(int)ANINAMEINDEX.Slash]);
		checkList.Add(AniNameList[(int)ANINAMEINDEX.ReadIdle]);
		checkList.Add(AniNameList[(int)ANINAMEINDEX.WalkFront]);
		checkList.Add(AniNameList[(int)ANINAMEINDEX.WalkBack]);
		checkList.Add(AniNameList[(int)ANINAMEINDEX.RunFront]);
		checkList.Add(AniNameList[(int)ANINAMEINDEX.RunBack]);

		string twoSlash = AniNameList[(int)ANINAMEINDEX.TwoSlash];
		string target = "";

		// TwoSlash가 진행되는 경우엔 여기에 들어오면 안됌
		bool bCheck = false;


		for (int i = 0; i < checkList.Count; i++)
		{
			if (AniNameEqual(checkList[i]) == true)
			{ bCheck = true; target = checkList[i]; break; }
		}
		if (bCheck == false) return 0;

		// 두 번째 베기시 리턴
		//Debug.Log(target);
		switch (target)
		{
			case "Slash":
				if (ani.GetCurrentAnimatorStateInfo(0).normalizedTime >= 0.85f)
				{
					SoundManager.Instance.PlayPlayerSoundEffect(0);

					Invoke("IK_TwoSlashEffectOn", 0.45f);
					Invoke("IK_TwoSlashEffectOff", 0.9f);
					//Debug.Log("OnTwoSlash");
					weaponCon.Slash(data.Attack + 5, 0.5f);
					ani.Play(twoSlash, 0, 0.0f);
					return 2;
				}
				else
				{
				//	Debug.Log("Slashing");
					//isMove = false;
					return 0;
				}
			default:
				//	Debug.Log("Slash");
				SoundManager.Instance.PlayPlayerSoundEffect(0);

				Invoke("IK_SlashEffectOn", 0.3f);
				Invoke("IK_SlashEffectOff", 0.6f);

				weaponCon.Slash(data.Attack, 0.3f);

				ani.Play(checkList[0], 0, 0.0f);
				SoundManager.Instance.PlayPlayerSoundEffect(0);
				//isMove = false;
				return 1;
		}
	}


	private void AniDead()
	{
		if (UnityEngine.Random.Range(0, 2) == 0)
			ani.Play("DeathFront", 0, 0.0f);
		else
			ani.Play("DeathBack", 0, 0.0f);
	}


	private void AniImpact()
	{

		if (UnityEngine.Random.Range(0, 2) == 0)
			ani.Play("impact1", 0, 0.0f);
		else
			ani.Play("impact2", 0, 0.0f);
	}


	private bool AniNameEqual(string _name, int _layerNumber = 0)
	{
		return ani.GetCurrentAnimatorStateInfo(_layerNumber).IsName(_name);
	}


	//	#endregion

	/// UINormalAttackButton - ButtonFunction
	public void Attack()
	{
		if (UIManager.Instance.bUIOn) return;
		if (bInFightZone == false) return;

		if (state == STATE.DrawReadIn || state == STATE.DrawReadUpdate || state == STATE.DrawReadOut
			|| state == STATE.SheathIn || state == STATE.SheathUpdate || state == STATE.SheathOut) return;
		state = STATE.AttackIn;
		AniAttack();
	}

	public void ESkill()
	{
		if (UIManager.Instance.bUIOn) return;
		if (bInFightZone == false)
		{
			UIManager.Instance.NotifyGame(2.0f, "마을에선 사용할 수 없습니다.");
			return;
		}
		if (state == STATE.DrawReadIn || state == STATE.DrawReadUpdate || state == STATE.DrawReadOut) return;
		if (data.EnableESkill())
			state = STATE.ESkillIn;
	}

	public void QSkill()
	{
		if (UIManager.Instance.bUIOn) return;
		if (bInFightZone == false)
		{
			UIManager.Instance.NotifyGame(2.0f, "마을에선 사용할 수 없습니다.");
			return;
		}
		if (state == STATE.DrawReadIn || state == STATE.DrawReadUpdate || state == STATE.DrawReadOut) return;
		if (data.EnableQSkill())
			state = STATE.QSkillIn;
	}



	private void OnReadShieldObject()
	{
		bUseRead = true;
		if (weaponObject != null) weaponObject.SetActive(true);
		if (shieldObject != null) shieldObject.SetActive(true);
	}

	private void OffReadShieldObject()
	{
		bUseRead = false;
		if (weaponObject != null) weaponObject.SetActive(false);
		if (shieldObject != null) shieldObject.SetActive(false);
	}

	public void Impact(int _dmg)
	{
		ESkillCollider.StopCoroutine();
		weaponCon.StopCoroutine();

		if (AniNameEqual(AniNameList[(int)ANINAMEINDEX.qSkill_Casting]))
		{
			//Debug.Log("CallCasting");
			return;
		}

		data.HP = -_dmg;
		bBarUpdate = true;
		//Debug.Log(data.HP + "\t" + _dmg);
		weaponCon.StopCoroutine();

		if ( data.IsDead() )
		{
			if (AniNameEqual(AniNameList[(int)ANINAMEINDEX.Die1]) == true || AniNameEqual(AniNameList[(int)ANINAMEINDEX.Die2])) return;

			//isMove = false;
			AniDead();
			Invoke("ResetStartPoint", 5.0f);	

		}
		else
		{
			AniImpact();
			//isMove = false;
		}
	}

	public void GetExpGold(int _exp,int _gold)
	{
		int prevlevel = data.Level;
		data.Exp += _exp;

		if (prevlevel != data.Level)
		{
			effectList[2].SetActive(true);
			Invoke("IK_LevelUpEffectOff", 2.0f);
			SoundManager.Instance.PlayLevelUpSoundEffect();

		}
		bBarUpdate = true;

		
		Inventory.Instance.Gold += _gold;
	}
	#region Invoke Function

	private void IK_SlashEffectOn() { effectList[0].SetActive(true); }
	private void IK_SlashEffectOff() { effectList[0].SetActive(false); }
	private void IK_TwoSlashEffectOn() { effectList[1].SetActive(true); }
	private void IK_TwoSlashEffectOff() { effectList[1].SetActive(false); }


	private void IK_LevelUpEffectOff()  { effectList[2].SetActive(false); }
	#endregion
}