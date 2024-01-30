using UnityEngine;

using static ItemEnum;

public class EquiptLineData {
	public EQUIPMENTOPTION optionIndex;
	public float value;
	public EQUIPMENTSET set;
}


[System.Serializable]
public class ItemEquipment
{
	private EQUIPMENTINDEX index;
	EquiptLineData mainOption;
	private int star;

	private Sprite itemSprite;

	private int level;
	private int maxLevel;

	private int mainValue;
	private int subValue;

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
	public int Star => star;
	public int Level => level;
	public int MaxLevel => maxLevel;

	public int MainValue => mainValue;

	public int CurrBreakThrough => currBreakThrough;
	public int MaxBreakThrough => maxBreakThrough;

	public int Exp => exp;
	public int ExpMax => expMax;
	public float ExpPer => (float)exp / (float)expMax;

	public string MainName => mainName;
	public string MainExplan => GetMainOptionString();
	public string SubExplan => GetSubOptionString();

	public bool Favorit { get; set; }
	public bool Lock { get; set; }
	public bool New { get; set; }

	public void Init(EQUIPMENTINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _mainValue, string _subOptionType, int _subOptionValue, int _maxBreakThrough)
	{
		itemSprite = ItemImage.Instance.GetEquip(_index);
		index = _index;
		star = _star;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		bFavorit = false;
		bNew = false;
		bLock = false;
		level = 1;
		maxLevel = 10;

		star = _star;

		mainValue = _mainValue;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		currBreakThrough = 1;
		maxBreakThrough = _maxBreakThrough;
	}

	private string GetMainOptionString()
	{
		switch (mainOption.optionIndex)
		{
			case EQUIPMENTOPTION.AttackValue:
				return "공격력 : " + mainOption.value;
			case EQUIPMENTOPTION.AttackPercent:
				return "공격력 퍼센트 : " + mainOption.value + "%";
			case EQUIPMENTOPTION.HPValue:
				return "체력 : " + mainOption.value + "%";
			case EQUIPMENTOPTION.HPPercent:
				return "체력 퍼센트 : " + mainOption.value + "%";
			case EQUIPMENTOPTION.ShieldValue:
				return "방어력 : " + mainOption.value + "%";
			case EQUIPMENTOPTION.ShieldPercent:
				return "방어력 퍼센트 : " + mainOption.value + "%";
		}
		return "";
	}

	public string GetSubOptionString()
	{
		string str = "";

		return str;
	}

	public static EQUIPMENTINDEX GetItemIndex(int _value)
	{
		EQUIPMENTINDEX index = EQUIPMENTINDEX.Star1_Flower;
		switch (_value)
		{
			case 0:
				index = EQUIPMENTINDEX.Star1_Flower;
				break;
			case 1:
				index = EQUIPMENTINDEX.Star1_Feather;
				break;
		}
		return index;
	}

	public static EQUIPMENTINDEX GetItemRandomIndex()
	{
		int min = 0;
		int max = 2;
		int randValue = UnityEngine.Random.Range(min, max);
		switch (randValue)
		{
			case 0: return EQUIPMENTINDEX.Star1_Flower;
			case 1: return EQUIPMENTINDEX.Star1_Feather;
			default:
				return EQUIPMENTINDEX.Star1_Flower;
		}
	}
}
