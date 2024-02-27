using UnityEngine;
using SimpleJSON;

// 이 스크립트는 캐릭터 테이블에 대한 기본 정보를 모두 갖고있습니다.

public class CharacterTable : SlngleTonMonobehaviour<CharacterTable>
{
	public TextAsset txtFile;
	[SerializeField] JSONNode jsonData;

	private void Awake()
	{
		GetJSONData();
	}

	public void GetJSONData()
	{
		string json = txtFile.text;
		jsonData = JSON.Parse(json);
	}

	public void GetCharacterTable(PlayerEnum.ePlayerCharIndex _index, out CharacterData _charData)
	{
		_charData = null;

		string findKey = "";

		switch (_index)
		{
			case PlayerEnum.ePlayerCharIndex.Char_5_0_MainManWind:
				findKey = "MainManWind";
				break;
			case PlayerEnum.ePlayerCharIndex.Char_5_0_1_MainGirlWind:
				findKey = "MainGirlWind";
				break;
			//case PlayerEnum.ePlayerCharIndex.Char_5_1_Jean:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_5_2_Klee:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_5_3_Mona:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_5_4_Chichi:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_5_5_RadenShogun:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_1_Ambo:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_2_Noelle:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_3_Rosaria:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_4_Ningguang:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_5_Yoyo:
			//	break;
			//case PlayerEnum.ePlayerCharIndex.Char_4_6_Charlotte:
			//	break;

			default:
				UnityEngine.Debug.LogWarning("타입이 잘못 설정됐습니다. : " + _index.ToString());
				return;
		}

		JSONNode target = jsonData["Character"][findKey];

		int star = target["Star"].AsInt;
		int hp = target["Hp"].AsInt;
		string weaponType = target["WeaponType"];

		int dmg = target["Damage"].AsInt;
		int shield = target["Shield"].AsInt;

		string eSkillType = target["EElement"];
		int eSkillDmg = target["EDamage"].AsInt;
		float eSkillCool= target["ECoolTime"].AsFloat;
		int eSkillStack = target["EStack"].AsInt;

		string qSkillType = target["QElement"];
		int qSkillDmg = target["QDamage"].AsInt;
		float qSkillCool = target["QCoolTime"].AsFloat;
		int qSkillStack = target["QStack"].AsInt;
		int qSkillGauge = target["QGauge"].AsInt;


		_charData = new CharacterData();
		_charData.Init(_index, star,hp,weaponType,dmg,shield,
			eSkillType,eSkillDmg,eSkillCool,eSkillStack,
			qSkillType,qSkillDmg,qSkillCool,qSkillGauge,qSkillStack);
	}
}