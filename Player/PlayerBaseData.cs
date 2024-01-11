using System;
using UnityEngine;
using static ElementEnum;
using static PlayerEnum;


public class PlayerBaseData : MonoBehaviour
{
	private int Hp;
	private int HpMax;
	public int HP
	{
		get { return Hp; }
		set { Hp += value; if (Hp <= 0) Hp = 0; else if (Hp > HpMax) Hp = HpMax; }
	}
	public int HPMax { get { return HpMax; } }
	public float HPPercent { get { return Hp / (float)HpMax; } }

	private int Mp;
	private int MpMax;
	public int MP
	{
		get { return Mp; }
		set { Mp += value; if (Mp > MpMax) Mp = MpMax; else if (Mp < 0) Mp = 0; }
	}
	public int MPMax { get { return MpMax; } }
	public float MPPercent => Mp / (float)MpMax;

	private int exp;
	private int expMax;

	public int Exp { get { return exp; } set { exp += value; 
			if (exp > expMax) { Level++; ChangeData(index, Level); exp = 0; } 
		} 
	}

	public float ExpPercent => exp / (float)expMax;

	private int attack;
	public int Attack { get { return attack; } }
	private int shild;
	public int Shild { get { return shild; } }

	public int Level = 1;

	private bool isDead;

	private float currESkillTime, currQSkillTime;
	[SerializeField] private float maxESkillTime, maxQSkillTime;

	public float ESkillValue => currESkillTime;
	public float ESkillPercent => currESkillTime / maxESkillTime;

	public float QSkillValue => currQSkillTime;
	public float QSkillPercent => currQSkillTime/ maxQSkillTime;



	private PLAYERCHARINDEX index;
	public PLAYERCHARINDEX Index { get { return index; } set { index = value; } }

	private ELEMENT charElement;


	public void ChangeData(PLAYERCHARINDEX _type, int _level)
	{
		isDead = false;
		index = _type;

		switch (_type)
		{
			case PLAYERCHARINDEX.Char_0_None:
				Level = shild = attack = MpMax = Mp = HpMax = Hp = 0;

				isDead = true;
				charElement = ELEMENT.Wind;
				break;
			case PLAYERCHARINDEX.Char_1_Paimon:
				HpMax = Hp = 0 * _level;
				Mp = 0;
				MpMax = 0;

				attack = 0;
				shild = 0;
				
				Level = _level;

				isDead = true;
				charElement = ELEMENT.Wind;
				break;
			case PLAYERCHARINDEX.Char_5_0_MainMan:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;
				exp = 0;
				expMax = 50 * _level;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Wind;
				break;
			case PLAYERCHARINDEX.Char_5_0_1_MainGirl:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				exp = 0;
				expMax = 50 * _level;

				attack = 10 + _level;
				shild = 1 + _level;

				Level = _level;

				isDead = false;

				isDead = false;
				charElement = ELEMENT.Wind;
				break;
			case PLAYERCHARINDEX.Char_5_1_Jean:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Wind;
				break;
			case PLAYERCHARINDEX.Char_5_2_Klee:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;
				isDead = false;
				charElement = ELEMENT.Fire;
				break;
			case PLAYERCHARINDEX.Char_5_3_Mona:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Water;
				break;
			case PLAYERCHARINDEX.Char_5_4_Chichi:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Ice;
				break;
			case PLAYERCHARINDEX.Char_5_5_RadenShogun:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Thunder;
				break;
			case PLAYERCHARINDEX.Char_4_1_Ambo:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Fire;
				break;
			case PLAYERCHARINDEX.Char_4_2_Noelle:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Rock;
				break;
			case PLAYERCHARINDEX.Char_4_3_Rosaria:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Ice;
				break;
			case PLAYERCHARINDEX.Char_4_4_Ningguang:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Rock;
				break;
			case PLAYERCHARINDEX.Char_4_5_Yoyo:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Grass;
				break;
			case PLAYERCHARINDEX.Char_4_6_Charlotte:
				HpMax = Hp = 100 * _level;
				Mp = MpMax = 10;

				attack = 10 * _level;
				shild = 1 * _level;

				Level = _level;

				isDead = false;
				charElement = ELEMENT.Ice;
				break;
		}
	}

	public void ESkillReset()
	{
		currESkillTime = maxESkillTime;
	}

	public void QSkillReset()
	{
		currQSkillTime = maxQSkillTime;
	}

	public void ESkillUpdate()
	{
		if (currESkillTime < 0.0f) return;
		currESkillTime -= Time.deltaTime;
	}

	public void QSkillUpdate()
	{
		if (currQSkillTime < 0.0f) return;
		currQSkillTime -= Time.deltaTime;
	}

	public void HPReset() { Hp = HpMax; }
	public bool IsDead()
	{
		if (Hp <= 0) return isDead = true;

		return isDead = false;
	}

	public bool EnableESkill()
	{
		if (currESkillTime < 0) return true;
		else return false;
	}

	public bool EnableQSkill()
	{
		if (currQSkillTime < 0)	return true;
		else return false;
	}

}