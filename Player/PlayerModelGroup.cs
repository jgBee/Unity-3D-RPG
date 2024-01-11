using UnityEngine;


using static PlayerEnum;
using static ElementEnum;
using UnityEditor;

public class PlayerModelGroup : MonoBehaviour
{
	public GameObject[] prefabs;
	private PlayerAnim[] anim;

	private GameObject prevObject;
	private PlayerAnim prevAnim;


	private void Awake()
	{
		anim = new PlayerAnim[prefabs.Length];

		for (int i = 0; i < prefabs.Length; i++)
		{
			if( i == 0 && i == 1)
			{
				GameObject obj = Instantiate(prefabs[i], transform.position, Quaternion.identity);
				obj.transform.parent = gameObject.transform;
				anim[i] = null;
			}
			else
			{
				GameObject obj = Instantiate(prefabs[i], transform.position, Quaternion.identity);
				obj.transform.parent = gameObject.transform;
				anim[i] = obj.GetComponentInChildren<PlayerAnim>();
			}
			//Debug.Log("ani null : " + i + (anim[i] == null));
		}
	}

	private void Start()
	{
		OffModelAll();

	}

	public string CheckModelName(PLAYERCHARINDEX _index)
	{
		string modelName = "";
		switch (_index)
		{
			case PLAYERCHARINDEX.Char_5_0_MainMan:
				modelName = "2_MainMan(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_0_1_MainGirl:
				modelName = "2_MainGirl(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_1_Jean:
				modelName = "5_Jean(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_2_Klee:
				modelName = "5_Klee(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_3_Mona:
				modelName = "5_Mona(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_4_Chichi:
				modelName = "5_Chichi(Clone)";
				break;
			case PLAYERCHARINDEX.Char_5_5_RadenShogun:
				modelName = "5_RadenShogun(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_1_Ambo:
				modelName = "4_Ambo(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_2_Noelle:
				modelName = "4_Noelle(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_3_Rosaria:
				modelName = "4_Rosaria(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_4_Ningguang:
				modelName = "4_Ningguang(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_5_Yoyo:
				modelName = "4_Yoyo(Clone)";
				break;
			case PLAYERCHARINDEX.Char_4_6_Charlotte:
				modelName = "4_Charotte(Clone)";
				break;
			default:
				break;
		}

		return modelName;
	}

	private int GetArrayIndex(PLAYERCHARINDEX _index)
	{
		switch (_index)
		{
			//case PLAYERCHARINDEX.Char_0_None: return 0;
			case PLAYERCHARINDEX.Char_1_Paimon: return 1;
			case PLAYERCHARINDEX.Char_5_0_MainMan: return 3;
			case PLAYERCHARINDEX.Char_5_0_1_MainGirl: return 2;
			case PLAYERCHARINDEX.Char_5_1_Jean: return 10;
			case PLAYERCHARINDEX.Char_5_2_Klee: return 11;
			case PLAYERCHARINDEX.Char_5_3_Mona: return 12;
			case PLAYERCHARINDEX.Char_5_4_Chichi: return 9;
			case PLAYERCHARINDEX.Char_5_5_RadenShogun: return 13;
			case PLAYERCHARINDEX.Char_4_1_Ambo: return 4;
			case PLAYERCHARINDEX.Char_4_2_Noelle: return 7;
			case PLAYERCHARINDEX.Char_4_3_Rosaria: return 99;
			case PLAYERCHARINDEX.Char_4_4_Ningguang: return 6;
			case PLAYERCHARINDEX.Char_4_5_Yoyo: return 8;
			case PLAYERCHARINDEX.Char_4_6_Charlotte: return 5;
			default: return 0;

		}
	}


	public void OnModel(PLAYERCHARINDEX _index)
	{
		string target = CheckModelName(_index);

		if (target == "") return;
		else
		{
			if (prevObject != null && prevObject.name != target)
			{
				prevObject.SetActive(false);
			}
			else if(prevObject != null && prevObject.name == target)
			{
				return;
			}
		}


		for (int i = 1; i < anim.Length; i++)
		{
			if (anim[i].gameObject.name == target)
			{
				anim[i].gameObject.SetActive(true);
				prevObject = anim[i].gameObject;
				prevAnim = anim[i].GetComponent<PlayerAnim>();
				break;
			}
		}

		
	}

	public void OffModel(int _n)
	{
		//if (CheckValue(_n) == false) return;

		anim[_n].gameObject.SetActive(false);
	}

	public void OffModelAll()
	{
		foreach (PlayerAnim item in anim)
		{
			if (item == null) continue;

			item.gameObject.SetActive(false);
		}
	}

	public void SetMove(float _speed)
	{
		if (prevAnim == null) return;

		if (_speed >= 1&& _speed <= 5.0f)
			prevAnim.StartAni_Walk();
		else if (_speed >= 6.0f &&_speed <= 10.0f)
			prevAnim.StartAni_Run();
		else
			prevAnim.StartAni_Idle();
	}


	#region ValueCheck


	//// 애니 상태 체크
	//private bool CheckAniValue(PlayerAnim.ANIINDEX _value)
	//{
	//	if (_value < 0)
	//	{
	//		return false;
	//	}
	//	else if (_value >= PlayerAnim.ANIINDEX.Max)
	//	{
	//		return false;
	//	}
	//	else
	//	{
	//		return true;
	//	}
	//}
	#endregion


	public bool IsAttack(int _n)
	{
		return anim[_n].IsAnimationAtk() == true ? true : false ;
	}

	public float GetAtkDelay(PLAYERCHARINDEX _index, int _aniindex)
	{
		return anim[(int)_index].AtkDelay[_aniindex];
	}
	public float GetSkillDelay(PLAYERCHARINDEX _index)
	{
		return anim[(int)_index].skillDelay;
	}

	public void SetBlendMoveSpeed(float _speed) {
		if (prevAnim == null) return;

		prevAnim.SetBlendSpeed(_speed); 
	}
}