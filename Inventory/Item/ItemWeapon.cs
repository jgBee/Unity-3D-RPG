using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemWeapon
{
	[SerializeField]private WEAPONeItemIndex index;
	private WEAPON_OPTION subOption;
	private int star;

	private Sprite itemSprite;

	private int level;
	private int maxLevel;

	private int attack;

	private int currBreakThrough;
	private int maxBreakThrough;

	private int exp;
	private int expMax;

	private string mainName;
	private string mainExplan;
	private string subExplan;

	private int subOptionValue;

	private bool bFavorit;
	private bool bNew;
	private bool bLock;


	// Get

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star=> star;
	public int Level => level;
	public int MaxLevel => maxLevel;

	public int Attack => attack;

	public int CurrBreakThrough => currBreakThrough;
	public int MaxBreakThrough => maxBreakThrough;

	public int Exp => exp;
	public int ExpMax => expMax;
	public float ExpPer => (float)exp / (float)expMax;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => SubOptionExplain();

	public bool Favorit { get; set; } 
	public bool Lock { get; set; }
	public bool New { get; set; }


	public int ReceveExp(int _exp)
	{
		int levelCount = 0;

		return levelCount;
	}

	public override string ToString()
	{
		string str = "";
		return str;
	}

	public void Init(WEAPONeItemIndex _index,int _star, string _mainName, string _mainExplan, string _subExplan, int _attack, string _subOptionType, int _subOptionValue, int _maxBreakThrough)
	{
		itemSprite = ItemImage.Instance.GetWeapon(_index);
		index = _index;

		bFavorit = false;
		bNew = false;
		bLock = false;
		level = 1;
		maxLevel = 10;

		star = _star;

		attack = _attack;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		currBreakThrough = 1;
		maxBreakThrough = _maxBreakThrough;

		switch (_subOptionType)
		{
			case null:
			case "0":
				subOption = WEAPON_OPTION.None;
				break;
			case "AddDamage":
				break;
			case "AddReadDamageValue":
				break;
			case "AddReadDamagePercent":
				break;
			case "AddFireAttack":
				break;
			case "AddWaterattack":
				break;
			case "AddLightingAttack":
				break;
			case "AddGreedAttack":
				break;
			case "AddIceAttack":
				break;
		}
		subOptionValue = _subOptionValue;
	}

	private string SubOptionExplain()
	{
		switch (subOption)
		{
			case WEAPON_OPTION.None:
				mainExplan = "";
				break;
			case WEAPON_OPTION.AddDamage:
				mainExplan = subOptionValue + "의 데미지를 추가합니다.";
				break;
			case WEAPON_OPTION.AddReadAttackValue:
				mainExplan = "무기 공격력이 현재 공격력 + " + subOptionValue + "값만큼 추가합니다.";
				break;
			case WEAPON_OPTION.AddReadAttackPercent:
				mainExplan = "무기 공격력이 현재 공격력 + " + subOptionValue + " 퍼센티지만큼 추가됩니다.";
				break;
			case WEAPON_OPTION.FireAttack:
				mainExplan = "불 속성 공격 : " + subOptionValue + "추가 공격";
				break;
			case WEAPON_OPTION.WaterAttack:
				mainExplan = "물 속성 공격 : " + subOptionValue + "추가 공격";
				break;
			case WEAPON_OPTION.IceAttack:
				mainExplan = "얼음 속성 공격 : " + subOptionValue + "추가 공격";
				break;
			case WEAPON_OPTION.GrassAttack:
				mainExplan = "풀 속성 공격 : " + subOptionValue + "추가 공격";
				break;
			case WEAPON_OPTION.WindAttack:
				mainExplan = "바람 속성 공격 : " + subOptionValue + "추가 공격";
				break;
			case WEAPON_OPTION.LightingAttack:
				mainExplan = "번개 속성 공격 : " + subOptionValue + "추가 공격";
				break;
		}
		return mainExplan;
	}


	public static WEAPONeItemIndex GetItemIndex(int _value)
	{
		WEAPONeItemIndex index = WEAPONeItemIndex.Star1_1_ItemSword;
		switch(_value)
		{
			case 0:
				index = WEAPONeItemIndex.Star1_1_ItemSword;
				break;
			case 1:
				index = WEAPONeItemIndex.Star1_2_ItemGreatSword;
				break;
		}
		return index;
	}

	public static WEAPONeItemIndex GetItemRandomIndex()
	{
		int min = 0;
		int max = 2;
		int randValue = UnityEngine.Random.Range(min, max);
		switch (randValue)
		{
			case 0: return WEAPONeItemIndex.Star1_1_ItemSword;
			case 1: return WEAPONeItemIndex.Star1_2_ItemGreatSword;
			default:
				return WEAPONeItemIndex.Star1_1_ItemSword;
		}
	}
}