using UnityEngine;
using System.Collections;

using static EnemyEnum;

public class EnemyData : MonoBehaviour
{
	[SerializeField]private ENEMYCHARINDEX index;
	public ENEMYCHARINDEX GetIndex { get { return index; } }

	public int Level;

	public int HP;
	public int HPMax;
	public float HPPercent => HP / (float)HPMax;

	public int Dmg;

	public int Shild;

	public int MP;
	public int MPMax;

	private bool bDead;
	public bool IsDead { get {return bDead;} }

	private int giveExp;
	public int GiveExp { get { return giveExp; } }


	private int giveGold;
	public int GiveGold { get { return giveGold; } }

	[Header("AttackTime")]
	public float currTime;
	public float attackTime;
	public float skillTime;
	public bool AttakPossible => (attackTime <= 0f) ? true : false;
	public bool SkillPossible => (skillTime <= 0f) ? true : false;
	



	public void TestChange()
	{
		ChangeEnemy(ENEMYCHARINDEX.Char_N_SpearMan, 1);
	}

	public void TestChangeBoss()
	{
		ChangeEnemy(ENEMYCHARINDEX.Char_B_SpearMan, 1);
	}

	public void HPReset()
	{
		HP = HPMax;
	}


	public void ChangeEnemy(ENEMYCHARINDEX _index, int _level)
	{
		switch (_index)
		{
			case ENEMYCHARINDEX.None:
				Level = 0;
				HP = HPMax = MP = MPMax = Dmg = Shild = 0;
				bDead = true;
				skillTime = attackTime = 0;
				giveExp = 0;
				giveGold = 0;
				break;
			case ENEMYCHARINDEX.Char_N_SpearMan:
				Level = _level;
				HP = HPMax = 30;
				MP = MPMax = 0;
				Shild = 1;
				attackTime = 3;
				skillTime = 0;
				bDead = false;
				giveExp = 10;
				giveGold = 10;
				CheckAttackTime();

				break;
			case ENEMYCHARINDEX.Char_H_SpearMan:
				Level = _level;
				HP = HPMax = 50;
				MP = MPMax = 50;
				Shild = 2;
				bDead = false;
				attackTime = 3;
				skillTime = 5;
				giveExp = 10;
				giveGold = Random.Range(10, 15);
				CheckAttackTime();

				break;
			case ENEMYCHARINDEX.Char_B_SpearMan:
				Level = _level;
				HP = HPMax = 100;
				MP = MPMax = 50;
				Shild = 3;
				bDead = false;
				attackTime = 2;
				skillTime = 4;

				giveExp = 100;
				giveGold = 100;

				CheckAttackTime();
				giveGold = 100;
				break;
			case ENEMYCHARINDEX.Char_E_SpearMan:
				Level = _level;
				HP = HPMax = 1;
				MP = MPMax = 1;
				Shild = 0;
				bDead = false;
				attackTime = 1;
				skillTime = 3;

				giveExp = 1;
				giveGold = 1;

				CheckAttackTime();
				break;
			default:
				break;
		}
		index = _index;	
	}

	public float HPCurrent() { return HP / HPMax; }

	public bool Impact(int _dmg)
	{
		int totalDamage = _dmg - Shild;

		HP -= totalDamage;

		if (HP <= 0) bDead = true;
		return bDead;
	}

	public void Heal(int _addHP)
	{
		HP += _addHP;
		if (HPMax >= HP) HP = HPMax;
	}

	private IEnumerator CheckAttackTime()
	{
		while (true)
		{
			switch (index)
			{
				case ENEMYCHARINDEX.Char_N_SpearMan:
				case ENEMYCHARINDEX.Char_H_SpearMan:
				case ENEMYCHARINDEX.Char_B_SpearMan:
				case ENEMYCHARINDEX.Char_E_SpearMan:
					if (attackTime > 0)
						attackTime -= 0.1f;
					break;
				default:
					attackTime = 1;	// 공격 불가
					yield break;
			}
			yield return new WaitForSeconds(0.1f);
		}
	}

	private IEnumerator CheckSkillTime()
	{
		while (true)
		{
			switch (index)
			{
				case ENEMYCHARINDEX.Char_N_SpearMan:
				case ENEMYCHARINDEX.Char_H_SpearMan:
				case ENEMYCHARINDEX.Char_B_SpearMan:
				case ENEMYCHARINDEX.Char_E_SpearMan:
					if (attackTime > 0)
						attackTime -= 0.1f;
					break;
				default:
					attackTime = 1; // 공격 불가
					yield break;
			}
			yield return new WaitForSeconds(0.1f);
		}
	}


}