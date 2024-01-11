using UnityEngine;

using static PlayerEnum;

public class SubSkill : MonoBehaviour
{
	private enum SKILLINDEX : int
	{
		None = 0,
		Main_Wind,
		Main_Rock,
		Main_Thunder,
		Main_Grass,
		Main_Water,
		Main_Fire,
		Main_Ice,

		Jin_Wind,
		Klee_Fire,
		Mona_Water,
		ChiChi_Ice,
		RadenShogun_Thunder,
		Ambo_Fire,
		Noelle_Rock,
		Roseria_Ice,
		Ningguang_Rock,
		Yoyo_Grass,
		Charlotte_Ice,

	};
	private SKILLINDEX index = SKILLINDEX.None;

	public void ChangeSubSkill(PLAYERCHARINDEX _index)
	{
		switch (_index)
		{
			case PLAYERCHARINDEX.Char_0_None:
				index = SKILLINDEX.None;
				break;
			case PLAYERCHARINDEX.Char_1_Paimon:
				index = SKILLINDEX.None;
				break;
			case PLAYERCHARINDEX.Char_5_0_MainMan:
				index = SKILLINDEX.Main_Wind;
				break; 
			case PLAYERCHARINDEX.Char_5_0_1_MainGirl:
				index = SKILLINDEX.Main_Wind;
				break;
			case PLAYERCHARINDEX.Char_5_1_Jean:
				index = SKILLINDEX.Jin_Wind;
				break;
			case PLAYERCHARINDEX.Char_5_2_Klee:
				index = SKILLINDEX.Klee_Fire;
				break;
			case PLAYERCHARINDEX.Char_5_3_Mona:
				index = SKILLINDEX.Mona_Water;
				break;
			case PLAYERCHARINDEX.Char_5_4_Chichi:
				index = SKILLINDEX.ChiChi_Ice;
				break;
			case PLAYERCHARINDEX.Char_5_5_RadenShogun:
				index = SKILLINDEX.RadenShogun_Thunder;
				break;
			case PLAYERCHARINDEX.Char_4_1_Ambo:
				index = SKILLINDEX.Ambo_Fire;
				break;
			case PLAYERCHARINDEX.Char_4_2_Noelle:
				index = SKILLINDEX.Noelle_Rock;
				break;
			case PLAYERCHARINDEX.Char_4_3_Rosaria:
				index = SKILLINDEX.Roseria_Ice;
				break;
			case PLAYERCHARINDEX.Char_4_4_Ningguang:
				index = SKILLINDEX.Ningguang_Rock;
				break;
			case PLAYERCHARINDEX.Char_4_5_Yoyo:
				index = SKILLINDEX.Yoyo_Grass;
				break;
			case PLAYERCHARINDEX.Char_4_6_Charlotte:
				index = SKILLINDEX.Charlotte_Ice;
				break;
		}
	}

	public void OnSubSkill(PLAYERCHARINDEX _index)
	{
		switch (_index)
		{
			case PLAYERCHARINDEX.Char_0_None:break;
			case PLAYERCHARINDEX.Char_1_Paimon:break;
			case PLAYERCHARINDEX.Char_5_0_MainMan:
				MainWind();
				break;
			case PLAYERCHARINDEX.Char_5_0_1_MainGirl:
				MainWind();
				break;
			case PLAYERCHARINDEX.Char_5_1_Jean:
				break;
			case PLAYERCHARINDEX.Char_5_2_Klee:
				break;
			case PLAYERCHARINDEX.Char_5_3_Mona:
				break;
			case PLAYERCHARINDEX.Char_5_4_Chichi:
				break;
			case PLAYERCHARINDEX.Char_5_5_RadenShogun:
				break;
			case PLAYERCHARINDEX.Char_4_1_Ambo:
				break;
			case PLAYERCHARINDEX.Char_4_2_Noelle:
				break;
			case PLAYERCHARINDEX.Char_4_3_Rosaria:
				break;
			case PLAYERCHARINDEX.Char_4_4_Ningguang:
				break;
			case PLAYERCHARINDEX.Char_4_5_Yoyo:
				break;
			case PLAYERCHARINDEX.Char_4_6_Charlotte:
				break;
		}
	}

	public void MainWind()
	{

	}
}