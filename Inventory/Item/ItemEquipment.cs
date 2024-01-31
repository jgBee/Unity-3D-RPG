using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemEquipment
{
	private EQUIPMENTINDEX index;
	private EQUIPMENTOPTION[] option;
	private EQUIPMENTSET set;
	private enum eType {Flower, Feather, Hourglass, Glass, Crown };
	private eType type;

	private Sprite itemSprite;
	private int star;

	private int level;
	private int maxLevel;

	private int mainValue;
	private string mainName;
	private string mainExplan;

	private int[] subValue;
	private string[] subExplan;

	private int exp;
	private int expMax;

	private int currBreakThrough;
	private int maxBreakThrough;

	private string setName;
	private string setExplan;



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
	public string MainExplan => System.String.Format(mainExplan, mainValue);
	public string SubExplan => "";

	public string SetName => setName;
	public string SetExplan => setExplan;

	public bool Favorit { get; set; }
	public bool Lock { get; set; }
	public bool Notify { get; set; }



	public void Init(EQUIPMENTINDEX _index, int _star, string _mainName, string _mainOption, int _mainValue, string _mainExplan, string _subExplan, int _maxBreakThrough, string _setName)
	{
		itemSprite = ItemImage.Instance.GetEquip(_index);
		index = _index;
		star = _star;

		level = 1;
		maxLevel = 10;

		mainValue = _mainValue;

		// 하단부 초기화 subValue;

		currBreakThrough = 1;
		maxBreakThrough = _maxBreakThrough;

		exp = 0;
		expMax = 10;

		mainName = _mainName;
		mainExplan = System.String.Format(mainExplan, mainValue);

		// 1. 타입 실정
		SettingType();

		// 2. 옵션 설정
		SettingSubOption();

		// 세트라는 것도 묶어야함
		// 2옵 4옵이랑 이름이랑 흠...
		switch (_setName)
		{
			case "base":
				setName = "기본 세트";
				setExplan = "2옵 4옵";
				break;
		}

	}

	private void SettingType()
	{
		switch (index)
		{
			case EQUIPMENTINDEX.Star1_Flower:


				type = eType.Flower;
				break;
			case EQUIPMENTINDEX.Star1_Feather:


				type = eType.Feather;
				break;
			case EQUIPMENTINDEX.Star1_Hourglass:


				type = eType.Hourglass;
				break;
			case EQUIPMENTINDEX.Star1_Glass:


				type = eType.Glass;
				break;
			case EQUIPMENTINDEX.Star1_Crown:


				type = eType.Crown;
				break;
		}
	}

	private void SettingSubOption()
	{
		switch (type)
		{
			case eType.Hourglass:
			case eType.Glass:
			case eType.Crown:



				break;
			default:
				break;
		}
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
